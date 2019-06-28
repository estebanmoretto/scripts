using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public delegate void InputHandler(Vector3 dir);
    public delegate void InputHandlerNoParameters();

    float hInput;
   

    public event InputHandlerNoParameters OnUp = delegate { };
    public event InputHandlerNoParameters OnNitro = delegate { };
    public event InputHandlerNoParameters OnSpace = delegate { };

    public InputHandler OnRotate = delegate { };
   

    private void Update()
    {

        hInput = Input.GetAxis("Horizontal");
       
        Vector3 rot = new Vector3(0,hInput,0);

        if (Input.GetKey(KeyCode.W))
            OnUp();

        if (Input.GetKey(KeyCode.LeftShift))
            OnNitro();

        if (hInput != 0)
            OnRotate(rot);

        if (Input.GetKey(KeyCode.Space))
            OnSpace();

    }
}
