using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowForAim : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        float distance = Vector3.Distance(player.transform.position, agent.transform.position);

        if (distance < 2.5f)
        {
            animator.Play("Zombie@Attack01");
        }
        else
        {
            animator.Play("Zombie@Walk01");
        }
    }
}
