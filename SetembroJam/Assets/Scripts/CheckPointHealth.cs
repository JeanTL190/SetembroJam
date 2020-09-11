using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointHealth : MonoBehaviour
{
    [SerializeField] private int vidaMax = 1;
    [SerializeField] private int number;
    private static int quantDestroy = 0;
    private bool canDamage = true;
    private int vida = 0;
    private GameManager gm;
    private void Awake()
    {
        vida = vidaMax;
        gm = GetComponent<GameManager>();
    }
    public void TakeDamage(int damage)
    {
        if (canDamage)
        {
            vida = Mathf.Clamp(vida - damage, 0, vidaMax);
            if (vida <= 0)
            {
                gm.SetNextCheckPoint(number + 1);
                quantDestroy++;
                canDamage = false;
            }
        }
    }
    public void ResetVida()
    {
        vida = vidaMax;
        quantDestroy--;
        canDamage = true;
    }
    public int GetVida()
    {
        return vida;
    }
    private void Update()
    {
        gm.SetEnergiaVital(gm.GetEnergiaVital() - quantDestroy / 3);
    }
}
