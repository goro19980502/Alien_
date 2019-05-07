using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class GunBehavior : VRTK_InteractableObject
{
    [Space(20)]
    [Range(0, 1000f)]
    //彈道偏移值
    public float TrajectoryOffset = 500f;
    [Range(0, 10000f)]
    //子彈速度
    public float BulletSpeed = 10000f;
    //子彈數量
    public int bulletAmonut = 15;

    private Animation anim;
    //子彈來源參考
    public GameObject RefBullet;
    //火花特效來源參考
    public GameObject RefSpark;
    //彈殼特效來源參考
    public GameObject RefCartridge;

    //特效插槽對應
    public GameObject Pivot_Spark, Pivot_Cartridge;
    //彈藥數量顯示
    public Text Text_Bullet;

    //子彈生命時間
    private float bulletLife = 5f;
    //手把控制器變數
    private GameObject controller;

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);
        OnFire();
    }

    public override void Grabbed(VRTK_InteractGrab currentGrabbingObject = null)
    {
        base.Grabbed(currentGrabbingObject);

        controller = currentGrabbingObject.gameObject;
    }

    public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject = null)
    {
        base.Ungrabbed(previousGrabbingObject);

        controller = null;

        //當槍枝丟棄時, 給予物理反應
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.useGravity = true;
        }
        else
        {
            gameObject.AddComponent<Rigidbody>().useGravity = true;
        }
        
        Destroy(gameObject, bulletLife);
        Destroy(this);
    }

    protected void Start()
    {
        anim = GetComponent<Animation>();
    }

    protected override void Update ()
    {
        base.Update();

        //讓槍枝跟隨手把控制器
        if (controller != null)
        {
            transform.position = controller.transform.position;
            transform.rotation = controller.transform.rotation;
        }

        Text_Bullet.text = bulletAmonut.ToString();

        if (Input.GetKeyDown("f"))
        {
            OnFire();
        }
    }

    public void OnFire()
    {
        //彈藥數量減一
        bulletAmonut -= 1;
        if (bulletAmonut < 0)
        {
            bulletAmonut = 0;
        }
        else
        {
            //播放開槍動畫
            anim.Play();
            //產生子彈
            GameObject bullet = Instantiate(RefBullet, Pivot_Spark.transform.position, Quaternion.Euler(90, 0, 0));

            //計算子彈偏移值
            Vector3 vUp = transform.up * Random.Range(-TrajectoryOffset, TrajectoryOffset);
            Vector3 vRight = transform.right * Random.Range(-TrajectoryOffset, TrajectoryOffset);
            Vector3 vForce = (vUp + vRight) + (transform.forward * BulletSpeed);
            bullet.GetComponent<Rigidbody>().AddForce(vForce);
            Destroy(bullet, bulletLife);

            //產生火花特效
            GameObject spark = Instantiate(RefSpark, Pivot_Spark.transform);
            Destroy(spark, 0.16f);

            //產生彈殼特效
            GameObject bulletFX = Instantiate(RefCartridge, Pivot_Cartridge.transform);
        }
    }
}
