using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovent : MonoBehaviour {

    public Rigidbody rb;

    public float force = 10f;
    public float torque = 10f;
    
    FlyBehaviour myCurrentStrategyNormal;
    FlyBehaviour myCurrentStrategyNitro;
    

    private void Awake()
    {
        myCurrentStrategyNormal = new NormalFly(this);
        myCurrentStrategyNitro = new NitrousFly(this);
    }

    public void Rotate(Vector3 nextdir)
    {

        rb.AddTorque(torque * nextdir);

    }

    public void NormalFly()
    {

        myCurrentStrategyNormal.Fly();
    }

    public void NitrousFly()
    {
       
        myCurrentStrategyNitro.Fly();
    }    

}
