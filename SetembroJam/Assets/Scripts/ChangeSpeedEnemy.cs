using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeedEnemy : MonoBehaviour
{
    [SerializeField] float normalSpeed = 1f;
    [SerializeField] float fastSpeed = 2f;
    [SerializeField] private LayerMask platformLayerMask;
    private EnemyMoviment em;
    private void Awake()
    {
        em = GetComponentInParent<EnemyMoviment>();
        em.ChangeVel(normalSpeed);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            em.ChangeVel(fastSpeed);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            em.ChangeVel(normalSpeed);
        }
    }
}
