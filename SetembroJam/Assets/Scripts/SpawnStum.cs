using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStum : MonoBehaviour
{
    [SerializeField] private Transform spawn;
    [SerializeField] private GameObject go;
    private bool ipt;
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Stum()
    {
        go.transform.position = spawn.transform.position;
        Instantiate(go);
    }
 
    private void Update()
    {
        ipt = Input.GetButtonDown("Stum");
        if (ipt)
        {
            anim.SetTrigger("Energy");
        }
    }
}
