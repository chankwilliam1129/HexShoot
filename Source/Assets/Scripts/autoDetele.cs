﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDetele : MonoBehaviour
{
   
    public float lifeTime;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        
    }
}