using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector2 maxXandY;
    [SerializeField] Vector2 minXandY;
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void LateUpdate()
    {
        float x = Mathf.Clamp(player.position.x, minXandY.x, maxXandY.x);
        float y = Mathf.Clamp(player.position.y, minXandY.y, maxXandY.y);
        this.transform.position = new Vector3(x,y, this.transform.position.z);
    }
}
