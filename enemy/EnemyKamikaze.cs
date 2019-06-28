using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikaze : EnemyBase {

    public Transform ship;
    public LineOfSight los;
    public float smoothingFactor = 3;
    public float range;
    private bool savePos;
    private bool posSaved;
    private Vector3 savedPos;
    public float rotMulti;
    Rigidbody rb;

    void Awake () {
        range = Mathf.Clamp(range, 0.1f, 5552);
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
    }
  
	void Update () {

            
        if (los.IsInSight(ship) && posSaved == false)
        {
            SaveEnemyPosition();
            Debug.Log("1");
            posSaved = true;

        }
        if (los.IsInSight(ship) && posSaved == true)
        {
            ActivateChild();
            Debug.Log("2");
        }
        if(!los.IsInSight(ship))
        {
            Movement();
            posSaved = false;
            Debug.Log("3");

        }
            

	}

    void Movement()
    {
        //  transform.forward = ship.transform.position - transform.position;
        speed = 50;
       
        var directionToTarget = ship.transform.position - transform.position;
        directionToTarget.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionToTarget, Vector3.up), Time.deltaTime * smoothingFactor);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void ActivateChild()
    {

        //transform.GetChild(0).GetComponent<rot>().enabled = !transform.GetChild(0).GetComponent<rot>().enabled;
         transform.GetChild(0).gameObject.transform.Rotate(new Vector3(0, 0, 10));
       
        speed = 100;
       
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(savedPos, Vector3.up), Time.deltaTime * smoothingFactor);
        transform.position += transform.forward * speed * Time.deltaTime;
       
  
        
    }
    void SaveEnemyPosition()
    {
        savedPos = ship.transform.position - transform.position;
        
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.layer == 8)
            Destroy(this.gameObject);*/
    }

}
