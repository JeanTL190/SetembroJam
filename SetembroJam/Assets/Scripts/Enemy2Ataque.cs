using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Ataque : MonoBehaviour
{
    private EnemyMoviment em;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] float velMax = 2f;
    private bool inRange = false;
    private bool stunado = false;

    private void Awake()
    {
        em = GetComponent<EnemyMoviment>();
        em.ChangeVel(velMax);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && (((1 << collision.gameObject.layer) & playerLayerMask) != 0))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && (((1 << collision.gameObject.layer) & playerLayerMask) != 0))
        {
            inRange = false;
        }
    }
    public void Stunar(bool s)
    {
        stunado = s;
    }
    private void Update()
    {
        if(inRange || stunado)
        {
            em.ChangeVel(0);
        }
        else
        {
            em.ChangeVel(velMax);
        }
    }
}
