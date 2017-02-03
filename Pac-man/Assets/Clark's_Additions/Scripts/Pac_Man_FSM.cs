using UnityEngine;
using System.Collections;

public class Pac_Man_FSM : MonoBehaviour 
{
    enum PacManStates { Idle, Moving, Jumping, MegaChomp, Dead}

    
    public float speed;
    public float rotations;
    public float jump;
    public float gravity;

    [SerializeField]
    private float baseHealth;
    public float energy;

    public bool invulnerable;

    Rigidbody rb;

    public float currentHealth;

    CharacterController cc;

    private Vector3 moveDirection;

    private float baseSpeed;


	// Use this for initialization
	void Start () 
    {
	    rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        rb.freezeRotation = true;
        moveDirection = Vector3.zero;
        currentHealth = baseHealth;
        baseSpeed = speed;
        adjustSpeed(energy);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ghost")
        {
            currentHealth = currentHealth / 3;
            Debug.Log("Pac-Man will die here!");
        }

        if (other.tag == "AntiPellet")
        {
            Destroy(other.gameObject);
            energy -= 15;
            adjustSpeed(energy);
            Debug.Log("Pac-Man would loose health here!");
        }

        if (other.tag == "Pellet")
        {
            Destroy(other.gameObject);
            energy = energy + 20;
            adjustSpeed(energy);
            Debug.Log("Pac-Man would gain energy here");
        }

    }

    public void adjustSpeed(float currentEnergy)
    {
        speed = baseSpeed + (baseSpeed * (energy / 100));
    }
}
