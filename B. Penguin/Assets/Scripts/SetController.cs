using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SetController : MonoBehaviour
{
    public Texture2D palette;
    public Material paletteMat;
    public Material paletteCenterStage;

    void Start()
    {
        
    }

    void Update()
    {
        paletteMat.SetTexture("_MainTex1", palette);
        paletteCenterStage.SetTexture("_MainTex1", palette);
    }
}
