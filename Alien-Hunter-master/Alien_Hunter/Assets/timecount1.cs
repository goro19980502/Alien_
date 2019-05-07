using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timecount1 : MonoBehaviour {

    public float startTime;
    public Text text;
    string s;
    public int timeInt;
    //public GameObject GameOverText;
    //public GameObject TimeText;
    void Update () {
        showtime();
	}
    void showtime()
    {
        float nowTime = Time.time - startTime;
        timeInt = 180 - (int)nowTime;
        Debug.Log("執行時間"+timeInt);
        s = timeInt.ToString();
        text.text = s;
        if (timeInt == 0)
        {
            s = "0";
            //GameOverText.SetActive(true);
            OnEnableStop();
            Application.LoadLevel(3);
            //TimeText.SetActive(false);
        }
            
            
    }
    //更新遊戲時間
    public void rest()
    {
        startTime = Time.time;
    }
    //時間暫停
    public void OnEnableStop()
    {
        Time.timeScale = 0f;
    }
    //時間以正常速度運行
    public void OnDisableStart()
    {
        Time.timeScale = 1f;
    }
}
