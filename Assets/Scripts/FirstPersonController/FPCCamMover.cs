using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public abstract class FPCCamMover : MonoBehaviour
{

    [SerializeField] private Transform fpsCam;
    [SerializeField] private float  mouseSensitivity = 100f;
    [SerializeField] private Vector2 verticalClampLimit;
    
    protected Transform tr;
    private float xRotation = 0f;
    
    protected virtual void Start()
    {
        this.tr = transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, verticalClampLimit.x, verticalClampLimit.y);

        fpsCam.localRotation = Quaternion.Euler(xRotation, 0, 0);
        this.tr.Rotate(Vector3.up * mouseX);
    }
}
