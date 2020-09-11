using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private HealthBar hb;
    [SerializeField] private bool canTakeDamage = false;
    [SerializeField] private float recuoForce = 50f;
    private int healthAtual;
    private Animator anim;
    private ChangeSpeedEnemy cse;
    private Rigidbody2D rb;

    private void Awake()
    {
        cse = GetComponentInChildren<ChangeSpeedEnemy>();
        rb = GetComponent<Rigidbody2D>();
        healthAtual = maxHealth;
        hb.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            cse.TookDamage();
            healthAtual -= damage;
            rb.AddForce(-transform.right * recuoForce);
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
