﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotation = Vector3.zero;

    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
