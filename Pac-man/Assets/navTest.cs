using UnityEngine;
using System.Collections;

public class navTest : MonoBehaviour {
    public Transform target;
    public Transform[] targetList;
    public int targetCount = 0;
    private bool canMove=true;
    public float minDist = .5f;
    private UnityEngine.AI.NavMeshAgent nmesh;
	// Use this for initialization
	void Start () {
        nmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nmesh.SetDestination(targetList[targetCount].transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	if (Vector3.Distance(nmesh.destination, transform.position) <= minDist && canMove)
        {
            canMove = false;
            StartCoroutine(getNextTarget());
        }
	}

   /* void getNextTarget()
    {
        Debug.Log("In next path");
        
        if (targetCount++ == targetList.Length)
        {
            targetCount = 0;
        }
        else
        {
            targetCount++;
        }
        nmesh.SetDestination(targetList[targetCount].transform.position);
        
        
    }*/

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(targetList[targetCount].position, minDist);
    }

    IEnumerator getNextTarget()
    {
        Debug.Log("In next path");

        if (targetCount+1 == targetList.Length)
        {
            Debug.Log("In tCount loop");
            targetCount = 0;
        }
        else
        {
            targetCount++;
        }
        nmesh.SetDestination(targetList[targetCount].transform.position);

        yield return new WaitForSeconds(1f);
        canMove = true;
        yield return null;
    }
}
