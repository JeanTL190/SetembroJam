using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private int dano = 1;
    [SerializeField] private LayerMask platformLayerMask;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(dano);
        }
    }

}
