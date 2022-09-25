using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public event Action OnJump;

    public Vector2 MoveDirection { get; private set; }
    public bool Sprinting { get; private set; }

    public bool JumpWasPressedThisFrame { get; private set; }
    public bool JumpIsPressed { get; private set; }
    private bool prevJump;

    public Vector2 Position { get; private set; }
    public Vector2 Delta { get; private set; }

    public bool Shoot { get; private set; }
    public bool Aim { get; private set; }

    private PlayerInput input;

    private void Awake()
    {
        input = new PlayerInput();
        InitializeMovementInput();
        InitializeLookInput();
        InitializeOtherInput();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    public void InitializeMovementInput()
    {
        input.PlayerControls.Move.started += HandleMoveChanged;
        input.PlayerControls.Move.performed += HandleMoveChanged;
        input.PlayerControls.Move.canceled += HandleMoveChanged;

        input.PlayerControls.Sprint.started += HandleSprintChanged;
        input.PlayerControls.Sprint.performed += HandleSprintChanged;
        input.PlayerControls.Sprint.canceled += HandleSprintChanged;

        input.PlayerControls.Jump.started += HandleJumpChanged;
        input.PlayerControls.Jump.performed += HandleJumpChanged;
        input.PlayerControls.Jump.canceled += HandleJumpChanged;
    }

    public void InitializeLookInput()
    {
        input.PlayerControls.Look.started += HandleLookChanged;
        input.PlayerControls.Look.performed += HandleLookChanged;
        input.PlayerControls.Look.canceled += HandleLookChanged;
    }

    public void InitializeOtherInput()
    {
        input.PlayerControls.Shoot.started += HandleShootChanged;
        input.PlayerControls.Shoot.performed += HandleShootChanged;
        input.PlayerControls.Shoot.canceled += HandleShootChanged;

        input.PlayerControls.Aim.started += HandleAimChanged;
        input.PlayerControls.Aim.performed += HandleAimChanged;
        input.PlayerControls.Aim.canceled += HandleAimChanged;
    }

    private void HandleMoveChanged(InputAction.CallbackContext context)
    {
        MoveDirection = context.ReadValue<Vector2>();
    }

    private void HandleSprintChanged(InputAction.CallbackContext context)
    {
        Sprinting = context.ReadValue<float>() == 1;
    }

    private void HandleJumpChanged(InputAction.CallbackContext context)
    {
        JumpIsPressed = context.ReadValue<float>() == 1;
        JumpWasPressedThisFrame = !prevJump && JumpIsPressed;
        prevJump = JumpIsPressed;

        if (JumpWasPressedThisFrame)
            OnJump?.Invoke();
    }

    private void HandleLookChanged(InputAction.CallbackContext context)
    {
        Position = Mouse.current.position.ReadValue();
        Delta = Mouse.current.delta.ReadValue();
    }

    private void HandleShootChanged(InputAction.CallbackContext context)
    {
        Shoot = context.ReadValue<float>() == 1;
    }

    private void HandleAimChanged(InputAction.CallbackContext context)
    {
        Aim = context.ReadValue<float>() == 1;
    }
}