using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightHelper : MonoBehaviour
{
    //public Vector3 FocalPoint;
    public GameObject Spotlight;
    public float LightOnTime = 10.0f;
    public float RecoveryTime = 2.0f;
    public bool spotlightIsActive = false;

    void Start()
    {
        StartCoroutine(LightSwitch(LightOnTime, RecoveryTime));
    }

    void LightsOff()
    {
        StopCoroutine("LightSwitch");
        spotlightIsActive = false;
        Spotlight.SetActive(false);
    }

    IEnumerator LightSwitch(float onTime, float waitTime )
    {
        spotlightIsActive = true;
        while(true)
        {
            Spotlight.SetActive(true);
            yield return new WaitForSeconds(onTime);
            Spotlight.SetActive(false);
            yield return new WaitForSeconds(waitTime);
        }
    }

    /*IEnumerator RotateLights()
    {

    }*/
}