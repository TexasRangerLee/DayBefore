using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActionScript : MonoBehaviour {

    Pac_Man_FSM script;

    void Awake()
    {
        script = GameObject.FindGameObjectWithTag("PacMan").GetComponent<Pac_Man_FSM>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DebugEnergy(bool infinite)
    {
        script.debugInfiniteEnergy = infinite;
    }

    public void DebugHealth(bool infinite)
    {
        script.debugInfiniteHealth = infinite;
    }
}
