using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CheckPoint[] checkPoints;
    [SerializeField] private int energiaVital = 3;
    private int checkPointAtual = 0;
    
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
    public void SetNextCheckPoint(int c)
    {
        checkPointAtual=c;
    }
    public void RestauraCheckPoint()
    {
        checkPointAtual = Mathf.Clamp(checkPointAtual - 1, 0, checkPoints.Length-1);
        checkPoints[checkPointAtual].ResetCheckPoint();
    }
}
