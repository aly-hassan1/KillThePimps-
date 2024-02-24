using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    public Weapon weapon;
    private weaponSwiching swiching;
    private PlayerMotor motor;
    private PlayerLook look;

    private void Start()
    {
        

    }
    
    
    // Start is called before the first frame update
    void Awake()
    {

        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        swiching = GetComponentInChildren<weaponSwiching>();    

        onFoot.Jump.performed += ctx => motor.Jump();

        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Sprint();
        onFoot.Shoot.started += ctx => weapon.StartShot();
        onFoot.Shoot.canceled += ctx => weapon.EndShot();
        onFoot.Reload.performed += ctx => weapon.Reload();

    }
    
    

    // Update is called once per frame
    void Update()
    {

        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());

        swiching.SwichWeapon(onFoot.Swicher.ReadValue<float>());

        weapon = GameObject.FindWithTag("Weapon").GetComponent<Weapon>();
    }
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }

}
