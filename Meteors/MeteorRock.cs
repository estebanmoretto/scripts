using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRock : MonoBehaviour {

    public float deathTime = 0f;
    public float aliveTime = 0f;

    public delegate void MeteorHandler(MeteorRock meteor);
    public event MeteorHandler OnDeath = delegate { };
   

    void Start () {
        
       
	}
	
	
	void Update () {
        CheckDead();
	}
    public void Spawn(Vector3 pos , Quaternion rot)
    {
        transform.position = pos;
        transform.rotation = rot;
        aliveTime = 0f;
    }
    private void CheckDead()
    {
        aliveTime += Time.deltaTime;

        if (aliveTime >= deathTime)
        {
            OnDeath(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            
            OnDeath(this);
            EventManager.Instance.FireEvent(EventManager.EventID.RockDestroy, gameObject);

         
        }
        if (collision.gameObject.layer == 8)
        {
            OnDeath(this);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            EventManager.Instance.FireEvent(EventManager.EventID.RockDestroy, gameObject);
            
            OnDeath(this);
        }
        if (other.gameObject.layer == 8)
        {
           
            OnDeath(this);
            EventManager.Instance.FireEvent(EventManager.EventID.RockDestroy, gameObject);
        }
    }


}
