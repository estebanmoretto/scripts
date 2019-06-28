using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyedMeteor : MonoBehaviour, IObserver {

    
    public float radius;
    public Transform meteorContainer;
    public MeteorRock asteroid;
    private Pool<MeteorRock> pool;
    private IObservable _meteor;
    private bool canShoot = true;

    void Awake ()
    {
       // _meteor =FindObjectOfType<Meteor>();
      //  _meteor.Subscribe(this);
        pool = new Pool<MeteorRock>(5, GetMeteor, OnReleaseMeteor, OnGetMeteor);  
    }
	
	
	void Update () {
        Spawn();
	}

    private void OnReleaseMeteor(MeteorRock meteor)
    {
        meteor.gameObject.SetActive(false);
        meteor.OnDeath -= pool.ReleaseObject;
    }

    private void OnGetMeteor(MeteorRock meteor)
    {
        meteor.gameObject.SetActive(true);
        meteor.OnDeath += pool.ReleaseObject;
    }

    private MeteorRock GetMeteor()
    {
        var meteor = Instantiate(asteroid);
        meteor.transform.parent = meteorContainer;
        meteor.gameObject.SetActive(false);
        return meteor;
    }

    public IEnumerator FireRate()
    {
        yield return new WaitForSeconds(Random.Range(0.4f, 2f));
        canShoot = true;


    }


    void Spawn()
    {

        if (canShoot)
        {
            var meteor = pool.GetObject();
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-494f, 520f), transform.position.y, transform.position.z);
            meteor.Spawn(pos, transform.rotation);
            canShoot = false;
            StartCoroutine(FireRate());
        }

    }
    private void OnDie()
    {
        _meteor.Unsubscribe(this);
    }
    public void OnNotify(string action)
    {
        if (action == "destroyed")
            Spawn();
    }
}
