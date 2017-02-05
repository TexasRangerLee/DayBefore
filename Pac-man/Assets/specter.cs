using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specter : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        agent.SetDestination(player.transform.position);
        StartCoroutine(repath());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator repath()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
    }
}
