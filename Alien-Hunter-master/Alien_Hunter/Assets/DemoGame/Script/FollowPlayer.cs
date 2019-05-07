using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject PivotObj;
	
	void Update ()
    {
        Vector3 pv = PivotObj.transform.position;
        transform.position = pv + (Vector3.up * -.5f);
        transform.rotation = Quaternion.Euler(0, PivotObj.transform.eulerAngles.y, 0);
    }
}
