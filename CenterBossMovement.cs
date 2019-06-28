using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterBossMovement : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 12)
            Destroy(this.gameObject);

    }
}
