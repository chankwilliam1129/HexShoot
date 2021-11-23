using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuNormal : MonoBehaviour
{
    public playerManager player;
    public selectMenu menu;
    public gameSceneManager game;

    public Button gameStartButton;

    public Text levelText;

    void Start()
    {
        Setup();
    }

    void Update()
    {
        gameStartButton.interactable = menu.moveButton.interactable;
    }

    void OnEnable()
    {
        Setup();
    }

    void Setup()
    {
        levelText.text = "Level:" + menu.map.data[menu.map.getCount(menu.vec)].level.ToString("F0");
    }

    public void SetupGameScene()
    {
        game.Reset();
        game.level = menu.map.data[menu.map.getCount(menu.vec)].level;
        game.seek = menu.map.data[menu.map.getCount(menu.vec)].seek;
        game.type = menu.map.data[menu.map.getCount(menu.vec)].type;

        player.data.locationX = menu.position.x;
        player.data.locationZ = menu.position.z;
    }
}
