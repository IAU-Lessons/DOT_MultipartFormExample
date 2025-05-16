using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : FPCCamMover
{

    [Header("Events")] 
    [SerializeField]
    private VoidEvent onLShiftKeyPressed;
    [SerializeField] 
    private VoidEvent onLShiftKeyReleaseed;
    [SerializeField] private VoidEvent onEBtnInteracted;
    
    
    [Header("Variables")] 
    [SerializeField]
    private BoolVariable playerMoveStatus;
    [SerializeField]
    private Vector3Variable playerPosition;

    [Header("Refs")] 
    [SerializeField] private FloatReference staminaValue;
    
    [Header("Settings")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private bool canJump = true;
    [SerializeField] private float jumpForce = 10f;

    protected CharacterController _controller;
    protected Vector3 velocity;
    private float runtimeSpeed;
    
    private Transform sitTransform;
    
    protected override void Start()
    {
        base.Start();
        this._controller = GetComponent<CharacterController>();
        this.runtimeSpeed = speed;
    }

    private void OnEnable()
    {
        onLShiftKeyPressed.AddListener(LShiftKeyPressed);
        onLShiftKeyReleaseed.AddListener(LShiftReleased);  
        onEBtnInteracted.AddListener(EBtnInteracted);
        
        
    }

    private void OnDisable()
    {
        onLShiftKeyPressed.RemoveListener(LShiftKeyPressed);
        onLShiftKeyReleaseed.RemoveListener(LShiftReleased);
        onEBtnInteracted.RemoveListener(EBtnInteracted);
    }

    protected override void Update()
    {
        base.Update();
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        
        if (_controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;
        
        Vector3 move = base.tr.right * moveX + base.tr.forward * moveZ;
        
        this._controller.Move(move * runtimeSpeed * Time.deltaTime);
        
        if (_controller.velocity != Vector3.zero)
            playerMoveStatus.value = true;
        else
            playerMoveStatus.value = false;
        
        if (canJump)
            if (Input.GetButtonDown("Jump"))
                velocity.y = Mathf.Sqrt(jumpForce * (-2) * gravity);
        
        velocity.y += gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);
        playerPosition.value = this.tr.position;
    }

    private void LShiftKeyPressed()
    {
        return;
        if (staminaValue.Value <= 0)
        {
            runtimeSpeed = speed * 0.7f;
        }
        else
        {
            runtimeSpeed = speed * 2;
        }
    }

    private void LShiftReleased()
    {
        runtimeSpeed = speed;
    }

    private void EBtnInteracted()
    {
        
    }
    
}
