using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Guarda : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            //Ativa trigger da animacao
        }
    }
}
