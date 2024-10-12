using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        CheckIfDead();
    }

    void CheckIfDead()
    {
        if (currentHealth <= 0){
            SceneManager.GoToGameOver();
        }
    }
}
