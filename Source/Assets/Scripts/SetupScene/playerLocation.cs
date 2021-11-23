using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLocation : MonoBehaviour
{
    public playerManager player;
    public mapGroup map;

    void Start()
    {
        
    }
    void Update()
    {
        transform.position = new Vector3(player.data.locationX, 0.0f, player.data.locationZ);
    }
}
