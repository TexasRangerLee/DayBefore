using UnityEngine;
using System.Collections;

public class Camera_Follower : MonoBehaviour 
{
    [SerializeField]
    GameObject PacMan;

    [SerializeField]
    public float offset;

    //Smooth following
    [SerializeField]
    public float distanceAwayFrom;
    [SerializeField]
    public float distanceUpFrom;
    [SerializeField]
    public float smoothCamera;
    [SerializeField]
    public Transform followPacMan;
    private Vector3 targetsPosition;

	// Use this for initialization
	void Start () 
    {
        followPacMan = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //transform.position = new Vector3(PacMan.transform.position.x, PacMan.transform.position.y, PacMan.transform.position.z - offset);
        //transform.rotation = PacMan.transform.rotation;
	}

    void LateUpdate()
    {
        targetsPosition = followPacMan.position + Vector3.up * distanceUpFrom - followPacMan.forward * distanceAwayFrom;

        transform.position = Vector3.Lerp(transform.position, targetsPosition, Time.deltaTime * smoothCamera);

        transform.LookAt(followPacMan);
    }
}
