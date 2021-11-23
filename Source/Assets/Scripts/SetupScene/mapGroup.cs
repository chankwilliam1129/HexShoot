using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGroup : MonoBehaviour
{
    public mapManager map;
    public mapBasicManager basic;
    public GameObject prefab;

    float xOffset = 0.882f;
    float zOffset = 0.764f;

    void Start()
    {
        if (map.data.Count !=331)
        {
            CreateNewMap();
        }
        else
        {
            CreateMap();
        }

        Time.timeScale = 1f;
    }

    void Update()
    {
    }

    void CreateNewMap()
    {
        map.data = new List<mapSet>();
        foreach (var n in basic.data)
        {
            float xPos = n.vector.x * xOffset;
            if (n.vector.y % 2 == 1)
            {
                xPos += xOffset / 2f;
            }
            GameObject mapObject = Instantiate(prefab, new Vector3(xPos + transform.position.x, 0, n.vector.y * zOffset + transform.position.z), Quaternion.identity, transform);
            SetupNewMap(mapObject, n.vector);
        }  
    }
    void SetupNewMap(GameObject mapObject, Vector2 vec)
    {
        mapObject.name = "Map_" + vec.x + "_" + vec.y;
        mapState state = mapObject.GetComponent<mapState>();
        state.group = this;
        state.vector = vec;
        float distance = Vector3.Distance(mapObject.transform.position, Vector3.zero);
        mapSet set = new mapSet(basic.data[map.getCount(vec)].type, (int)distance);
        if(set.type == mapType.empty) 
        {
            float rand = Random.value;

            if (distance > 4.0f)
            {
                if (rand > 0.94f) set.type = mapType.chest;
                else if (rand > 0.88f) set.type = mapType.heal;
                else if (rand > 0.82f) set.type = mapType.shop;
                else if (rand > 0.5f) set.type = mapType.elite;
                else set.type = mapType.normal;
            }
            else
            {
                if (rand > 0.94f) set.type = mapType.heal;
                else if (rand > 0.7f) set.type = mapType.elite;
                else set.type = mapType.normal;
            }
        }
        map.data.Add(set);
    }

    void CreateMap()
    {
        foreach (var n in basic.data)
        {
            float xPos = n.vector.x * xOffset;
            if (n.vector.y % 2 == 1)
            {
                xPos += xOffset / 2f;
            }
            GameObject mapObject = Instantiate(prefab, new Vector3(xPos + transform.position.x, 0, n.vector.y * zOffset + transform.position.z), Quaternion.identity, transform);
            SetupMap(mapObject, n.vector);
        }
    }
    void SetupMap(GameObject mapObject, Vector2 vec)
    {
        mapObject.name = "Map_" + vec.x + "_" + vec.y;
        mapState state = mapObject.GetComponent<mapState>();
        state.group = this;
        state.vector = vec;
    }
}
