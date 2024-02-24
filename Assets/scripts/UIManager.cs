using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text AmmoText;

    public void UpdateAmmo(int count)
    {
        AmmoText.text = "Ammo: " + count;
        Debug.Log(count);
    }
}
