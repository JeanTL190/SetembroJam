using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private Animator anim;
    private GameManager gm;
    private int damage;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        anim = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        damage = gm.GetEnergiaVital();
        if (Input.GetButtonDown("Attack"))
        {
            anim.SetTrigger("Attack");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            EnemyHealth eh = collision.GetComponent<EnemyHealth>();
            CheckPointHealth cph = collision.GetComponent<CheckPointHealth>();
            if (eh != null)
            {
                eh.TakeDamage(damage);
            }
            if (cph != null)
            {
                cph.TakeDamage(damage);
            }
        }
    }
}
