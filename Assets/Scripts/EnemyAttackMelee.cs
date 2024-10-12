using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMelee : MonoBehaviour
{
    public UnitType thisUnitType;

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            AttackEnemy(col);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            AttackPlayer(col);
        }        
    }

    private void AttackEnemy(Collider2D col)
    {
        if (col.GetComponent<EnemyStats>().unitType != thisUnitType){
            int damage = 1;
            if (EnemyAdvantagesSystem.DoesAttackerHaveAdvantage(thisUnitType, col.GetComponent<EnemyStats>().unitType))
                damage *= 2;
            col.gameObject.SendMessage("ApplyDamage", damage);
            DestoryThisMelee();
        }
    }


    private void AttackPlayer(Collider2D col)
    {
        if (col != null)
        {
            int damage = 1;
            col.gameObject.SendMessage("ApplyDamage", damage);
            DestoryThisMelee();
        }
    }

    void DestoryThisMelee()
    {
        Destroy(gameObject);
    }
}
