using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    //擊中特效
    public GameObject RefHitFx;
    //擊中怪物特效
    public GameObject RefFx;

    private void OnCollisionEnter(Collision collision)
    {
        //碰觸非自身玩家時, 產生煙霧特效
        if (collision.gameObject.name != "[CameraRig]")
        {
            Instantiate(RefHitFx, transform.position, Quaternion.identity);
        }

        //開啟重力效果
        GetComponent<Rigidbody>().useGravity = true;

        //擊中判定為"Monster"標籤, 產生煙霧特效並給予傷害, 並讓子彈消失
        if (collision.gameObject.tag == "Monster")
        {

            GameObject tmp = Instantiate(RefFx, transform.position, transform.rotation);
            tmp.transform.localScale = Vector3.one * 0.25f;

            if (collision.gameObject.GetComponent<DamageBehavior>())
            {
                collision.gameObject.GetComponent<DamageBehavior>().GiveDamage();
            }

            if (collision.gameObject.GetComponent<ThinDamageBehavior1>())
            {
                collision.gameObject.GetComponent<ThinDamageBehavior1>().GiveDamage();
            }
            if (collision.gameObject.GetComponent<BossDamageBehavior>())
            {
                collision.gameObject.GetComponent<BossDamageBehavior>().GiveDamage();
            }

            Destroy(gameObject);
        }
        
        
    }
}
