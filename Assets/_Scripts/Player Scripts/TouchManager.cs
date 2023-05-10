using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class touchManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions.FindAction("TouchPress");
        touchPositionAction = playerInput.actions.FindAction("TouchPosition");
    }

    private void Update()
    {
        
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }
    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
    }
    private void TouchPressed(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();

    }
}
