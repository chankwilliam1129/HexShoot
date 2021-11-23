using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthBar : MonoBehaviour
{
    public playerManager player;
    public Text healthNum;
    public Text healthMaxNum;
    public Text LevelNum;
    public TextMeshProUGUI coinText;
    public GameObject playerExpBar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthNum.text = player.data.healthCounter.ToString("F0");
        healthMaxNum.text = player.getHealth().ToString("F0");
        LevelNum.text = "Lv." + player.data.level.ToString("F0");

        player.data.healthCounter = Mathf.Min(player.data.healthCounter, player.getHealth());
        float hp = player.data.healthCounter / player.getHealth();
        GetComponent<Image>().material.SetFloat("_Offset", hp);

        coinText.text = "coin:" + player.data.gold.ToString("F0");


        int curExp;
        if (player.getLevel() >= 30)
        {
            playerExpBar.GetComponent<Image>().material.SetFloat("_Offset", 1);
        }
        else
        {
            if (player.getLevel() == 0) curExp = 0;
            else curExp = player.experience[player.getLevel() - 1];
            float exp = (player.data.experiencePoint - curExp) * 1.0f / (player.experience[player.getLevel()] - curExp) * 1.0f;
            playerExpBar.GetComponent<Image>().material.SetFloat("_Offset", exp);
        }

    }
}
