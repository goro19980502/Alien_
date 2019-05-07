using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxAttackRight : MonoBehaviour {

    public Animator animator;
    public void OnTriggerStay(Collider Attack   )
    {
        if (Attack.gameObject.tag == "Player")
        {
            animator.SetBool("AttackRight", true);
        }
    }

}
