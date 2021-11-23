using System;
using UnityEngine;

public enum enemyType
{
    Boss1,
    Boss2,
    Enemy1,
    Enemy2,
    Total,
}

public enum enemyMove
{
    Stay,
    Track,
    Forecast,
    Turn,
}

[System.Serializable]
public struct enemyMoveState
{
    public enemyMove move;
    public enemyBullteType attack;
    public float time;
    public float attackPowerScale;
    public float reloadTime;
    public float moveValue;
    public float rotateValue;

}

[System.Serializable]
public struct enemyPrefab
{
    public enemyState prefab;
    [ColorUsage(true, true)] public Color color;

    public float health;
    public float healthPerLevel;
    public float attackPower;
    public float attackPowerPerLevel;
    public float reloadSpeed;
    public float reloadSpeedPerLevel;

    public int experience;
    public int experiencePerLevel;

    public enemyMoveState[] moveStates;

    public float getHealth(int level)
    {
        return health + level * healthPerLevel;
    }

    public float getAttackPower(int level)
    {
        return (attackPower + level * attackPowerPerLevel) / 100f;
    }

    public float getReloadSpeed(int level)
    {
        return (reloadSpeed + level * reloadSpeedPerLevel) / 100f;
    }

    public int getExperience(int level)
    {
        return experience + level * experiencePerLevel;
    }
}


[CreateAssetMenu]
public class enemyManager : ScriptableObject
{
    public playerManager player;
    public enemyBullteManager enemyBullte;
    public gameSceneManager gameScene;

    public enemyPrefab[] enemyList;

    private void OnValidate()
    {
        if (enemyList.Length != (int)enemyType.Total)
        {
            Array.Resize(ref enemyList, (int)enemyType.Total);
        }
    }

    public Vector3 getPlayerPos()
    {
        return player.position;
    }
}
