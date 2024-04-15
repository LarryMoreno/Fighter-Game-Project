using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    private CharacterAnimation player_Anim;
    private Rigidbody rb;
    [SerializeField] float movementSpeed  = 5f;
    //[SerializeField] float z_Speed = 1.5f;
    //[SerializeField] float jumpForce  = 5f;
    [SerializeField] float rotation_Y = -90f;
    //[SerializeField] float rotation_Speed = 15f;
    
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

   void Start()
    {
        rb = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
        
        int LP1 = LayerMask.NameToLayer("Player");
        int LayerPlayer2 = LayerMask.NameToLayer("Player2");
       
        if(!IsOwner) 
        { 
            gameObject.layer = LayerPlayer2;
        }
        else 
        {
            gameObject.layer = LP1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsOwner) return;
        
        float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, 0, 0);

        /*if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }*/

        RotatePlayer();
        AnimatePlayerWalk();


    }

    void FixedUpdate()
    {
        DetectMovement();
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    void DetectMovement(){
        /*rb.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (movementSpeed),
            rb.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (z_Speed));*/
         rb.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-movementSpeed),
            0,
            0);
    }

    void RotatePlayer() {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0 )
        {
            transform.rotation = Quaternion.Euler(0f, rotation_Y, 0f);
            
        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f);
        }
    }

    void AnimatePlayerWalk(){
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0)
        {
            player_Anim.Walk(true);
        }
        else
        {
            player_Anim.Walk(false);
        }
 
    }
}
