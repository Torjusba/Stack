using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {

    public float targetY = -3.00f;

    public Transform spawner;

	// Update is called once per frame
	void Update () {

        float realTargetY = targetY + 2.50f;
            
        Vector3 pos = transform.position;
        pos.y = Mathf.Lerp(pos.y, realTargetY, 1 * Time.deltaTime);
        transform.position = pos;

        Vector3 spawnPos = spawner.position;
        spawnPos.y = Mathf.Lerp(spawnPos.y, realTargetY + 2.5f, 1 * Time.deltaTime);
        spawner.position = spawnPos;
	}
}
