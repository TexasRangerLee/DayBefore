using UnityEngine;
using System.Collections;

public class Pac_Man_FSM : MonoBehaviour 
{
    enum PacManStates { Idle, Moving, Jumping, MegaChomp, Dead}

    
    public float speed;
    public float rotations;
    public float jump;
    public float gravity;

    Rigidbody rb;

    [SerializeField]
    private bool inAir = false;

    CharacterController cc;

    private Vector3 moveDirection;


	// Use this for initialization
	void Start () 
    {
	    rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        rb.freezeRotation = true;
        moveDirection = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotations, 0);
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            float vertical = Input.GetAxis("Vertical");
            moveDirection = new Vector3(0, 0, vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jump;
            }


        }
        //moveDirection.z = Input.GetAxis("Vertical");
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.5f, this.transform.position.z);
        }

	}
}
