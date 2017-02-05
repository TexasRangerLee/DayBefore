using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Attack : MonoBehaviour 
{

    private GameObject pacman;

    private Pac_Man_FSM script;

    [SerializeField]
    private bool canAttack;

	// Use this for initialization
	void Start () 
    {
        pacman = GameObject.FindGameObjectWithTag("PacMan");
        script = pacman.GetComponent<Pac_Man_FSM>();
        canAttack = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PacMan" && canAttack && script.invulnerable != true)
        {
            StartCoroutine(script.invulnearbiltyTime());
            StartCoroutine(exhaustion());
        }
    }

    IEnumerator exhaustion()
    {
        //can not attack
        canAttack = !canAttack;
        yield return new WaitForSeconds(5f);
        canAttack = !canAttack;
    }
}
