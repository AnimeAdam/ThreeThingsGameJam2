using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowEnemy : MonoBehaviour
{

    private GameObject enemy;
    public bool hasSeenEnemy ;
    private float speed;
    [SerializeField] private HandleAnimation handleAnimation;
    // Start is called before the first frame update
    void Start()
    {
        hasSeenEnemy = false;
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSeenEnemy && enemy.gameObject!= null) {
            UnityEngine.Vector3 direction = enemy.gameObject.transform.position - transform.position;
            handleAnimation.SetDirection(direction);
            followEnemy(enemy.gameObject.transform.position);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            setEnemy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "Enemy")
        {
           setEnemy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasSeenEnemy = false;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            hasSeenEnemy = false;
        }
    }
    private void setEnemy(GameObject myEnemy)
    {
        hasSeenEnemy = true;
        enemy = myEnemy;
    }
    private void followEnemy(Vector2 pos)
    {
        float dist = Vector3.Distance(pos, transform.position);
        if(dist > 2)
            transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);

    }
}
