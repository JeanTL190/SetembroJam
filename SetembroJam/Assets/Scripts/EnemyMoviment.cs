using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    [SerializeField] Transform posiDireita;
    [SerializeField] Transform posiEsquerda;
    private Rigidbody2D rb;
    private Transform tToGo;
    private Animator anim;
    private float velAtual;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tToGo = posiDireita;
    }

    private void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        if (tToGo == posiDireita)
        {
            if (transform.position.x > tToGo.position.x)
            {
                tToGo = posiEsquerda;
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            rb.velocity = Vector2.right * velAtual;
        }
        else
        {
            if(transform.position.x< tToGo.position.x)
            {
                tToGo = posiDireita;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            rb.velocity = Vector2.left* velAtual;
        }
    }
    public void ChangeVel(float novaVel)
    {
        velAtual = novaVel;
    }
}
