using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour {

    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float bottomConstraint = Screen.height;
    float topConstraint = Screen.height;
    float buffer = 1.0f;
    Camera cam;
    float distanceZ;


	void Start () {
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);
        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f,0.0f,distanceZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width,0.0f,distanceZ)).x;
        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f,0.0f,distanceZ)).z;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f,Screen.height,distanceZ)).z;


    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position.x < leftConstraint - buffer)
            transform.position = new Vector3(rightConstraint - 0.10f, transform.position.y, transform.position.z);

        if (transform.position.x > rightConstraint + buffer)
            transform.position = new Vector3(leftConstraint + 0.10f, transform.position.y,transform.position.z);

        if (transform.position.z < bottomConstraint )
            transform.position = new Vector3(transform.position.x,transform.position.y, topConstraint );

        if (transform.position.z > topConstraint + buffer)
            transform.position = new Vector3(transform.position.x,transform.position.y, bottomConstraint - buffer);
	}
}
