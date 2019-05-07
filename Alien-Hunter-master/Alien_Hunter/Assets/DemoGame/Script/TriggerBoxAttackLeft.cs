using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxAttackLeft : MonoBehaviour {

    public Animator animator;
    public void OnTriggerStay(Collider Attack)
    {
        if (Attack.gameObject.tag == "Player")
        {
            animator.SetBool("AttackLeft", true);
        }
    }

}
