using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumMoviment : MonoBehaviour
{
    private PlayerWalk pw;
    private Rigidbody2D rb;
    private Vector3 posiInicial;
    [SerializeField] private float speedStum = 1f;
    [SerializeField] private float maxDist = 3f;
    private void Awake()
    {
        pw = FindObjectOfType<PlayerWalk>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        posiInicial = this.transform.position;
        if(pw.GetRight())
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            rb.velocity = Vector2.right * speedStum;
        }
        else
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            rb.velocity = -Vector2.right * speedStum;
        }
    }
    private void Update()
    {
        Vector3 v = posiInicial - this.transform.position;
        if(v.magnitude>= maxDist)
        {
            Destroy(this.gameObject);
        }
    }

}
