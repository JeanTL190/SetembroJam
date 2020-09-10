using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastDown : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerJump pj;
    private Animator anim;
    [SerializeField] private string ipt;
    [SerializeField] private float acel = 1f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pj = GetComponent<PlayerJump>();
    }
    private void Update()
    {
        float aux = Input.GetAxis(ipt);
        if(aux<0 && !pj.IsGrounded())
        {
            rb.velocity -= Vector2.up*acel;
        }
    }
}
