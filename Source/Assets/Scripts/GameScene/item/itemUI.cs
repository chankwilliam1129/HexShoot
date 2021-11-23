using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class itemUI : MonoBehaviour
{
    public itemManager itemManager;
    public playerManager player;

    public int type;
    public GameObject effect;
    public TextMesh text;

    void Start()
    {
        Color color = itemManager.itemList[type].color;
        GetComponent<MeshRenderer>().material.SetColor("_Emssion", color);

        effect.GetComponent<VisualEffect>().visualEffectAsset = itemManager.itemList[type].effectAsset;
       
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player.data.nowItem[type].ToString();
    }
}
