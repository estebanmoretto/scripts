using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour, IObservable {

    public Meteor asteroid;
    public Transform meteorContainer;
    private bool canShoot = true;
    private Pool<Meteor> pool;
    private List<IObserver> _allObservers = new List<IObserver>();

    void Start () {
        pool = new Pool<Meteor>(5, GetMeteor, OnReleaseMeteor, OnGetMeteor);
    }
	
	
	void Update () {
        Spawn();
	}

    private void OnReleaseMeteor(Meteor meteor)
    {
        meteor.gameObject.SetActive(false);
        meteor.OnDeath -= pool.ReleaseObject;
    }

    private void OnGetMeteor(Meteor meteor)
    {
        meteor.gameObject.SetActive(true);
        meteor.OnDeath += pool.ReleaseObject;
    }

    private Meteor GetMeteor()
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
            meteor.Spawn(pos, transform.forward);
            canShoot = false;
            StartCoroutine(FireRate());
            foreach (IObserver o in _allObservers)
            {
               // Debug.Log("entro al for del spawn");
                o.OnNotify("spawn");
            }
        }
    }

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
}
