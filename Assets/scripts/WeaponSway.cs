using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    private PlayerLook look;
    private PlayerMotor player;
    [SerializeField] private float smooth;
    [SerializeField] private float swayMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void SwayWeapon(float mouseXX, float mouseYY)
    {
        float mouseX = mouseXX * swayMultiplier;
        float mouseY = mouseYY * swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
    

    
}
