using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class TriggerBoxAttackMid : MonoBehaviour
{
    public Animator animator;
    public void OnTriggerStay(Collider Attack)
    {
        if (Attack.gameObject.tag == "Player")
        {
            animator.SetBool("AttackMid", true);
        }
    }

}
