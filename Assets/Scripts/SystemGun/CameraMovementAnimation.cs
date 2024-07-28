using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementAnimation : MonoBehaviour
{
    private IWeaponReact weaponReact;
    
    void Start()
    {
        weaponReact = GetComponent<IWeaponReact>();
    }

    
    void Update()
    {
        weaponReact.ReactOnPrimaryAttack();
        weaponReact.RegularAttack();
    }
}
