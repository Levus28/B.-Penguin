using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBackAndForth : MonoBehaviour
{
    public Vector3 m_from = new Vector3(0.0f, 5.0f, 0.0f);
    public Vector3 m_to = new Vector3(0.0f, -5.0f, 0.0f);
    public float m_frequency = 1.0f;
    
    void Update() 
    {
        Quaternion from = Quaternion.Euler(this.m_from);
        Quaternion to = Quaternion.Euler(this.m_to);
    
        float lerp = 0.5F * (1.0F + Mathf.Sin(Mathf.PI * Time.deltaTime * this.m_frequency));
        this.transform.localRotation = Quaternion.Lerp(from, to, lerp);
    }
}
