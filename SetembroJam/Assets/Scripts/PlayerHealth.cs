using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private HealthBar hb;
    private int healthAtual;
    private void Awake()
    {
        healthAtual = maxHealth;
        hb.SetMaxHealth(maxHealth);
    }
    public void SetMaxHealth(int valor)
    {
        maxHealth = valor;
    }
    public void TakeDamage(int damage)
    {
        healthAtual -= damage;
    }
    private void Update()
    {
        hb.SetHealth(healthAtual);
    }
}
