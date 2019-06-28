using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFly : FlyBehaviour {

    float force = 100;
    ShipMovent ship;

    public NormalFly(ShipMovent s)
    {
        ship = s;
    }

    public void Fly()
    {
        ship.rb.AddForce(ship.transform.forward * force);
    }

   
}
