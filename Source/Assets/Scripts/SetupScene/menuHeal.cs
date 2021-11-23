using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class menuHeal : MonoBehaviour
{
    public GameObject effect;
    public float rotateSpeed;

    public playerManager player;
    public itemManager item;
    public selectMenu menu;

    public Button button;
    public int cost;
    void Start()
    {
        Setup();
    }

    void Update()
    {
        effect.transform.Rotate(0.0f, rotateSpeed * Time.deltaTime, 0.0f);
        button.interactable = player.data.locationX == menu.position.x && player.data.locationZ == menu.position.z;
    }

    public void heal()
    {
        player.data.healthCounter = Mathf.Min(player.data.healthCounter + player.getHealth() * 0.2f, player.getHealth());

        mapSet temp = menu.map.data[menu.map.getCount(menu.vec)];

        menu.map.data[menu.map.getCount(menu.vec)] = new mapSet(temp.type, temp.level, temp.seek - cost);

        Setup();
    }

    void Setup()
    {
        int seek = menu.map.data[menu.map.getCount(menu.vec)].seek;
        int healCount = seek / cost + 1;
        if(seek<0)
        {
            healCount = 0;
        }

        button.interactable = healCount > 0;
        button.gameObject.GetComponentInChildren<Text>().text = "体力２０％回復\n(残り" + healCount.ToString("F0") + "回)"; 
    }
    void OnEnable()
    {
        Setup();
    }

}

