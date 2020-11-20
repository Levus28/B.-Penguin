using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightHelper : MonoBehaviour
{
    public Vector3 FocalPoint;
    public GameObject Spotlight;

    //public float Timer = 0f;
    public float DisableTimer = 15f;
    public float DisableRecoveryTimer = 2f;
    public float RotateTimer = 5f;
    public float RotateRecoveryTimer = 2f;
    public float MoveTimer = 10f;

    private float CachedDisableTimer;
    private float CachedDisableRecoveryTimer;
    private float CachedRotateTimer;
    private float CachedRotateRecoveryTimer;
    //private float CachedTimer;

    public Vector3 rotation = Vector3.zero;    

    void Start()
    {
        CachedDisableTimer = DisableTimer;
        CachedDisableRecoveryTimer = DisableRecoveryTimer;
        CachedRotateTimer = RotateTimer;
        //CachedTimer = Timer;
    }

    void Update()
    {
        //Timer += Time.deltaTime;
        DisableTimer -= Time.deltaTime;
        RotateTimer -= Time.deltaTime;
        MoveTimer -= Time.deltaTime;

        if (DisableTimer == 0)
        {
            Spotlight.SetActive(false);
            DisableRecoveryTimer -= Time.deltaTime;
            
            if(DisableRecoveryTimer == 0)
            {
                Spotlight.SetActive(true);
                DisableRecoveryTimer = CachedDisableRecoveryTimer;
                DisableTimer = CachedDisableTimer;
            }
        }

        if (RotateTimer == 0)
        {
            transform.Rotate(rotation * Time.deltaTime);
            RotateRecoveryTimer -= Time.deltaTime;

            if (RotateRecoveryTimer == 0)
            {
                //stop rotating, reset
                RotateRecoveryTimer = CachedRotateRecoveryTimer;
            }
        }
    }
}
