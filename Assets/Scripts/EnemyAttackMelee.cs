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
    }

    private void AttackEnemy(Collider2D col)
    {
        if (col.GetComponent<EnemyStats>().unitType != thisUnitType){
            col.gameObject.SendMessage("ApplyDamage", 1);
            DestoryThisMelee();
        }
    }

    void DestoryThisMelee()
    {
        Destroy(gameObject);
    }
}
