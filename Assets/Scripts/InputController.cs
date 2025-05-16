using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    
    [Header("Events")] 
    [SerializeField] private VoidEvent      onLShiftKeyPressed;
    [SerializeField] private VoidEvent      onLShiftKeyReleaseed;
    [SerializeField] private VoidEvent      onRightMouseBtnPressed;
    [SerializeField] private VoidEvent      onRightMouseBtnReleased;
    [SerializeField] private VoidEvent      onLeftMouseBtnPressed;
    [SerializeField] private VoidEvent      onMBtnPressed;
    [SerializeField] private VoidEvent      onFBtnPressed;
    [SerializeField] private VoidEvent      onEBtnPressed;
    
    
    [Header("Variables")]
    [SerializeField] private BoolVariable   rightMouseBtnBeingHeldDown;
    [SerializeField] private FloatVariable  mouseWheelValue;

    [Header("Settings")]
    [SerializeField] private float mouseWheelSensibility = 5f;
    
    
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.F)){
            onFBtnPressed.Raise();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            onLShiftKeyPressed.Raise();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            onLShiftKeyReleaseed.Raise();
        }

        if (Input.GetMouseButtonUp(0))
        {
            onLeftMouseBtnPressed.Raise();
        }

        if (Input.GetMouseButton(1))
        {
            //rightMouseBtnBeingHeldDown.value = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            //onRightMouseBtnPressed.Raise();
        }

        if (Input.GetMouseButtonUp(1))
        {
            //onRightMouseBtnReleased.Raise();    
           // rightMouseBtnBeingHeldDown.value = false;
        }
        
        if(Input.GetKeyDown(KeyCode.E))
        { 
            onEBtnPressed.Raise();
        }
        
        mouseWheelValue.value = mouseWheelSensibility * Input.GetAxis("Mouse ScrollWheel");
        
    }
    
}
