using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehavior : MonoBehaviour
{
    //傷害值
    public int Damage = 1;
    private MonsterBehavior monsterBehavior;

    private void Start()
    {
        monsterBehavior = GetComponentInParent<MonsterBehavior>();
    }

    public void GiveDamage()
    {
        monsterBehavior.OnDamage(Damage);
    }
}
