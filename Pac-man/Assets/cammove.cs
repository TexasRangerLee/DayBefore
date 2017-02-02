using UnityEngine;
using System.Collections;

public class cammove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward, 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.back, 1);

        }
        if (Input.GetKey(KeyCode.A))
        {
           // transform.rotation 
        }
	
	}
}
