using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private PlayerHealth ph;
    private CheckPointHealth cph;
    private void Awake()
    {
        cph = GetComponent<CheckPointHealth>();
        ph = FindObjectOfType<PlayerHealth>();
    }

    public void SpawnPlayer()
    {
        ph.ResetVida();
        ph.transform.position = this.transform.position;
    }

    public void ResetCheckPoint()
    {
        if(cph.GetVida()<=0)
        {
            cph.ResetVida();
        }
    }
}
