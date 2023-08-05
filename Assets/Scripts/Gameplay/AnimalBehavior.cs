using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalBehavior : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    //private Transform target;
    private NavMeshAgent agent;
    private float timer;

    [SerializeField] private Animator animator;
    private int Anim_Speed;

    // Use this for initialization
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        Anim_Speed = Animator.StringToHash("speed");
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }

        AnimalAnimation();
    }

    private static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMesh.SamplePosition(randDirection, out NavMeshHit navHit, dist, layermask);

        return navHit.position;
    }
    private void AnimalAnimation()
    {
        animator.SetFloat(Anim_Speed, agent.velocity.magnitude);
    }
}
