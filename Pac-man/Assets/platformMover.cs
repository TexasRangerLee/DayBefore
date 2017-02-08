using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMover : MonoBehaviour {
    public Transform[] points;
    int n = 0;
    Vector3 curr;
    Vector3 tar;
	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(curr,tar, .5f);
        if (transform.position == tar)
        {
            n++;
            if (n == points.Length)
            {
                n = 0;
            }
            curr = tar;
            tar = points[n].position;
        }
		
	}
}
