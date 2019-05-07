using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_follow_player : MonoBehaviour {

    
    public GameObject PivotObj;
    public float t;
    void Update()
    {
        Vector3 pv = PivotObj.transform.position;
        //transform.position = Vector3.Lerp(transform.position,pv, t);
        //transform.rotation = Quaternion.Euler(PivotObj.transform.eulerAngles.x, PivotObj.transform.eulerAngles.y, 0);
        transform.position =  pv;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(PivotObj.transform.eulerAngles.x, PivotObj.transform.eulerAngles.y, 0), t);
    }
}
