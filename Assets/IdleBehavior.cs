using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleBehavior : StateMachineBehaviour
{
    //private float timer;
    //Transform player;
    //float chaseRange = 10f;

    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    timer = 0;
    //    player = GameObject.FindGameObjectWithTag("Player").transform;
    //}

    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    timer += Time.deltaTime;
    //    if (timer > 5)
    //    {
    //        animator.SetBool("MoveZombie", true);
    //    }

    //    float distance = Vector3.Distance(animator.transform.position, player.position);
    //    if (distance < chaseRange)
    //    {
    //        animator.SetBool("IsChase", true);
    //    }
    //}

    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}
}
