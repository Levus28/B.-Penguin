using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awfulCharacterController : MonoBehaviour
{

    
    
    [SerializeField]
    float playerHeight, gravitySpeed, gravityDelta, jumpHeight, jumpSpeed, movementVelocity;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    private AnimationCurve velocityCurve, speedCurve;

    float defaultJumpSpeed;
    bool isGrounded, jumped;

    
    

    

    // Start is called before the first frame update
    void Start()
    {
        defaultJumpSpeed = jumpSpeed;
        jumpSpeed = 0;
    }

//transform.position.y - gravitySpeed * Time.deltaTime

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.localPosition, Vector3.down, out hit, 1000, groundLayer))
        {
            transform.localPosition = new Vector3
            (transform.position.x, 
            Mathf.MoveTowards(transform.position.y, hit.point.y + playerHeight, gravityDelta), transform.position.z);
        }


        if(Input.GetKey("a"))
        {
            Debug.Log("a");
            transform.localPosition = new Vector3
            (
                Mathf.MoveTowards(
                    transform.localPosition.x, transform.localPosition.x - movementVelocity, movementVelocity * Time.deltaTime),
                transform.localPosition.y,
                transform.localPosition.z
            );
        }

        if(Input.GetKey("d"))
        {
            Debug.Log("d");
            transform.localPosition = new Vector3
            (
                Mathf.MoveTowards(
                    transform.localPosition.x, transform.localPosition.x + movementVelocity, movementVelocity * Time.deltaTime),
                transform.localPosition.y,
                transform.localPosition.z
            );
        }
        
        //For checking if the player is grounded
        if (hit.distance <= playerHeight)
        {isGrounded = true;}        
        if (hit.distance > playerHeight) 
        {isGrounded = false;}

        if (Input.GetKeyDown("space"))
        {
            //For when the player is not in the air
            if (isGrounded == true)
            {
                
                jumped = true;

                transform.localPosition = new Vector3(
                    transform.position.x,
                    Mathf.MoveTowards(transform.localPosition.y, transform.localPosition.y + jumpHeight, 1), 
                    transform.position.z);
            }

            //For when the player is in the air
            if (!isGrounded)
            {
                Debug.Log("Space While Ungrounded");
            }

        }

        float scaleFactor = 1/2;
        
        if (jumped == true)
        {jumpSpeed = velocityCurve.Evaluate(1 - scaleFactor);}

        Debug.Log(jumpSpeed);
        Debug.Log(jumped);
    }
}
