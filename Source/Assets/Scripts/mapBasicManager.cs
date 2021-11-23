using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct mapBasic
{
    public string name;
    public Vector2 vector;
    public mapType type;
    public int level;

    public mapBasic(Vector2 vector ,mapType type, int level)
    {
        name = vector.x.ToString("00")+","+ vector.y.ToString("00"); 
        this.vector = vector;
        this.type = type;
        this.level = level;
    }
}

[CreateAssetMenu]
public class mapBasicManager : ScriptableObject
{
    public List<mapBasic> data;
}
