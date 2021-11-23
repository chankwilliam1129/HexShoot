using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameScene : MonoBehaviour
{
    public gameSceneManager game;
    public playerManager player;
    public mapManager map;

    public GameObject winPanel;
    public Text winText;
    public GameObject failPanel;
    void Start()
    {
        game.SetupGameScene();
    }

    void Update()
    {
        if(game.enemyCounter <=0)
        {
            winPanel.SetActive(true);
            if (winPanel.activeSelf)
            {
                winText.text = game.gold.ToString("F0") + "コインを獲得";
                Time.timeScale = 0f;
            }
        }

        if (player.data.healthCounter <= 0)
        {
            failPanel.SetActive(true);
            if (failPanel.activeSelf)
            {
                Time.timeScale = 0f;
            }
        }

    }


    public void win()
    {
        winPanel.SetActive(false);
        player.data.gold += game.gold;
        player.data.healthCounter += player.data.nowItem[(int)itemType.HealPerRound] * game.item.itemList[(int)itemType.HealPerRound].value;
        game.SetupSceneStart();
    }

    public void fail()
    {
        player.reset();
        map.data.Clear();

        failPanel.SetActive(false);
        game.SetupSceneStart();
    }
}
