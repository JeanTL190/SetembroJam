using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private HealthBar hb;
    [SerializeField] private float recuo = 10f;
    private int healthAtual;
    private Rigidbody2D rb;
    private Animator anim;
    private void Awake()
    {
        healthAtual = maxHealth;
        hb.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetMaxHealth(int valor)
    {
        maxHealth = valor;
    }
    public void TakeDamage(int damage)
    {
        rb.AddForce(-transform.right * recuo);
        healthAtual -= damage;
    }
    private void Update()
    {
        hb.SetHealth(healthAtual);
    }
}
