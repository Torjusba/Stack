using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLoop : MonoBehaviour
{

    public Text textBox;

    void Start()
    {
        textBox.text = "0";
    }

    public Rigidbody2D box_pre;

    int ms;
    int s;

    public Camera camera;
    public Transform dropper;
    public Transform checker;

    public Vector3 modVector = new Vector3(0, -7.5f, 0);
    public Vector3 spawnPosition = new Vector3(-5f, 1.5f, 0);
    public Vector3 increment = new Vector3(0, 0.01f, 0);


    void FixedUpdate()
    {
        ms += 1; //One FixedUpdate every 0.02 seconds

        if (ms >= 50)
        {
            s++;
            ms = 0;
        }

        if (s == 9 && ms == 20)
        {
            checkMove();
        }

        if (s == 9 && ms == 30)
        {
            unCheckMove();
        }


        //Every 4 seconds
        if (s == 4 && ms == 0)
        {
            spawnBox();
        }

        if (s == 10)
        {
            s = 0;
        }
    }

    void checkMove()
    {
        checker.position += modVector;
    }

    void unCheckMove()
    {
        checker.position -= modVector;
    }

    public void moveUp()
    {
        Debug.Log("moved");
        camera.GetComponent<Transform>().position = Vector3.Lerp(camera.GetComponent<Transform>().position, camera.GetComponent<Transform>().position + increment, 1.0F);
        dropper.position += increment;
        checker.position += increment;
        spawnPosition += increment;
    }

    void spawnBox()
    {
        Instantiate(box_pre, spawnPosition, Quaternion.identity);
    }
}
