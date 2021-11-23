using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setupSceneCamera : MonoBehaviour
{
    public playerManager player;

    public Vector3 newPos;
    public float moveSpeed;
    public float speedOffset;
    public float moveArea;
    public Vector2 moveLimit;


    private Vector3 posOffset;
    private Vector3 nowPos;


    void Start()
    {
        posOffset = transform.position;
        Vector3 pos = new Vector3(player.data.locationX, 0.0f, player.data.locationZ);
        transform.position = posOffset + pos;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        if (mousePos.x > 0 && mousePos.x < Screen.width && mousePos.y > 0 && mousePos.y < Screen.height)
        {
            if (mousePos.x < moveArea) newPos.x = nowPos.x - moveSpeed;
            else if (mousePos.x > (Screen.width - moveArea)) newPos.x = nowPos.x + moveSpeed;


            if (mousePos.y < moveArea) newPos.z = nowPos.z - moveSpeed;
            else if (mousePos.y > (Screen.height - moveArea)) newPos.z = nowPos.z + moveSpeed;
        }

        nowPos += (newPos - nowPos) * speedOffset;

        nowPos.x = Mathf.Clamp(nowPos.x, -moveLimit.x, moveLimit.x);
        nowPos.z = Mathf.Clamp(nowPos.z, -moveLimit.y, moveLimit.y);

        transform.position = nowPos + posOffset;
        

    }
}

