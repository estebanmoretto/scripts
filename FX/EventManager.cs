using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager Instance;
    public delegate void DispatchEvent(GameObject sender);

    private DispatchEvent[] _events;

    void Start()
    {
        Instance = this;
        _events = new DispatchEvent[(int)EventID.None];

    }
    public void Unsubscrive(EventID id, DispatchEvent function)
    {
        if (id != EventID.None) _events[(int)id] -= function;
    }

    public void Subscrive(EventID id, DispatchEvent function)
    {
        if (id != EventID.None) _events[(int)id] += function;
    }

    public void FireEvent(EventID id, GameObject go)
    {
        if ((int)id <= (int)EventID.None)
            _events[(int)id](go);
    }

    public enum EventID
    {
        MeteorDestroy,
        ShootEffect,
        RockDestroy,
        None
    }
}

