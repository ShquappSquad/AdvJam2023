using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    
    public float sceneCount;

    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x <= 0)
        {
            transform.position = new Vector3(0, transform.position.y, -10);
        }
        else
        {
            transform.position = new Vector3(player.position.x, transform.position.y, -10);
        }
    }
}
