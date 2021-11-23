using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]

public class gameSceneManager : ScriptableObject
{
    public enemyManager enemy;
    public itemManager item;

    List<AsyncOperation> sceneToLoad = new List<AsyncOperation>();

    public mapType type;
    public int level;
    public int seek;
    public int gold;

    public int enemyCounter;

    public void gameSceneStart()
    {
        Time.timeScale = 1f;
        sceneToLoad.Add(SceneManager.LoadSceneAsync("SampleGameScene"));
    }
    public void SetupSceneStart()
    {
        Time.timeScale = 1f;
        sceneToLoad.Add(SceneManager.LoadSceneAsync("SetupScene"));
    }

    public void SetupGameScene()
    {
        switch (type)
        {
            case mapType.boss:
                for (int i = 0; i < 4; i++)
                {
                    if ((seek & (2 << 0)) == 0)
                    {
                        createEnemy(enemyType.Enemy1, level + 1);
                    }
                    else
                    {
                        createEnemy(enemyType.Enemy2, level + 1);
                    }
                    enemyCounter++;
                }

                for (int i = 4; i < 7; i++)
                {
                    if ((seek & (2 << 0)) == 0)
                    {
                        createEnemy(enemyType.Boss2, level + 2);
                    }
                    else
                    {
                        createEnemy(enemyType.Boss1, level + 2);
                    }
                    enemyCounter++;
                }
                gold = 40 * (level + 1);
                break;

            case mapType.elite:
                for (int i = 0; i < 5; i++)
                {
                    if ((seek & (2 << i)) == 0)
                    {
                        createEnemy(enemyType.Enemy1, level + 1);
                    }
                    else
                    {
                        createEnemy(enemyType.Enemy2, level + 1);
                    }
                    enemyCounter++;
                }
                if((seek & (2 << 5))==0)
                {
                    createEnemy(enemyType.Boss1, level);
                }
                else
                {
                    createEnemy(enemyType.Boss2, level);
                }
                enemyCounter++;
                gold = 10 * (level + 1);
                break;
            case mapType.normal:
                for (int i = 0; i <= 4; i++)
                {
                    if ((seek & (2 << i)) == 0)
                    {
                        createEnemy(enemyType.Enemy1, level);
                    }
                    else
                    {
                        createEnemy(enemyType.Enemy2, level);
                    }
                    enemyCounter++;
                }
                gold = 5 * (level + 1);
                break;
            default:
                break;
        }
    }

    public void createEnemy(enemyType type ,int level)
    {
        Vector3 pos = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        pos = pos.normalized * Random.Range(20, 35);
        Instantiate(enemy.enemyList[(int)type].prefab, pos, Quaternion.identity).level = level;
    }

    public void Reset()
    {
        type = 0;
        level = 0;
        seek = 0;
        enemyCounter = 0;
    }

}
