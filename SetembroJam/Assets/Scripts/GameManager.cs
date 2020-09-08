using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CheckPoint[] checkPoints;
    private int checkPointAtual = 0;
    public void Spawn()
    {
        checkPoints[checkPointAtual].SpawnPlayer();
    }
}
