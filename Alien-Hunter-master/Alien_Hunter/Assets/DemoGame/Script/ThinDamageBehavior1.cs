using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinDamageBehavior1 : MonoBehaviour
{
    //傷害值
    public int Damage = 1;
    public ThinMonsterBehavior1 monsterBehavior;

    void Start()
    {
        monsterBehavior = GetComponentInParent<ThinMonsterBehavior1>();
    }

    public void GiveDamage()
    {
        monsterBehavior.OnDamage(Damage);
    }
}
