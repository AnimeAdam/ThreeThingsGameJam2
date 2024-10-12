using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    [SerializeField] private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar = GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("damaged");
        healthBar.UpdateHealthBar(currentHealth,maxHealth);
        CheckIfDead();
    }

    void CheckIfDead()
    {
        if (currentHealth <= 0){
            SceneManager.GoToGameOver();
        }
    }
}
