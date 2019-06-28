using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour, IObserver {

    public Text text;
    private IObservable _meteor;
    private bool notifyed=false;
    bool meteorNotify = false;
    private IObservable _spawner;
    private int points=0;

    void Awake()
    {
        _spawner = FindObjectOfType<MeteorSpawner>();
        _spawner.Subscribe(this);
       

    }
    private void OnDie()
    {
        _meteor.Unsubscribe(this);
    }

    void Update()
    {
        FindMeteor();
        MeteorDestroyed();
    }
    public void OnNotify(string action)
    {
        if (action == "spawn")
            notifyed = true;
        if (action == "destroyed")
            meteorNotify = true;
        
    }
    void MeteorDestroyed()
    {
        if (meteorNotify == true)
        {
            points += 10;
            text.text = "score: " + points;
          //  Debug.Log("destroyed");
            meteorNotify = false;
        }
    }
   
    void FindMeteor()
    {
         _meteor = FindObjectOfType<Meteor>();
         _meteor.Subscribe(this);
      
        
    }
}
