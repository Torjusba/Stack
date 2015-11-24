using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Box_Handler : MonoBehaviour {
    
    public Text textBox;

	void Start () {
        Vector2 speed = new Vector2(70, 0);
        gameObject.GetComponent<Rigidbody2D>().AddForce(speed);
	}


    public bool counted = false;
    void OnCollisionEnter2D(Collision2D c)
    {
        Debug.Log("collided");
        //When it collides for the first time
        if (!counted)
        {
            Debug.Log("+1");
            //Add 1 to score
            textBox.text = Convert.ToString(Convert.ToInt32(textBox.text)+1);
        }
    }

    void FixedUpdate () {
	    if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
	}
}
