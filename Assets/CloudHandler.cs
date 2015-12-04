using UnityEngine;
using System.Collections;

public class CloudHandler : MonoBehaviour {

	void Update () {
	if (transform.position.x < -6)
        {
            Destroy(gameObject);
        }
	}
}
