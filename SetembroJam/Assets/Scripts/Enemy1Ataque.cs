using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Ataque : MonoBehaviour
{
    [SerializeField] private float distMin = 1.5f;
    [SerializeField] float intervaloEntreAttacks = 2f;
    [SerializeField] GameObject hitbox;
    private Animator anim;
    private Transform target;
    private ChangeSpeedEnemy cse;
    private float nextAttack;
    private void Awake()
    {
        cse = GetComponentInChildren<ChangeSpeedEnemy>();
    }
    private void Update()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
      
        if (target != null)
        {
            if (Mathf.Abs(target.position.x - transform.position.x) < distMin && cse.GetInRange())
            {
                cse.SetAtaque(true);
                if(Time.time > nextAttack)
                {
                    nextAttack = Time.time + intervaloEntreAttacks;
                }
            }
            else
            {
                cse.SetAtaque(false);
            }
        }
    }
}
