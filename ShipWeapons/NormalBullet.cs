using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour {

    public delegate void BulletHandler(NormalBullet laBullet);

    public float speed = 50f;
    public float deathTime = 5f;
    public float aliveTime = 0f;

    public event BulletHandler OnDeath = delegate { };

    public void Spawn(Vector3 position, Quaternion rot)
    {
        transform.position = position;
        transform.rotation = rot;

        aliveTime = 0;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        CheckDead();
    }

    public void CheckDead()
    {
        aliveTime += Time.deltaTime;

        if (aliveTime >= deathTime)
        {
            OnDeath(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 8)
            OnDeath(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 8)
        {
            OnDeath(this);
        }
    }
}