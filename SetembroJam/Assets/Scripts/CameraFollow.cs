using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector2 maxXandY;
    [SerializeField] Vector2 minXandY;
    private Transform player;

    private void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player)
        {
            float x = Mathf.Clamp(player.position.x, minXandY.x, maxXandY.x);
            float y = Mathf.Clamp(player.position.y, minXandY.y, maxXandY.y);
            this.transform.position = new Vector3(x, y, this.transform.position.z);
        }
    }
}
