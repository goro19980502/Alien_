using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SpawnGunBehavior : MonoBehaviour
{
    //槍枝來源參考
    public GameObject GunPrefab;
    //槍枝產生時間延遲
    public float spawnDelay = 1f;
    //產生延遲計時器
    private float spawnDelayTimer = 0f;
    //槍枝數量索引值
    private int gunIndex = 0;

    private void OnTriggerStay(Collider collider)
    {
        //取得控制器的<VRTK_InteractGrab>組件
        VRTK_InteractGrab grabbingController = (collider.gameObject.GetComponent<VRTK_InteractGrab>() ? collider.gameObject.GetComponent<VRTK_InteractGrab>() : collider.gameObject.GetComponentInParent<VRTK_InteractGrab>());

        if (grabbingController && grabbingController.IsGrabButtonPressed())
        {
            //當手把控制器目前沒抓取任何東西時, 則產生槍枝, 並附著在手上
            if (grabbingController.GetGrabbedObject() == null && Time.time >= spawnDelayTimer)
            {
                gunIndex++;
                GameObject newGun = Instantiate(GunPrefab, transform.position, Quaternion.identity);
                newGun.name = "NewGun_" + gunIndex;

                grabbingController.GetComponent<VRTK_InteractTouch>().ForceTouch(newGun);
                grabbingController.AttemptGrab();
                spawnDelayTimer = Time.time + spawnDelay;
            }
        }
    }
}
