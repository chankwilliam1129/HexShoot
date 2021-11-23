using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuChest : MonoBehaviour
{
    public GameObject effect;
    public float rotateSpeed;

    public playerManager player;
    public itemManager item;
    public selectMenu menu;
    public int gold;

    public Button button;
    void Start()
    {
        Setup();
    }

    void Update()
    {
        effect.transform.Rotate(0.0f, rotateSpeed * Time.deltaTime, 0.0f);
        button.interactable = player.data.locationX == menu.position.x && player.data.locationZ == menu.position.z;
    }

    public void getGold()
    {
        player.data.gold += gold;

        mapSet temp = menu.map.data[menu.map.getCount(menu.vec)];

        menu.map.data[menu.map.getCount(menu.vec)] = new mapSet(temp.type, temp.level, 0);

        Setup();
    }

    void Setup()
    {
        int seek = menu.map.data[menu.map.getCount(menu.vec)].seek;
        if(seek>0)
        {
            gold = menu.map.data[menu.map.getCount(menu.vec)].level * 30;
        }
        else
        {
            gold = 0;
        }
        button.interactable = seek > 0;

        button.gameObject.GetComponentInChildren<Text>().text = gold.ToString("F0") + "コイン獲得";
    }
    void OnEnable()
    {
        Setup();
    }

}
