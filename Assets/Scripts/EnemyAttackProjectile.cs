using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackProjectile : MonoBehaviour
{
    public UnitType thisUnitType;

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            AttackEnemy(col);
        }
    }

    private void AttackEnemy(Collider2D col)
    {
        if (col.GetComponent<EnemyStats>().unitType != thisUnitType){
            int damage = 1;
            if (EnemyAdvantagesSystem.DoesAttackerHaveAdvantage(thisUnitType, col.GetComponent<EnemyStats>().unitType))
                damage *= 2;
            col.gameObject.SendMessage("ApplyDamage", damage);
            DestoryThisProjectile();
        }
    }

    void DestoryThisProjectile()
    {
        Destroy(gameObject);
    }
}
