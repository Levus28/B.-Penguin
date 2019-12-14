using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputController))]
[RequireComponent(typeof(PlayerMachine))]
public class door : MonoBehaviour
{
    [SerializeField]
    GameObject room1, room2, doorObj;

    [SerializeField]
    Vector3 targetOffset;

    [SerializeField]
    private PlayerInputController input;
    [SerializeField]
    private PlayerMachine player;

    [SerializeField]
    float openSpeed = 5.0f;

    bool isNextToDoor, isOpening;
    Vector3 doorDef, doorOpen;

    public GameObject point1;
    public GameObject point2;

    // Start is called before the first frame update
    void Start()
    {
        doorDef = doorObj.transform.localPosition;
        isOpening = false;
        doorOpen = doorDef + targetOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isNextToDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isNextToDoor = false;
        }
    }

    private void DoorOpen()
    {
        isOpening = true;
        Debug.Log("Open Door");
        player.currentState = PlayerMachine.PlayerStates.OpenDoor;
    }

    // Update is called once per frame
    void Update()
    {
        if (input.Current.UseInput == true && isNextToDoor == true)  
        {
            DoorOpen();
        }

        if (isOpening == true){
            doorObj.transform.localPosition = Vector3.MoveTowards(
            doorObj.transform.localPosition, doorOpen, openSpeed * Time.deltaTime);
        }

        if (doorObj.transform.localPosition == targetOffset)
        {
            isOpening = false;
        }
    }
}
