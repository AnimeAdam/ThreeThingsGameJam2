using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GotHit : MonoBehaviour
{

    [SerializeField] private HealthBar healthBar;
    const float MAXHEALTH = 100;
    float currentHealth = MAXHEALTH;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack")
            Debug.Log("Collision detected");
        TakeDamage(10);
    }

    private void TakeDamage(int v)
    {
        currentHealth -= v;
        healthBar.UpdateHealthBar(currentHealth, MAXHEALTH);
    }
}
