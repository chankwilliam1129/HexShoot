using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager: MonoBehaviour
{
    public GameObject pauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !pauseMenuUI.activeSelf)
        {
            pauseMenuUI.SetActive(true);
        }
    }

}
