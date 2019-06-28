using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot : MonoBehaviour {

    public Vector3 rota;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rota * Random.value);
	}
}
