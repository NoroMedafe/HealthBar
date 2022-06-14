using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private HealthBar healthBar;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _health;

        healthBar.SetMaxHealth(_health);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(20);

        else if(Input.GetKeyDown(KeyCode.W))
            TakeHealth(20);
    }
    
    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            _currentHealth = 0;
        
        healthBar.SetHealth(_currentHealth);
    } 
    
    private void TakeHealth(int health)
    {
        _currentHealth += health;

        if (_currentHealth >= 100)
            _currentHealth = 0;

        healthBar.SetHealth(_currentHealth);
    }
}
