using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipLife : MonoBehaviour, IObservable {

    public int life = 100;
    int life2 = 100;
    private List<IObserver> _allObservers = new List<IObserver>();
    public Text text;
    

    void Start () {
		
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
    // Update is called once per frame
    void Update () {
        ChekDead();
        CheckLife();

      
    }
    void ChekDead()
    {
        if (life <= 0)
            SceneManager.LoadScene("Lose");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            life -= 10;

        }
        if (collision.gameObject.layer == 11)
        {
            life -= 5;
        }
        if (collision.gameObject.layer == 12)
        {
            life -= 10;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
            life -= 10;
        }
    }
    void CheckLife()
    {
        /*  if (life != life2)
          {
              foreach (IObserver o in _allObservers)
              {

                  o.OnNotify("takeDamage");
              }
              life2 = life;
          }*/
        text.text = "Life" + life;
    }
  
}
