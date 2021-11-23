using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameTimeManager : MonoBehaviour
{
    public float timeCounter;
    public Text Text;
    public string displayText;
    void Start()
    {
        timeCounter = 0.0f;
    }
    void Update()
    {
        timeCounter += Time.deltaTime;
        Text.text = displayText + timeCounter.ToString("F2");
    }
}
