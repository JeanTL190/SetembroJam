using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CheckPoint[] checkPoints;
    private int checkPointAtual = 0;
    private static int energiaVital = 3;
    public void Spawn()
    {
        checkPoints[checkPointAtual].SpawnPlayer();
    }
    public int GetEnergiaVital()
    {
        return energiaVital;
    }
    public void SetEnergiaVital(int e)
    {
        energiaVital = e;
    }
}
