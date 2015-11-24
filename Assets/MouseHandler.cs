using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MouseHandler : MonoBehaviour {

    public Transform dropPos;
    public BoxCollider2D dropper;
    public Text textBox;

    public bool touched;
    public bool released;
    public bool active;
    public bool create;


    public Vector3 modVector = new Vector3(0, 3f, 0);
	
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            touched = true;   
        }

        if (Input.GetMouseButtonUp(0)) {
            released = true;
        }

	}

    void FixedUpdate()
    {

        if (touched && !active)
        {
            Debug.Log("enabling");
            dropPos.transform.position -= modVector;
            touched = false;
            active = true;
        }
        if (released && active)
        {
            Debug.Log("disabling");
            dropPos.transform.position += modVector;
            released = false;
            active = false;
        }
    }
}
