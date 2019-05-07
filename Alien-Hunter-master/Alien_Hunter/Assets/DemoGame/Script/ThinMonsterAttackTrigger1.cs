using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinMonsterAttackTrigger1 : MonoBehaviour
{
    //特效來源參考
    public GameObject RefFX;
    private Vector3 closeTarget;

    private void OnTriggerEnter(Collider other)
    {
        //如果觸碰到為"PlayerCom"的組件, 則進行以下動作
        if (other.GetComponent<PlayerCom>())
        {
            //給予玩家傷害
            other.GetComponent<PlayerCom>().OnDamage();

            //將特效於最接近的座標產生
            closeTarget = other.gameObject.transform.position;
            Vector3 closestPoint = other.ClosestPoint(closeTarget);
            Instantiate(RefFX, closestPoint, Quaternion.identity);

            //時間減一
            GameObject tmpGM = GameObject.FindGameObjectWithTag("GameModeTag");
            tmpGM.GetComponent<GameMode>().SetTimer(-1);
        }
        
    }
}
