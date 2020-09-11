using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    private CheckPointHealth cph;
    private void Awake()
    {
        cph = GetComponent<CheckPointHealth>();
    }

    public void SpawnPlayer()
    {
        if (player != null)
        {
            player.transform.position = this.transform.position;
            Instantiate(player);
        }
    }

    public void ResetCheckPoint()
    {
        if(cph.GetVida()<=0)
        {
            cph.ResetVida();
        }
    }
}
