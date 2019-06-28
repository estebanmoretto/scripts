using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour {

    public GameObject boss;
    public Transform sp;
    float counter;
    bool spawn = true;

	void Start () {
		
	}
	
	
	void Update () {
        counter += Time.deltaTime;
        if (counter >= 10 && spawn == true)
        {
            Spawn();
            spawn = false;
        }
	}

    void Spawn()
    {
        Instantiate(boss, sp.transform);
    }
}
