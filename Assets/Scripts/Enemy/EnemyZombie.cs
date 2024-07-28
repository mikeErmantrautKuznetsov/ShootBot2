using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyZombie : MonoBehaviour, IEnemyZombie
{
    private float health = 20f;
    private bool isAliveZombie = true;
    NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        ZombieDestroy();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"Damage {damage} is applied");
        health -= damage;

        if (health == 0)
        {
            isAliveZombie = false;
            animator.enabled = false;
            agent.enabled = false;
            ScoreManager.score++;
        }
    }

    public void ZombieDestroy()
    {
        if (isAliveZombie == false)
        {
            StartCoroutine(ZombieLife());
        }
    }

    IEnumerator ZombieLife()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
