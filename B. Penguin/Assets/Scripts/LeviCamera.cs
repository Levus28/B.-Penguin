using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeviCamera : MonoBehaviour
{

    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    GameObject character;
    [SerializeField]
    public float cameraHeight, cameraDepth;
    [SerializeField]
    SuperCharacterController controller;

    [SerializeField]
    TextMeshProUGUI tmp;

    [SerializeField]
    int playerHP = 100;

    public float camX, camY, camZ;

    [SerializeField]
    public bool followX, followZ;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //mainCamera.transform.localPosition = new Vector3(character.transform.localPosition.x, cameraHeight, cameraDepth);

        if (followX == true){camX = character.transform.localPosition.x;}
        if (followZ == true){camZ = character.transform.localPosition.z + cameraDepth;}
        else{camZ = cameraDepth;}


        if (controller.currentGround.IsGrounded(true, 0.1f))
        {
            camY = Mathf.MoveTowards (mainCamera.transform.localPosition.y, character.transform.localPosition.y + cameraHeight, 0.5f);
            
        }
        

        mainCamera.transform.localPosition = new Vector3 
        (camX, camY, camZ);

        //tmp.text = "Health: " + playerHP.ToString();
        
    }
}
