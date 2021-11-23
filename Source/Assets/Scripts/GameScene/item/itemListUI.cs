using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class itemListUI : MonoBehaviour
{
    public itemManager itemManager;
    public GameObject prefab;
    public float Yoffset;

    void Start()
    {
        for (int i = 0; i< (int)itemType.Total;i++)
        {
            Vector3 pos = transform.position;
            pos.y += Yoffset * i;

            itemUI obj = Instantiate(prefab, pos, Quaternion.identity, transform).GetComponent<itemUI>();
            obj.type = i;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
