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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.localPosition = new Vector3(character.transform.localPosition.x, cameraHeight, cameraDepth);
    }
}
