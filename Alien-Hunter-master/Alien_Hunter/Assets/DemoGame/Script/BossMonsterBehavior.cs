using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
public class BossMonsterBehavior : MonoBehaviour
{
    //目標變數
    public GameObject Target;
    //初始特效來源參考
    public GameObject RefBorn;
    //死亡特效來源參考
    public GameObject RefExplosion;

    public BoxCollider collider_Prop;

    //NavMeshAgent組件
    //private NavMeshAgent meshAgent;
    private Animator animator;

    //最近停止距離值
    //private float stopDestionation = 3.5f;
    //生命值
    public int HealthPoint = 30;
    //死亡布林值
    public bool bDeath = false;
    public CountScore countScore;
    //動畫Hash碼
    private static int state_Idle = Animator.StringToHash("Idle");
    private static int state_AttackRight = Animator.StringToHash("AttackRight");
    private static int state_AttackMid = Animator.StringToHash("AttackMid");
    private static int state_AttackLeft = Animator.StringToHash("AttackLeft");
    private static int state_Death = Animator.StringToHash("Death");
    //Congraulation
    public GameObject congrtulations;
    public GameObject game;
    void Start ()
    {
        animator = GetComponentInChildren<Animator>();
        countScore = GameObject.Find("Score").GetComponent<CountScore>();//抓取 Score 的 Component
        
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator DelayDestory()
    {
        yield return new WaitForSeconds(3.0f);
        Instantiate(RefExplosion, transform.position, transform.rotation);
        gameObject.SetActive(false);
        Destroy(this.gameObject);

    }

    public void OnDamage(int Dmg)
    {
        HealthPoint -= Dmg;
        //        animator.SetTrigger("Death");
        //        Destroy(this); 
        if(HealthPoint == 0)
        {
            StartCoroutine(DelayDestory());
            gameObject.SetActive(false);
            Destroy(this);
            congrtulations.SetActive(true);
            game.SetActive(false);
        }
    }

    void Update ()
    {
        animator.SetBool("AttackRight", true);
        animator.SetBool("AttackLeft", true);
        animator.SetBool("AttackMid", true);
        Debug.Log("healthPoint" + HealthPoint);
        //生命值低於0時, 執行死亡行為
        if (HealthPoint <= 0 && HealthPoint >= -10)
        {
            bDeath = true;
            collider_Prop.enabled = false;
            this.gameObject.SetActive(false);
            //將所有碰撞體關閉
            Collider[] cols = GetComponentsInChildren<Collider>();
            foreach (var item in cols)
            {
                item.enabled = false;
            }
            //Destroy(this.gameObject);
        }

        //死亡之後的動作
        if (bDeath)
        {
            //GameObject tmpGM = GameObject.FindGameObjectWithTag("GameModeTag");
            //tmpGM.GetComponent<GameMode>().SetScore(10);

            HealthPoint = -99;

            bDeath = false;
            animator.SetTrigger("Death");
            StartCoroutine(DelayDestory());
            return;
        }
    }

    
}
