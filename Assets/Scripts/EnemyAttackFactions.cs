using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackFactions : MonoBehaviour
{
    private GameObject enemyToFight;
    public UnitType thisUnitType;
    public float minimumDistance = 1f; //Minimum distance the enemy can be to another enemy.

    // Start is called before the first frame update
    void Start()
    {
        thisUnitType = GetComponentInParent<EnemyStats>().unitType;
    }

    // Update is called once per frame
    void Update()
    {        
        MoveTowardsEnemy();
    }

    void MoveTowardsEnemy() {
        if (GetComponentInParent<EnemyStats>().unitState == UnitState.AttackingEnemy){
            float distance = Vector3.Distance(transform.parent.position, enemyToFight.transform.position);
            float stepSpeed = GetComponentInParent<EnemyStats>().movementSpeed * Time.deltaTime;

            if (distance > minimumDistance)
                transform.parent.position = UnityEngine.Vector3.MoveTowards(transform.parent.position, enemyToFight.transform.position, stepSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy" && 
        GetComponentInParent<EnemyStats>().unitState != UnitState.AttackingEnemy){
            if (col.gameObject.GetComponent<EnemyStats>().unitType != thisUnitType){
                GetComponentInParent<EnemyStats>().ChangeUnitState(UnitState.AttackingEnemy);
                enemyToFight = col.gameObject;
            }
        }
    }
}