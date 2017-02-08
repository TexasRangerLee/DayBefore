using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public float currentHealth;
    public GameObject pacBody;

    Rigidbody rb;
    CharacterController cc;
    private Vector3 moveDirection;
    private float baseSpeed;
    private bool damaged;
    private Vector3 baseSize;

    //Addition by Caleb; if this screws up, blame me
    public bool debugInfiniteEnergy;
    //end Caleb Addition

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
        damaged = false;
        baseSize = transform.localScale;

        //Caleb addition
        debugInfiniteEnergy = false;
        //end addition
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotations, 0);
        float vertical = Input.GetAxis("Vertical");
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            //float vertical = Input.GetAxis("Vertical");
            moveDirection = new Vector3(0, 0, vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Rotate(0, Input.GetAxis("Horizontal") * rotations, 0);
                moveDirection.y = jump;
            }
        }
        else
        {
            if (transform.position.y < jump)
            {

            }
            else
            {
                if (Input.GetKey(KeyCode.F))
                {
                    transform.Rotate(0, Input.GetAxis("Horizontal") * rotations, 0);
                    vertical = Input.GetAxis("Vertical");
                    moveDirection = new Vector3(0, 0, vertical);
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection.y -= gravity/10 * Time.deltaTime;
                    moveDirection *= speed;
                }
                else
                {
                    moveDirection.y -= gravity * Time.deltaTime;
                }
            }
        }

        //moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (transform.localScale == baseSize)
            {
                transform.localScale = new Vector3(transform.localScale.x/2,transform.localScale.y/2,transform.localScale.z/2);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z * 2);
            }
        }


        if (invulnerable)
        {
            StartCoroutine(iFrames());
        }

        //Caleb Addition
        if (debugInfiniteEnergy)
        {
            if (energy < 100)
            {
                energy = 100;
                adjustSpeed(energy);
            }
            energy = 900;
        }
        //end addition

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "AntiPellet")
        {
            Destroy(other.gameObject);
            currentHealth -= 5;
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
        if (speed == baseSpeed * 2)
        {
            return;
        }
        else
        {
            speed = baseSpeed + (baseSpeed * (energy / 100));
        }
    }

    public IEnumerator invulnearbiltyTime()
    {
        invulnerable = true;
        currentHealth = currentHealth - (baseHealth / 3);
        yield return new WaitForSeconds(5f);
        invulnerable = false;
    }

    IEnumerator iFrames()
    {
        
        pacBody.GetComponent<Renderer>().sharedMaterial.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        pacBody.GetComponent<Renderer>().sharedMaterial.color = Color.yellow;
    }
}

