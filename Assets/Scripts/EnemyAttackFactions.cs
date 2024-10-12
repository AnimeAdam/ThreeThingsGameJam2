using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackFactions : MonoBehaviour
{
    private GameObject enemyToFight;
    private float timer = 0f;

    public GameObject attackObject;
    public float attackLifetime = 2f;
    public float attackSpeed = 200f;
    public float attackRange = 2f;
    public float timeBetweenAttacking = 3f;
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
        if (GetComponentInParent<EnemyStats>().unitState == UnitState.AttackingEnemy && enemyToFight != null){
            MoveTowardsEnemy();
            AttackEnemy();
        }
        else if (GetComponentInParent<EnemyStats>().unitState == UnitState.AttackingPlayer && enemyToFight != null){
            MoveTowardsEnemy();
            AttackEnemy();
        }
        else if (GetComponentInParent<EnemyStats>().unitState == UnitState.AttackingEnemy && enemyToFight == null){
            GetComponentInParent<EnemyStats>().ChangeUnitState(UnitState.MovingToCastle);
        }
        else if (GetComponentInParent<EnemyStats>().unitState == UnitState.AttackingCastle && enemyToFight == null){
            GetComponentInParent<EnemyStats>().ChangeUnitState(UnitState.MovingToCastle);
        }
    }

#region MovementCode
    void MoveTowardsEnemy() {        
            float distance = Vector3.Distance(transform.parent.position, enemyToFight.transform.position);
            float stepSpeed = GetComponentInParent<EnemyStats>().movementSpeed * Time.deltaTime;

            if (distance > minimumDistance)
                transform.parent.position = UnityEngine.Vector3.MoveTowards(transform.parent.position, enemyToFight.transform.position, stepSpeed);
    }
#endregion MovementCode

#region AttackCode
    void AttackEnemy()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacking) {
            switch (GetComponentInParent<EnemyStats>().unitAttackType){
                case UnitAttackType.Melee:
                    AttackMelee();
                    break;
                case UnitAttackType.Shooter:
                    AttackShooter();
                    break;
                default:
                    Debug.Log("Something has gone wrong with this: " + transform.parent.gameObject.name);
                    Debug.Break();
                    break;
            }
            timer = 0f;
        }
    }

    void AttackMelee()
    {
        float distance = Vector3.Distance(transform.parent.position, enemyToFight.transform.position);
        Vector3 meleeSpawnPoint = UnityEngine.Vector3.MoveTowards(transform.parent.position, enemyToFight.transform.position, 0.1f);
        Quaternion meleeRotation = Quaternion.LookRotation(Vector3.forward, enemyToFight.transform.position - transform.parent.position);

        if (distance <= attackRange){
            var meleeTemp = Instantiate(attackObject, meleeSpawnPoint, meleeRotation);
            meleeTemp.GetComponent<EnemyAttackMelee>().thisUnitType = thisUnitType;
        }
    }

    void AttackShooter()
    {
        float distance = Vector3.Distance(transform.parent.position, enemyToFight.transform.position);
        Vector3 projectileSpawnPoint = UnityEngine.Vector3.MoveTowards(transform.parent.position, enemyToFight.transform.position, 0.2f);
        Quaternion rotationDirection = Quaternion.LookRotation(Vector3.forward, enemyToFight.transform.position - transform.parent.position);

        if (distance <= attackRange) {
            var projectileTemp = Instantiate(attackObject, projectileSpawnPoint, rotationDirection);
            Vector3 projectileDirection = enemyToFight.transform.position - transform.parent.position;
            projectileTemp.GetComponent<Rigidbody2D>().AddForce(projectileDirection * attackSpeed);
            projectileTemp.GetComponent<EnemyAttackProjectile>().thisUnitType = thisUnitType;

            Destroy(projectileTemp, attackLifetime);
        }
    }
#endregion AttackCode

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy" && 
        GetComponentInParent<EnemyStats>().unitState == UnitState.MovingToCastle){
            if (col.gameObject.GetComponent<EnemyStats>().unitType != thisUnitType){
                GetComponentInParent<EnemyStats>().ChangeUnitState(UnitState.AttackingEnemy);
                enemyToFight = col.gameObject;
            }
        }
        if (col.gameObject.tag == "Castle" && 
        GetComponentInParent<EnemyStats>().unitState == UnitState.MovingToCastle){
            if (col.gameObject.GetComponent<GotHit>().castleType != gameObject.GetComponentInParent<EnemyMoveTowardsCastle>().homeBaseCastle) {
                GetComponentInParent<EnemyStats>().ChangeUnitState(UnitState.AttackingCastle);
                enemyToFight = col.gameObject;
            }
        }
        if (col.gameObject.tag == "Player" && 
        thisUnitType != UnitType.PlayerTroops){
            GetComponentInParent<EnemyStats>().ChangeUnitState(UnitState.AttackingPlayer);
            enemyToFight = col.gameObject;
        }
    }
}