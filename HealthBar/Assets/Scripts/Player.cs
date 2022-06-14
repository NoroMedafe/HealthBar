using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _health;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(20);

        else if(Input.GetKeyDown(KeyCode.W))
            Heal(20);
    }

    private void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
        HealthChanged?.Invoke(_health, _maxHealth);
    } 
    
    private void Heal(int health)
    {
      
        _health = Mathf.Clamp(_health+health, 0, _maxHealth);
        HealthChanged?.Invoke(_health, _maxHealth);
    }
    
}
