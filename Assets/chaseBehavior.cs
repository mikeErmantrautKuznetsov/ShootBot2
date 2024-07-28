using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chaseBehavior : StateMachineBehaviour
{
    //private NavMeshAgent agent;
    //private Transform player;
    //private float AttackCharacter = 2f;
    //private float chaseRange = 10f;

    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    agent = animator.GetComponent<NavMeshAgent>();
    //    agent.speed = 4f;

    //    player = GameObject.FindGameObjectWithTag("Player").transform;
    //}


    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    agent.SetDestination(player.position);
    //    float distance = Vector3.Distance(animator.transform.position, player.position);

    //    if (distance < AttackCharacter)
    //    {
    //        animator.SetBool("IsAttack", true);
    //    }

    //    if (distance > chaseRange)
    //    {
    //        animator.SetBool("IsChase", false);
    //    }
    //}

    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    agent.SetDestination(agent.transform.position);
    //    agent.speed = 2f;
    //}
}
