using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStum : MonoBehaviour
{
    [SerializeField] private Transform spawn;
    [SerializeField] private float timeToStum = 2f;
    [SerializeField] private GameObject go;
    private bool ipt;
    IEnumerator Stum()
    {
        while (true)
        {
            if (ipt)
            {
                go.transform.position = spawn.position;
                Instantiate(go);
                yield return new WaitForSeconds(timeToStum);
            }
            else
                yield return new WaitForEndOfFrame();
        }
    }
    private void Awake()
    {
        StartCoroutine("Stum");
    }
    private void Update()
    {
        ipt = Input.GetButtonDown("Stum");
    }
}
