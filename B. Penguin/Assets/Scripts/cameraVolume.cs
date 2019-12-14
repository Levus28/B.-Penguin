using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraVolume : MonoBehaviour
{
    [SerializeField]
    bool lerpToFOV, lerpToX, lerpToY, lerpToZ, followOnX, followOnZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        LeviCamera leviCamera = collider.gameObject.GetComponentInParent<LeviCamera>();
        if (leviCamera != null)
        {
            Debug.Log("Bigger Gun?");
            leviCamera.followX = followOnX;
            leviCamera.followZ = followOnZ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
