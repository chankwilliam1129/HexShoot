using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class menuShop : MonoBehaviour
{
    public playerManager player;
    public itemManager item;
    public selectMenu menu;

    public itemIcon[] itemIcons;
    public Button[] buttons;

    void Start()
    {

        Setup();

    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<4;i++)
        {
            if (player.data.locationX == menu.position.x && player.data.locationZ == menu.position.z)
            {
                if (player.data.gold < item.itemList[itemIcons[i].type].cost)
                {
                    buttons[i].interactable = false;
                }
                else
                {
                    buttons[i].interactable = true;
                }
            }
            else
            {
                buttons[i].interactable = false;
            }
        }

    }


    void OnEnable()
    {
        Setup();
    }


    public void Buy(int num)
    {
        player.data.gold -= item.itemList[itemIcons[num].type].cost;
        player.data.nowItem[itemIcons[num].type]++;
    }


    void Setup()
    {
        int seek = menu.map.data[menu.map.getCount(menu.vec)].seek;

        for (int itemCount = 0, iconCount = 0; iconCount < 4 && itemCount < 7; itemCount++)
        {

            if ((seek & (2 << itemCount)) != 0)
            {
                itemIcons[iconCount].type = itemCount;
                itemIcons[iconCount].setup();
                iconCount++;
                continue;
            }

            if (6 - itemCount < 4 - iconCount)
            {
                itemIcons[iconCount].type = itemCount;
                itemIcons[iconCount].setup();
                iconCount++;
            }
        }

        for (int i = 0; i < 4; i++) 
        {
            buttons[i].GetComponentInChildren<Text>().text = "COST:" + item.itemList[itemIcons[i].type].cost.ToString("F0");
        }
    }
}
