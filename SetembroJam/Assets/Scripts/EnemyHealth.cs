using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private HealthBar hb;
    [SerializeField] private bool canTakeDamage = false;
    private int healthAtual;
    private Animator anim;

    private void Awake()
    {
        healthAtual = maxHealth;
        hb.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            healthAtual -= damage;
        }
    }
    public void CanDamage(bool can)
    {
        canTakeDamage = can;
    }
    private void Update()
    {
        hb.SetHealth(healthAtual);
    }
}
