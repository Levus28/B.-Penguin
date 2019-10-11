using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidOut : MonoBehaviour
{
    //[SerializeField] 
    //private bool active = true,
    [SerializeField] Transform respawn;
    //[SerializeField] GameObject RespawnPoint;
    void Awake()
    {
        respawn = GetComponent<Transform>();
    }

    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //i have no idea why this isnt working lol, other line is just setting the transform to 0, 0, 0
            //other.transform.position = RespawnPoint.transform.position;
            other.transform.position = new Vector3(0, 0, 0);
        }
    }
}
