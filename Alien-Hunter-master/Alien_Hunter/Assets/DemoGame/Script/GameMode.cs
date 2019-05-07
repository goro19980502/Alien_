using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    public Image TimeBar;
    public Text Text_Score;
    public MessageBehavior messageBehavior;
    public CountScore countScore;
    public timecount timecount;
    [Header("Time")]
    //時間設定值
    public int Timer = 60;
    //計算時間變數
    private float timerCount;
    //最大時間變數
    private float TimerLimit;

    [Header("Monster")]
    //怪物來源參考
    public GameObject RefMonster;
    //產生怪物時間, (最小, 最大)
    public Vector2 RandomTimeMonster = new Vector2(3, 10);
    private PathMove pathMove;

    [Header("TimerItem")]
    //道具來源參考
    public GameObject RefTimerItem;
    //產生道具時間, (最小, 最大)
    public Vector2 RandomTimeItem = new Vector2(15, 20);

    //分數變數
    private int Score = 0;
    private bool bGameOver = false;
    
    void Start ()
    {
        pathMove = GetComponent<PathMove>();
        timerCount = TimerLimit = Timer;

        StartCoroutine(SpawnMonster());
        StartCoroutine(SpawnTimerItem());
    }

    IEnumerator SpawnMonster()
    {
        //給予亂數時間, 產生怪物
        float rndTimer = Random.Range(RandomTimeMonster.x, RandomTimeMonster.y);
        yield return new WaitForSeconds(rndTimer);

        float rotY = Random.Range(0, 359);
        Instantiate(RefMonster, pathMove.GetRandomVector(), Quaternion.Euler(0, rotY, 0));

        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnTimerItem()
    {
        //給予亂數時間, 產生道具
        float rndTimer = Random.Range(RandomTimeItem.x, RandomTimeItem.y);
        yield return new WaitForSeconds(rndTimer);

        Instantiate(RefTimerItem, pathMove.GetRandomVector(), Quaternion.identity);

        StartCoroutine(SpawnTimerItem());
    }

    void Update ()
    {
        if (!bGameOver)
        {
            if (TimeBar.fillAmount > 0)
            {
                //給予時間條長度
                timerCount -= Time.deltaTime;
                TimeBar.fillAmount = timerCount / TimerLimit;

                //設定時間條顏色
                Color destColor = Color.green;
                if (TimeBar.fillAmount > .7f) destColor = Color.green;
                else if (TimeBar.fillAmount > .3f && TimeBar.fillAmount < .7f) destColor = new Color(1, .5f, 0);
                else if (TimeBar.fillAmount < .3f) destColor = Color.red;

                TimeBar.color = Color.Lerp(TimeBar.color, destColor, 0.15f);
            }
            else // 時間到
            {
/*                bGameOver = true;
                //messageBehavior.SetMessage("遊戲結束!!");

                //將場上所有怪物擊斃
                MonsterBehavior[] mb = FindObjectsOfType<MonsterBehavior>();
                foreach (var item in mb)
                {
                    item.OnDamage(10);
                }
                StopAllCoroutines();*/
            }
        }
        else
        {
            //關閉關卡重置
            //            StartCoroutine(DelayRestart());
        }
 /*       if(countScore.sum == 15 || timecount.timeInt == 170)
        {
            float rotY = Random.Range(0, 359);
            Instantiate(RefBoss, pathMove.GetRandomVector(), Quaternion.Euler(0, rotY, 0));
        }*/
    }

    IEnumerator DelayRestart()
    {
        //等待關卡重製
        yield return new WaitForSeconds(5f);
        StopAllCoroutines();
        SceneManager.LoadScene(0);
    }

    public void SetTimer(float amount)
    {
        string tmpMsg = "時間";

        if (amount > 0) tmpMsg += "+";

        messageBehavior.SetMessage(tmpMsg + amount + "秒");

        timerCount += amount;
        timerCount = Mathf.Clamp(timerCount, 0, Timer);
    }
    //分數
    public void SetScore(int amonut)
    {
        if (!bGameOver)
        {
            messageBehavior.SetMessage("分數+"+amonut+"分");
            Score += amonut;
            Text_Score.text = Score.ToString();
        }
        
    }
}
