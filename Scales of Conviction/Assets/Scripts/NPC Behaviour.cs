using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    //stae based on whether it is the player or enemy turn
    public enum State
    {
        Idle,
        Active,
    }

    public State state;

    //Accessing other Triggers aside from main ones
    public LineOfSight loS;

    //additional public variables
    public bool chasing = false; //checking if chasing the player or not
    private NavMeshAgent navigator; //using the navmesh
    public Bounds floorBounds; //checking the bounds withing which to place random targets
    public Vector3 targetPoint; //target of ai when not chasing
    public GameObject targetReticle; // visualizer for current goal of AI
    public float offSetY = 2f; //Offset height for target visualizer
    public GameObject playerTarget;
    public GameObject loSTrigger;

    // Start is called before the first frame update
    void Start()
    {
        navigator = GetComponent<NavMeshAgent>();
        floorBounds = GameObject.Find("Floor").GetComponent<Renderer>().bounds;
        playerTarget = GameObject.FindWithTag("Player");

        //Checking current object tag to change behaviour slightly
        if(gameObject.tag == "Enemy")
        {
            targetReticle = GameObject.Find("Enemy Target");
        } else if(gameObject.tag == "Merchant")
        {
            targetReticle = GameObject.Find("Merchant Target");
        }

        SetRandomTarget();

        //set default state to Idle
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing == true)
        {
            targetPoint = playerTarget.transform.position;
            navigator.SetDestination(targetPoint);
        }

        if (StatManager.Instance.playerTurn == false)
        {
            state = State.Active;
        }
        else
        {
            state = State.Idle;
        }

        //check state machine
        switch (state)
        {
            case State.Idle:
                navigator.enabled = false;
                loSTrigger.GetComponent<Collider>().enabled = false;
                break;

            case State.Active:
                navigator.enabled = true;
                loSTrigger.GetComponent<Collider>().enabled = true; 
                navigator.SetDestination(targetPoint);
                break;
        }

        if (Vector3.Distance(transform.position, targetPoint) <= 0.1f && !chasing)
        {
            SetRandomTarget();
        }
    }

    void SetRandomTarget()
    {
            //set a new random point
            float rX = Random.Range(floorBounds.min.x, floorBounds.max.x);
            float rZ = Random.Range(floorBounds.min.z, floorBounds.max.z);
            //float rY = Random.Range(floorBounds.min.y, floorBounds.max.y);
            targetPoint = new Vector3(rX, transform.position.y, rZ);
            navigator.SetDestination(targetPoint);

            //display a target at chosen point
            targetReticle.transform.position = new Vector3(targetPoint.x, transform.position.y + offSetY, targetPoint.z);
            //ConfirmTarget();
            //check that destination is on navmesh
            //Invoke("ConfirmTarget", 0.2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall" && chasing == false)
        {
            SetRandomTarget();
        }
    }

    void ConfirmTarget()
    {
        if(navigator.pathEndPosition != targetPoint)
        {
            SetRandomTarget();
        }
    }
}
