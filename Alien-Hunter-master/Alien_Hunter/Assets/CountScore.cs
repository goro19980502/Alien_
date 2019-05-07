using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScore : MonoBehaviour {

    public int sum = 0;
    public Text text;
    public GameObject GameWinner;
    public timecount timecount;
    void Start()
    {
        timecount = GameObject.Find("Time").GetComponent<timecount>();    
    }
    void Update()
    {
        if(sum >= 15)
            OnWinner();    
    }
    public void scoreCount(int n)
    {
        sum++;
        string s = sum.ToString();
        text.text = s;
    }
    void OnWinner()
    {
        timecount.rest();
        GameWinner.SetActive(true);
        StartCoroutine(DelayDestory());
        Application.LoadLevel(1);
    }
    IEnumerator DelayDestory()
    {
        yield return new WaitForSeconds(10f);
    }

}
