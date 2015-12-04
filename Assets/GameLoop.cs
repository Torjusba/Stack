using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameLoop : MonoBehaviour
{
    public Transform spawner;

    public bool hasBushed = false;
    void Start()
    {
        GlobalVariables.score = 0;
        GlobalVariables.hasLost = false;
        GlobalVariables.menu = false;
        GlobalVariables.readyForSpawn = true;
        menuCanvas.enabled = false;
        hasBushed = false;
    }

    public Rigidbody2D box_pre;

    public float fireDelay = .5f;
    float nextFire = 3f;
    float nextCloud = 2f;
    
    public Canvas menuCanvas;
    void FixedUpdate()
    {
        if (GlobalVariables.readyForSpawn && !GlobalVariables.menu && !GlobalVariables.hasLost)
        {
            nextFire -= Time.deltaTime;

            if (nextFire <= 0)
            {
                nextFire = fireDelay;
                spawnBox();
            }
        }
        if (Camera.main.GetComponent<CameraHandler>().targetY > 5)
        {
            nextCloud -= Time.deltaTime;

            if (nextCloud <= 0)
            {
                nextCloud = UnityEngine.Random.Range(15f, 20f);
                spawnCloud();
            }
        }



        if (GlobalVariables.hasLost && !GlobalVariables.menu)
        {
            Camera.main.GetComponent<CameraHandler>().targetY = -4;
            menuCanvas.enabled = true;
            GlobalVariables.menu = true;


        }


        if (GlobalVariables.score == 9 && PlayerPrefs.GetInt("HighScore") == 11 && !hasBushed && GlobalVariables.eaasterEgg)
        {
            GlobalVariables.readyForSpawn = false;
            Camera.main.GetComponent<CameraHandler>().targetY = -2;
            StartCoroutine(bush());
            hasBushed = true;
        }

        if (GlobalVariables.restart)
        {
            Restart();
        }
    }

    void spawnBox()
    {
        Vector3 spawnPosition = spawner.position;
        Instantiate(box_pre, spawnPosition, Quaternion.identity);
    }

    public Transform cloud_pre;
    void spawnCloud()
    {
        Vector3 cloudPosition = new Vector3(spawner.position.x + 15f, spawner.position.y + 5 - UnityEngine.Random.Range(1f, 10f), spawner.position.z + 1f);
        Instantiate(cloud_pre, cloudPosition, Quaternion.identity);
    }

    void Restart()
    {
        GlobalVariables.restart = false;
        GlobalVariables.score = 0;
        GlobalVariables.hasLost = false;
        GlobalVariables.menu = false;
        GlobalVariables.readyForSpawn = true;
        GlobalVariables.restarted = true;
        menuCanvas.enabled = false;
        Camera.main.GetComponent<CameraHandler>().targetY = -4;
    }



    public Rigidbody2D plane_pre;
    IEnumerator bush()
    {
        Vector3 planePos = new Vector3(15, Camera.main.GetComponent<CameraHandler>().targetY + 4, 0);
        Debug.Log("bush did 9/11");
        yield return new WaitForSeconds(3f);

        Instantiate(plane_pre, planePos, Quaternion.identity);
    }
}
