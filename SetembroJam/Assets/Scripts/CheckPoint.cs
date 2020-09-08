using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject player;

    public void SpawnPlayer()
    {
        player.transform.position = this.transform.position;
        Instantiate(player);
    }
}
