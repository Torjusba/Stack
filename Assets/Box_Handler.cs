using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Box_Handler : MonoBehaviour {

    public Canvas canvas;

    void Start () {
        GlobalVariables.readyForSpawn = false;
        GlobalVariables.restarted = false;
	}

    public bool counted = false;
    void OnCollisionEnter2D()
    {
        GlobalVariables.readyForSpawn = true;
        Debug.Log("collided");
        //When it collides for the first time
        if (!counted)
        {
            GlobalVariables.score++;
            counted = true;
        }

        Vector3 camPos = Camera.main.transform.position;
        if (Camera.main.GetComponent<CameraHandler>().targetY < transform.position.y)
        {
            Debug.Log("adjusted");
            Camera.main.GetComponent<CameraHandler>().targetY = transform.position.y;
        }
    }

    bool touched;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touched = true;
        }
    }

    void FixedUpdate () {

        if (touched && !counted && gameObject.GetComponent<Rigidbody2D>().gravityScale == 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
            touched = false;
        }
        

	    if (transform.position.y < -4 || transform.position.x > 8 || transform.position.x < -8)
        {
            GlobalVariables.hasLost = true;
            Destroy(gameObject);
        }
        if (GlobalVariables.restarted)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > 6)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-GlobalVariables.boxForce, 0));
        }
        if (transform.position.x < -6)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(GlobalVariables.boxForce, 0));
        }
    }
}
