using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetController : MonoBehaviour
{
    public Texture2D palette;
    public Material paletteMat;

    void Start()
    {
        
    }

    void Update()
    {
        paletteMat.SetTexture("_MainTex1", palette);
    }
}
