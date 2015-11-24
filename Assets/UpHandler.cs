using UnityEngine;
using System.Collections;

public class UpHandler : MonoBehaviour
{
    public GameLoop gameloop;

    void OnTriggerEnter2D(Collider2D c)
    {
        gameloop.moveUp();
    }
}