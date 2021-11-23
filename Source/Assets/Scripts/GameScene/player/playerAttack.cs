using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    public playerManager player;
    public playerBullteManager BullteManager;
    public GameObject bullteOut;

    private float bullteTimeCounter;
    void Start()
    {
    }
    void Update()
    {
        if(bullteTimeCounter<=0)
        {
            if(Input.GetMouseButton(0))
            {
                int num = player.data.nowItem[(int)itemType.MultShotRate] * (int)player.itemManager.itemList[(int)itemType.MultShotRate].value;
                shot(1 + Random.Range(0, 99 + num) / 100);
                bullteTimeCounter = BullteManager.bullteList[player.data.bullteNum].reloadSpeed;
            }
        }
        else
        {
            bullteTimeCounter -= Time.deltaTime * player.getReloadSpeed();
        }

    }

    void shot(int num)
    {
        for (int i = 0; i < num; i++)
        {
            float angle = (i - (num - 1) * 0.5f) * 6.0f;
            Vector3 rotate = new Vector3(0.0f, angle, 0.0f);
            playerBulltePrefab Prefab = BullteManager.bullteList[player.data.bullteNum];
            playerBullteMove bullteNow = Instantiate(Prefab.prefab, bullteOut.transform.position, bullteOut.transform.rotation);
            bullteNow.transform.Rotate(rotate);
            bullteNow.speed = Prefab.moveSpeed;
            bullteNow.damage = Prefab.damage * player.getAttackPower();
        }
    }
}
