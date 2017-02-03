using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaSlurpScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject mysteryCollision = col.gameObject;
        string tag = mysteryCollision.tag; //Get tag from collided object

        switch (tag)
        {
            case "pellet":
                OnPelletCollision(mysteryCollision);
                break;

            case "antipellet":
                OnAntiPelletCollision(mysteryCollision);
                break;

            case "enemy":
                OnEnemyCollision(mysteryCollision);
                break;

            case "megapellet":
                OnMegaCollision(mysteryCollision);
                break;

            default:
                break;
        }
    }

    void OnPelletCollision(GameObject g)
    {
        //increase energy
        Destroy(g);
    }

    void OnAntiPelletCollision(GameObject g)
    {
        //decrease energy
        Destroy(g);
    }

    void OnEnemyCollision(GameObject g)
    {
        //call enemy death call
    }

    void OnMegaCollision(GameObject g)
    {
        //engage super mode
    }
}
