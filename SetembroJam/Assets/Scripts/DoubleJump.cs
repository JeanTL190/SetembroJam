using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private bool canDoubleJump = false;
    private PlayerJump pj;
    private Rigidbody2D rb;
    private void Awake()
    {
        pj = GetComponent<PlayerJump>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (pj.IsGrounded())
        {
            canDoubleJump = true;
        }
        PuloDuplo();

    }
    private void PuloDuplo()
    {
        if (Input.GetButtonDown("Jump") && !pj.IsGrounded() && canDoubleJump)
        {
            rb.velocity += Vector2.up * pj.GetJumpForce();
            canDoubleJump = false;
        }

    }
}
