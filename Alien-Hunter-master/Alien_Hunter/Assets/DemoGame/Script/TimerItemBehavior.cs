using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerItemBehavior : MonoBehaviour
{
    //增加時間變數
    public float AddTimer = 10f;
    //旋轉頻率
    public float Rot = 0.5f;
    //特效參考來源
    public GameObject RefFx;

    void Update ()
    {
        //自我旋轉指令
        transform.Rotate(new Vector3(0, Rot, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCom>())
        {
            Instantiate(RefFx, transform.position, Quaternion.identity);
            GameObject tmpGM = GameObject.FindGameObjectWithTag("GameModeTag");
            tmpGM.GetComponent<GameMode>().SetTimer(AddTimer);
            Destroy(gameObject);
        }
    }
}
