using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageBehavior : MonoBehaviour
{
    //傷害值
    public int Damage = 1;
    private BossMonsterBehavior monsterBehavior;

    private void Start()
    {
        monsterBehavior = GetComponentInParent<BossMonsterBehavior>();
    }

    public void GiveDamage()
    {
        monsterBehavior.OnDamage(Damage);
    }
}
