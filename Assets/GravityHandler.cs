using UnityEngine;
using System.Collections;

public class GravityHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("triggered");
        if (c.GetComponent<Rigidbody2D>() != null)
        {
            c.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
