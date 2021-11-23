using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectMenu : MonoBehaviour
{
    public playerManager player;
    public mapManager map;
    public Vector2 vec;
    public Vector3 position;
    public Text text;

    public GameObject[] menuList;
    public Button moveButton;

    void Start()
    {

    }

    void Update()
    {
        text.text = vec.x.ToString("00") + "," + vec.y.ToString("00") + "  Lv:" + map.data[map.getCount(vec)].level.ToString("0");

        Vector3 pos = new Vector3(player.data.locationX, 0.0f, player.data.locationZ);
        moveButton.interactable = Vector3.Distance(pos, position) <= 1;

        moveButton.gameObject.SetActive(!menuList[2].activeSelf);
        
    }

    void OnValidate()
    {

        if (menuList.Length != (int)mapType.total) 
        {
            Array.Resize(ref menuList, (int)mapType.total);
        }
    }

    public void cancle()
    {
        gameObject.SetActive(false);
    }

    public void move()
    {
        player.data.locationX = position.x;
        player.data.locationZ = position.z;
    }

    public void turnOn(Vector2 vector)
    {
        gameObject.SetActive(true);
        vec = vector;
        foreach (var menu in menuList)
        {
            menu.SetActive(false);
        }
        menuList[(int)map.data[map.getCount(vec)].type].SetActive(true);
    }
}
