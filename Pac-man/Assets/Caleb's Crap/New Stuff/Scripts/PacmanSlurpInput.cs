using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanSlurpInput : MonoBehaviour {

    public GameObject topLip;
    public GameObject bottomLip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            topLip.GetComponent<Animator>().SetTrigger("TriggerSlurp");
            bottomLip.GetComponent<Animator>().SetTrigger("TriggerSlurp");
        }
	}
}
