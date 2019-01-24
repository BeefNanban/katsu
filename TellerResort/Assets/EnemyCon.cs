using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCon : MonoBehaviour {

    //private Animator animator;
    public GameObject target;
    private NavMeshAgent agent;
    private Vector3 velocity;
    private Vector3 direction;
    private bool arrived;
    private SetEnemy setPosition;
    private float ProgressTime;
    private EnemyState state;
    [SerializeField]
    private float freezetime = 0.3f;
    private Transform playerTransform;
    [SerializeField]
    private float waitTime = 5f;
    [SerializeField]
    private float walkSpeed = 2.0f;
    [SerializeField]
    private float rotateSpeed = 45f;
    private Vector3 destination;

    public enum EnemyState
    {
        Walk,
        Wait,
        Chase,
        Freeze
    };

    public void SetState(string mode, Transform obj = null)
    {
        if (mode == "walk")
        {
            arrived = false;
            ProgressTime = 0.0f;
            state = EnemyState.Walk;
            setPosition.CreateRandomPosition();
            agent.SetDestination(setPosition.GetDestination());
            agent.isStopped = false;
        }
        else if (mode == "chase")
        {
            state = EnemyState.Chase;
            arrived = false;
            playerTransform = obj;
            setPosition.SetDestination(playerTransform.position);
            agent.SetDestination(setPosition.GetDestination());
            agent.isStopped = false;
        }
        else if (mode == "wait")
        {
            ProgressTime = 0f;
            state = EnemyState.Wait;
            arrived = true;
            agent.isStopped = true;
        }
    }

    public EnemyState GetState()
    {
        return state;
    }

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        setPosition = GetComponent<SetEnemy>();
        agent.speed = 1;

        SetState("wait");

    }
	
	// Update is called once per frame
	void Update () {
        if (state == EnemyState.Walk || state == EnemyState.Chase)
        {
            if (state == EnemyState.Chase)
            {
                setPosition.SetDestination(playerTransform.position);
                agent.SetDestination(setPosition.GetDestination());
            }


            if (state == EnemyState.Walk)
            {
                if (agent.remainingDistance < 0.7f)
                {
                    SetState("wait");
                }
            }
            else if (state == EnemyState.Chase || state == EnemyState.Walk)
            {
                if (agent.remainingDistance < 1.0f)
                {

                }
            }
            else if (state == EnemyState.Wait)
            {
                ProgressTime += Time.deltaTime;

                if (ProgressTime > waitTime)
                {
                    SetState("walk");
                }
            }
            else if (state == EnemyState.Freeze)
            {
                ProgressTime += Time.deltaTime;

                if (ProgressTime > freezetime)
                {
                    SetState("walk");
                }
            }
        }

    }
}
