using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class itemIcon : MonoBehaviour
{
    public itemManager itemManager;

    public float rotateSpeed;

    public int type;
    public GameObject effect;
    public TextMesh text;

    void Start()
    {
        setup();
    }

    // Update is called once per frame
    void Update()
    {
        effect.transform.Rotate(0.0f,rotateSpeed * Time.deltaTime, 0.0f);
    }

    public void setup()
    {
        Color color = itemManager.itemList[type].color;
        GetComponent<MeshRenderer>().material.SetColor("_Emssion", color);

        effect.GetComponent<VisualEffect>().visualEffectAsset = itemManager.itemList[type].effectAsset;
        text.text = itemManager.itemList[type].name;
    }
}
