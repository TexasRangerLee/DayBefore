using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Respawn : MonoBehaviour 
{
    public GameObject PacMan;

    Pac_Man_FSM pacManScript;


	// Use this for initialization
	void Start () 
    {
        PacMan = GameObject.FindGameObjectWithTag("PacMan");
        pacManScript = GameObject.FindGameObjectWithTag("PacMan").GetComponent<Pac_Man_FSM>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Entered the Trigger");
    }

    void OnTriggerExit (Collider other)
    {
        Debug.Log("Exited the Trigger");
        if (PacMan.transform.position.y < 11 || PacMan.transform.position.y < 0)
        {
            PacMan.transform.position = pacManScript.pacMansLastLocation;
        }
        //PacMan.transform.position = pacManScript.pacMansLastLocation;
        //Reset Pac-Man to his last ground terrain position
    }
}
