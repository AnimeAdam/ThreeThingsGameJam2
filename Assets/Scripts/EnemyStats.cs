using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public float movementSpeed = 2f;
    public UnitType unitType;
    public UnitAttackType unitAttackType;
    public UnitState unitState;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        ChangeUnitState(UnitState.MovingToCastle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeUnitState(UnitState state)
    {
        unitState = state;
    }

    void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        CheckIfDead();
    }

    void CheckIfDead()
    {
        if (currentHealth <= 0){
            gameObject.SendMessage("DestoryThisEnemy");
        }

    }
}
