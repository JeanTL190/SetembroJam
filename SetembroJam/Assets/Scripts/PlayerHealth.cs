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
    private GameManager gm;
    private void Awake()
    {
        healthAtual = maxHealth;
        hb.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
    }
    public void TakeDamage(int damage)
    {
        rb.AddForce(-transform.right * recuo);
        healthAtual -= damage;
        if(healthAtual <= 0)
        {
            gm.Spawn();
        }
    }
    public void ResetVida()
    {
        healthAtual = maxHealth;
    }
    private void Update()
    {
        hb.SetHealth(healthAtual);
        maxHealth = gm.GetEnergiaVital();
    }
}
