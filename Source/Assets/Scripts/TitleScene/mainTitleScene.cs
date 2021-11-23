using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainTitleScene : MonoBehaviour
{

    List<AsyncOperation> sceneToLoad = new List<AsyncOperation>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        sceneToLoad.Add(SceneManager.LoadSceneAsync("SampleGameScene"));
    }
}
