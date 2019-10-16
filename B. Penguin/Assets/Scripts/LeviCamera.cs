using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviCamera : MonoBehaviour
{

    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    GameObject character;
    [SerializeField]
    float cameraHeight, cameraDepth;
    [SerializeField]
    SuperCharacterController controller;

    float camX, camY, camZ;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //mainCamera.transform.localPosition = new Vector3(character.transform.localPosition.x, cameraHeight, cameraDepth);

        camX = character.transform.localPosition.x;
        if (controller.currentGround.IsGrounded(true, 0.1f))
        {
            camY = Mathf.MoveTowards (mainCamera.transform.localPosition.y, character.transform.localPosition.y + cameraHeight, 0.5f);
            
        }
        camZ = cameraDepth;

        mainCamera.transform.localPosition = new Vector3 
        (camX, camY, camZ);

        
    }
}
