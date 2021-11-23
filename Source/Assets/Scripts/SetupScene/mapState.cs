using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class mapState : MonoBehaviour
{
    public mapGroup group;
    public Vector2 vector;

    public GameObject top;
    public GameObject bottom;

    private mapSet data;
    private int num;

    void Start()
    {
        num = group.map.getCount(vector);
        data = group.map.data[num];
        top.GetComponent<MeshRenderer>().material.SetFloat("_Angle", Random.Range(10f, 50f));
        Reload();
    }

    void Update()
    {

    }

    public void Reload()
    {
        data = group.map.data[num];
        switch (data.type)
        {
            case mapType.empty:
            case mapType.total:
                top.SetActive(false);
                break;

            default:
                top.SetActive(true);
                top.GetComponent<MeshRenderer>().material.SetColor("_Color", group.map.typeSetList[(int)data.type].color);
                break;
        }
    }
}
