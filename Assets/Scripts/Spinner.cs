﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float spinnerRate = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,spinnerRate);
    }
}
