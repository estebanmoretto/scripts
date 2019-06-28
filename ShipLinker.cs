using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLinker : MonoBehaviour {

    public ShipMovent shipMovement;
    public ShipWeapon shipWeapon;
    public InputController controller;
    
   
    void Start()
    {
        controller.OnUp += shipMovement.NormalFly;
        controller.OnRotate += shipMovement.Rotate;
        controller.OnNitro += shipMovement.NitrousFly;
        controller.OnSpace += shipWeapon.Shoot;
    }

 

}
