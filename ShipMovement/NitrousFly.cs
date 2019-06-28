using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitrousFly :  FlyBehaviour {

    float force = 200;
    ShipMovent ship;

    public NitrousFly(ShipMovent s)
    {
        ship = s;
    }
    public void Fly()
    {
       // ship.Move(force);
        ship.rb.AddForce(ship.transform.forward * force);
    }
}
