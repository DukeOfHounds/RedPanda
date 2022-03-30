using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    private PlayerInput pI;
    public CharacterController controller;
    
    Vector3 velocity;
    float gravity = -9.81f;
    //float horizontalMovement = 0;
    //float verticalMovement = 0;
    public float jumpForce = 7;

    //bool isGrounded;d
    //bool isMoving = false;

    //float iTimer;
    //float iTimerMax = 2;
    //bool useTimer;


    private void Awake()
    {
        PlayerInput.JumpEvent += HandleJump;//

    }

    private void Start()
    {
        pI = this.gameObject.GetComponent<PlayerInput>();
        controller = this.gameObject.GetComponent<CharacterController>();
        pI.pD.currentMovement = gameObject.transform.position;
    }


    void Update()
    {
        HandleMovement();
        //Debug.Log(speed);
    }
    
    private void HandleMovement()
    {
        Vector3 rawMovement = new Vector3(-pI.GetHorizontalMovement() *.75f, 0.0f, -pI.GetVerticalMovement());
        pI.pD.currentMovement = Vector3.MoveTowards(pI.pD.currentMovement, rawMovement, pI.pD.inertiaVar * Time.deltaTime);
        Vector3 finalMovement = transform.TransformVector(pI.pD.currentMovement);
        controller.Move(finalMovement * pI.pD.moveSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void HandleJump(object sender, EventArgs e)
    {
        Debug.Log("Jump");
        //if(velocity.y)
        velocity.y = jumpForce;
        controller.Move(velocity * Time.deltaTime);
    }




}