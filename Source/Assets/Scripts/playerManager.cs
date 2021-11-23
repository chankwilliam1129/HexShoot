using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData
{
    public int level;
    public int experiencePoint;
    public float healthCounter;
    public int bullteNum;

    public float locationX;
    public float locationZ;


    public int gold;

    public int[] nowItem;

    public playerData(playerData data)
    {
        experiencePoint = data.experiencePoint;
        healthCounter = data.healthCounter;
        bullteNum = data.bullteNum;
        nowItem = data.nowItem;
    }


}

[CreateAssetMenu]
public class playerManager : ScriptableObject
{
    public itemManager itemManager;

    public float health;
    public float healthPerLevel;
    public float attackPower;
    public float attackPowerPerLevel;
    public float reloadSpeed;
    public float reloadSpeedPerLevel;
    public Vector3 position;
    public int[] experience;

    public playerData data;


    public void takeDamage(float damage)
    {
        data.healthCounter -= damage;
    }

    public void getExperience(int exp)
    {
        data.experiencePoint += exp;
        int level;
        for (level = 0; level < 30; level++)  
        {
            if (data.experiencePoint < experience[level]) break;
        }
        if (data.level < level) 
        {
            float temp = data.healthCounter / getHealth();
            data.level = level;
            data.healthCounter = getHealth() * temp;
        }
        
    }


    public int getLevel()
    {
        return data.level;
    }

    public float getHealth()
    {
        return health + healthPerLevel * getLevel() + data.nowItem[(int)itemType.Health] * itemManager.itemList[(int)itemType.Health].value;
    }

    public float getAttackPower()
    {
        return (attackPower + attackPowerPerLevel * getLevel() + data.nowItem[(int)itemType.AttackPower] * itemManager.itemList[(int)itemType.AttackPower].value) / 100f;
    }

    public float getReloadSpeed()
    {
        return (reloadSpeed + reloadSpeedPerLevel * getLevel() + data.nowItem[(int)itemType.ReloadSpeed] * itemManager.itemList[(int)itemType.ReloadSpeed].value) / 100f;
    }

    public void SavePlayer()
    {
        saveSystem.SavePlayer(data);
    }

    public void LoadPlayer()
    {
        data = new playerData(saveSystem.LoadPlayer());
    }

    private void OnValidate()
    {

        if (data.nowItem.Length != (int)itemType.Total)
        {
            Array.Resize(ref data.nowItem, (int)itemType.Total);
        }
    }

    public void reset()
    {
        data.level = 0;
        data.experiencePoint = 0;
        data.healthCounter = getHealth();
        data.locationX = 0;
        data.locationZ = 0;
        data.bullteNum = 0;
        data.gold = 0;
        for (int i = 0; i < (int)itemType.Total; i++) 
        {
            data.nowItem[i] = 0;
        }
    }
}
