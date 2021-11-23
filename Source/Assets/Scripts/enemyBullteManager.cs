using System;
using UnityEngine;

public enum enemyBullteType
{
    Tracking,
    Fireball,
    Normal,
    Total,
}


[CreateAssetMenu]
public class enemyBullteManager : ScriptableObject
{
    public EnemyBullteState[] enemyBullteList;

    private void OnValidate()
    {
        if (enemyBullteList.Length != (int)enemyBullteType.Total)
        {
            Array.Resize(ref enemyBullteList, (int)enemyBullteType.Total);
        }
    }
}
