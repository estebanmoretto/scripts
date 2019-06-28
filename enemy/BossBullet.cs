using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet :  NormalBullet {

    public delegate void BulletHandler(BossBullet laBullet);
    public event BulletHandler OnDeath = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            OnDeath(this);
        }
    }

}
