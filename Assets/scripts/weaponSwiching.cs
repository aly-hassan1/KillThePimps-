using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class weaponSwiching : MonoBehaviour
{
    public int selectedWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }
    
    // Update is called once per frame
    void Update()
    {
        

    }
    public void SwichWeapon(float input)
    {
        int previousSelectedWeapon = selectedWeapon;
        if (input > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }
        if (input < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

    }
    public void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
