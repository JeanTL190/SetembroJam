using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int healthAtual;
    private void Awake()
    {
        healthAtual = maxHealth;
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
        Debug.Log(healthAtual);
    }
}
