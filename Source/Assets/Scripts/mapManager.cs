using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Rendering;

public enum mapType
{
    empty,
    normal,
    elite,
    boss,
    shop,
    chest,
    heal,
    total,
}

[System.Serializable]
public struct mapSet
{
    public mapType type;
    public int level;
    public int seek;

    public mapSet(mapType type,int level)
    {
        this.type = type;
        this.level = level;
        seek = UnityEngine.Random.Range(0, 32767);
    }

    public mapSet(mapType type, int level,int seek)
    {
        this.type = type;
        this.level = level;
        this.seek = seek;
    }
}

[System.Serializable]
public struct typeSet
{
    public mapType type;
    [ColorUsage(true, true)] public Color color;
}

[CreateAssetMenu]
public class mapManager : ScriptableObject
{
    public mapBasicManager baisc;
    public List<mapSet> data;
    public typeSet[] typeSetList;

    private void OnValidate()
    {

        if (typeSetList.Length != (int)mapType.total)
        {
            Array.Resize(ref typeSetList, (int)mapType.total);
        }
    }

    public int getCount(Vector2 vec)
    {
        return baisc.data.FindIndex(n => n.vector == vec);
    }


    public void SaveMapdata()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/mapdata.sav";

        FileStream stream = new FileStream(path, FileMode.Create);

        List<mapSet> newdata = new List<mapSet>(data);

        formatter.Serialize(stream, newdata);
        stream.Close();
    }

    public void LoadMapdata()
    {
        string path = Application.persistentDataPath + "/mapdata.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<mapSet> newdata = new List<mapSet>(formatter.Deserialize(stream) as List<mapSet>);

            data = new List<mapSet>(newdata);
            stream.Close();
        }
        else
        {
            Debug.LogError("Sace file not found in " + path);
        }

    }

}
