using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanSlurpInput : MonoBehaviour 
{

    public GameObject topLip;
    public GameObject bottomLip;

    private float pacEnergy;

	// Use this for initialization
	void Start () 
    {
        pacEnergy = GameObject.FindGameObjectWithTag("Player").GetComponent<Pac_Man_FSM>().energy;
	}
	
	// Update is called once per frame
	void Update () 
    {
        pacEnergy = GameObject.FindGameObjectWithTag("Player").GetComponent<Pac_Man_FSM>().energy;
		if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (pacEnergy >= 100)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Pac_Man_FSM>().energy -= 100;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Pac_Man_FSM>().adjustSpeed(pacEnergy - 100);
                topLip.GetComponent<Animator>().SetTrigger("TriggerSlurp");
                bottomLip.GetComponent<Animator>().SetTrigger("TriggerSlurp");
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ghost")
        {
            Destroy(other.gameObject);
        }
    }
}
