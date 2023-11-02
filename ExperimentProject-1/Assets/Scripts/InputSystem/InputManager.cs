using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static bool
        jumping,
        sprinting,
        interacting,
        pausing;


    public static float
        moveX,
        moveY,
        mouseX,
        mouseY,
        sensitivityX,
        sensitivityY;

    public static InputManager instance;
    public static InputSystem inputAction;
    
    private Vector2 moveInput;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        Init();
    }

    //待修改
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        inputAction.GameControl.Jumping.started += ctx => jumping = true;
        // inputAction.GameControl.Pausing.started += ctx => pausing = true;
        // inputAction.GameControl.Pausing.canceled += ctx => pausing = false;
        // inputAction.GameControl.Spirinting.started += ctx => sprinting = true;
        // inputAction.GameControl.Spirinting.canceled += ctx => sprinting = false;
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    private void Update()
    {
        if (Mouse.current != null)
        {
            mouseX = Mouse.current.delta.x.ReadValue();
            mouseY = Mouse.current.delta.y.ReadValue();
        }

        moveInput = inputAction.GameControl.Movement.ReadValue<Vector2>();
        moveX = moveInput.x;
        moveY = moveInput.y;

        sprinting = inputAction.GameControl.Spirinting.ReadValue<float>() > 0;
        interacting = inputAction.GameControl.Interacting.ReadValue<float>() > 0;
        pausing = inputAction.GameControl.Pausing.ReadValue<float>() > 0;
        
        Debug.Log(mouseX);
        Debug.Log(mouseY);
        Debug.Log(moveX);
        Debug.Log(moveY);
    }

    private void Init()
    {
        if (inputAction == null)
        {
            inputAction = new InputSystem();
            inputAction.Enable();
        }
    }
}
