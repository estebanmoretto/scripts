using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    Collider _collider;

    public delegate void MeteorHandler(Rock meteor);
    public event MeteorHandler OnDeath = delegate { };

    void Start () {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
	}
	
	
	void Update ()
    {

        ActivateCol();
	}

    void ActivateCol()
    {
        if (transform.parent == null)
        {
            _collider.enabled = true;
        }
    }

}
