using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Meteor : MonoBehaviour, IObservable {

    public Rigidbody rb;
    public float force;
    public Vector3 speed;
    
    
    public float deathTime = 0f;
    public float aliveTime = 0f;
    public Collision col;
    public delegate void MeteorHandler(Meteor meteor);
    public event MeteorHandler OnDeath = delegate { };

    public List<IObserver> _allObservers = new List<IObserver>();

    public void Subscribe(IObserver observer)
    {
        if (!_allObservers.Contains(observer))
            _allObservers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        if (_allObservers.Contains(observer))
            _allObservers.Remove(observer);
    }
    void Start () {
		
	}

    private void OnEnable()
    {
        transform.forward = new Vector3(0,0,-180);
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.forward*100f,ForceMode.Impulse);
    }

    void FixedUpdate ()
    {
      //  rb.angularVelocity = Random.value * speed;
	}

    private void Update()
    {
        CheckDead();
        // OnCollisionEnter(col);
        if (Input.GetKeyDown(KeyCode.P))
        {
            foreach (IObserver o in _allObservers)
            {
                Debug.Log("entro al for");
                o.OnNotify("destroyed");
            }

        }
    }

    public void Spawn(Vector3 pos, Vector3 forw)
    {
        transform.position = pos;
        transform.forward = forw;
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
            EventManager.Instance.FireEvent(EventManager.EventID.MeteorDestroy, gameObject);
           
           /* for (int i = _allObservers.Count - 1; i >= 0; i--)
            {
                _allObservers[i].OnNotify("destroyed");
            }*/
            foreach (IObserver o in _allObservers)
            {

                o.OnNotify("destroyed");
            }
        }
        if (collision.gameObject.layer == 8)
        {
            OnDeath(this);
            EventManager.Instance.FireEvent(EventManager.EventID.MeteorDestroy, gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer ==10)
        {
            EventManager.Instance.FireEvent(EventManager.EventID.MeteorDestroy, gameObject);
            foreach (IObserver o in _allObservers)
            {

                o.OnNotify("destroyed");
            }
            OnDeath(this);
        }
        if (other.gameObject.layer == 8)
        {
            foreach (IObserver o in _allObservers)
            {

                o.OnNotify("destroyed");
            }
            OnDeath(this);
            EventManager.Instance.FireEvent(EventManager.EventID.MeteorDestroy, gameObject);
        }
    }





}
