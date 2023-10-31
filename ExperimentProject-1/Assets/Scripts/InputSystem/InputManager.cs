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

    private PlayerControl player;
    private Vector2 moveInput;

    private void Awake()
    {
        if (instance != null)
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
        player = gameObject.GetComponent<PlayerControl>();
    }

    private void OnEnable()
    {
        inputAction.GameControl.Jumping.started += ctx => jumping = true;
        inputAction.GameControl.Pausing.started += ctx => pausing = true;
        inputAction.GameControl.Spirinting.started += ctx => sprinting = true;
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    private void Update()
    {
        
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
