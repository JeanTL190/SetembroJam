using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeedEnemy : MonoBehaviour
{
    [SerializeField] private float normalSpeed = 1f;
    [SerializeField] private float fastSpeed = 2f;
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private float acel = 0.5f;
    [SerializeField] private float damageTime = 0.5f;

    private EnemyMoviment em;
    private float speedAtual;
    private bool inRange = false;
    private float damageTimer = 0f;
    private bool atacando = false;
    private bool tookdamage = false;

    private void Awake()
    {
        speedAtual = normalSpeed;
        em = GetComponentInParent<EnemyMoviment>();
        em.ChangeVel(speedAtual);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            inRange = false;
        }
    }
    public void SetAtaque(bool a)
    {
        atacando = a;
    }
    public bool GetInRange()
    {
        return inRange;
    }
    public void TookDamage()
    {
        tookdamage = true;
    }
    private void FixedUpdate()
    {
        if (!tookdamage)
        {
            if (!inRange)
            {
                if (speedAtual > normalSpeed)
                {
                    speedAtual = Mathf.Clamp(speedAtual - acel, normalSpeed, fastSpeed);
                }
                else if (speedAtual < normalSpeed)
                {
                    speedAtual = Mathf.Clamp(speedAtual + acel, 0, normalSpeed);
                }
            }
            else
            {
                if (!atacando)
                {
                    speedAtual = Mathf.Clamp(speedAtual + acel, 0, fastSpeed);
                }
                else
                {
                    speedAtual = 0;
                }
            }
        }
        else
        {
            speedAtual = 0;
        }
        em.ChangeVel(speedAtual);
    }
    private void Update()
    {
        if (tookdamage)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageTime)
            {
                tookdamage = false;
                damageTimer = 0;
            }
        }
    }
}
