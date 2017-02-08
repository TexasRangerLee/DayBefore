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
    public bool debugInfiniteEnergy;
    public bool debugInfiniteHealth;
    public Vector3 pacMansLastLocation;

    Rigidbody rb;
    CharacterController cc;
    private Vector3 moveDirection;
    private float baseSpeed;
    private bool damaged;
    private Vector3 baseSize;
    private float groundedBase;

    Camera_Follower cameraScritpt;
    float pacManCameraOffset;
    float pacManCameraBack;
    float pacManCameraUp;
    float pacManCameraSmooth;

	// Use this for initialization
	void Start () 
    {
	    rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        cameraScritpt = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera_Follower>();
        //rb.freezeRotation = true;
        moveDirection = Vector3.zero;
        currentHealth = baseHealth;
        baseSpeed = speed;
        adjustSpeed(energy);
        damaged = false;
        baseSize = transform.localScale;
        debugInfiniteEnergy = false;
        debugInfiniteHealth = false;

        pacManCameraOffset = cameraScritpt.offset;
        pacManCameraBack = cameraScritpt.distanceAwayFrom;
        pacManCameraUp = cameraScritpt.distanceUpFrom;
        pacManCameraSmooth = cameraScritpt.smoothCamera;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotations, 0);
        float vertical = Input.GetAxis("Vertical");
        CharacterController controller = GetComponent<CharacterController>();
        Debug.Log(controller.isGrounded);
        if (controller.isGrounded)
        {
            this.rotations = 2f;
            pacMansLastLocation = transform.position;
            groundedBase = transform.position.y;
            //float vertical = Input.GetAxis("Vertical");
            moveDirection = new Vector3(0, -0.2f, vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Rotate(0, Input.GetAxis("Horizontal") * rotations, 0);
                moveDirection.y = jump;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                this.rotations = 1f;
                transform.Rotate(0, Input.GetAxis("Horizontal") * rotations, 0);
                vertical = Input.GetAxis("Vertical");
                moveDirection = new Vector3(0, 0, vertical);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection.y -= gravity / 10 * Time.deltaTime;
                moveDirection *= speed;
            }
            else if (transform.position.y < groundedBase + jump)
            {
                this.rotations = 1;
                moveDirection.y -= gravity * Time.deltaTime;
            }
            else if (transform.position.y > groundedBase + jump)
            {
                this.rotations = 1;
                transform.Rotate(0, Input.GetAxis("Horizontal") * rotations, 0);
                vertical = Input.GetAxis("Vertical");
                moveDirection = new Vector3(0, 0, vertical);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
            }

        }

        //moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (transform.localScale == baseSize)
            {
                cameraScritpt.offset = 10;
                cameraScritpt.distanceAwayFrom = 5;
                cameraScritpt.distanceUpFrom = 0;
                cameraScritpt.smoothCamera = 15;
                this.speed = speed / 2;
                transform.localScale = new Vector3(transform.localScale.x/2,transform.localScale.y/2,transform.localScale.z/2);
            }
            else
            {
                cameraScritpt.offset = pacManCameraOffset;
                cameraScritpt.distanceAwayFrom = pacManCameraBack;
                cameraScritpt.distanceUpFrom = pacManCameraUp;
                cameraScritpt.smoothCamera = pacManCameraSmooth;
                this.speed = speed * 2;
                transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z * 2);
            }
        }


        if (invulnerable)
        {
            StartCoroutine(iFrames());
        }

        if (debugInfiniteEnergy)
        {
            if (energy > 100)
            {
                energy = 100;
                adjustSpeed(energy);
            }
            energy = 900;
        }

        if (debugInfiniteHealth)
        {
            currentHealth = baseHealth;
        }
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

