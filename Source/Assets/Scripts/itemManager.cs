using System;
using UnityEngine;
using UnityEngine.VFX;

public enum itemType
{
    Health,
    AttackPower,
    ReloadSpeed,
    HealPerRound,
    HealPerKill,
    ColddownSpeed,
    MultShotRate,
    Total,
}

[System.Serializable]
public struct itemSet
{
    public string name;
    public string comment;
    public float value;
    public int cost;

    [ColorUsage(true, true)] public Color color;
    public VisualEffectAsset effectAsset;
}


[CreateAssetMenu]
public class itemManager : ScriptableObject
{
    public itemSet[] itemList;

    private void OnValidate()
    {
        if (itemList.Length != (int)itemType.Total)
        {
            Array.Resize(ref itemList, (int)itemType.Total);
        }
    }
}
