using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLapAttack : MonoBehaviour
{
    [Header("Common")]
    [SerializeField, Min(0f)] private float damage = 10f;

    [Header("Masks")]
    [SerializeField] private LayerMask searchLayerMask;
    [SerializeField] private LayerMask obstacleLayerMask;

    [Header("Overlap Area")]
    [SerializeField] private Transform overlapStartPoint;
    [SerializeField] private OverLapType overLapType;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 boxSize = Vector3.one;
    [SerializeField, Min(0f)] private float sphereRadius = 1f;

    [Header("Obstacles")]
    [SerializeField] private bool considerObstacles;

    [Header("Gizmos")]
    [SerializeField] private DrawGizmosType drawGizmosType;
    [SerializeField] private Color gizmosColor = Color.cyan;

    private readonly Collider[] overlapResults = new Collider[32];
    private int overlapResultsCount;


    private void LateUpdate()
    {
        PerformAttack();
    }

    public void PerformAttack()
    {
        if (TryFindEnemies())
        {
            TryAttackEnemies();
        }
    }

    private bool TryFindEnemies()
    {
        var position = overlapStartPoint.TransformPoint(offset);

        overlapResultsCount = overLapType switch
        {
            OverLapType.Box => OverlapBox(position),
            OverLapType.Sphere => OverLapSphere(position),

            _ => throw new ArgumentOutOfRangeException(nameof(overLapType)),
        };

        return overlapResultsCount > 0;
    }

    private int OverlapBox(Vector3 position)
    {
        return Physics.OverlapBoxNonAlloc(position, boxSize / 2, overlapResults,
            overlapStartPoint.rotation, searchLayerMask.value);
    }

    private int OverLapSphere(Vector3 position)
    {
        return Physics.OverlapSphereNonAlloc(position, sphereRadius, overlapResults, searchLayerMask.value);
    }

    private void TryAttackEnemies()
    {
        for (int i = 0; i < overlapResultsCount; i++)
        {
            if (overlapResults[i].TryGetComponent(out IEnemyZombie enemyZombie) ==  false)
            {
                continue;
            }
            if(considerObstacles)
            {
                var startPointPosition = overlapStartPoint.position;
                var colliderPosition = overlapResults[i].transform.position;
                var hasObstacle = Physics.Linecast(startPointPosition, colliderPosition
                    ,obstacleLayerMask.value);

                if (hasObstacle)
                {
                    continue;
                }
                
            }
            enemyZombie.TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        TryDrawGizmos(DrawGizmosType.Always);
    }

    private void OnDrawGizmosSelected()
    {
        TryDrawGizmos(DrawGizmosType.OnSelected);
    }

    private void TryDrawGizmos(DrawGizmosType requiredType)
    {
        if (drawGizmosType != requiredType)
            return;

        if (overlapStartPoint == null)
            return;

        Gizmos.matrix = overlapStartPoint.localToWorldMatrix;
        Gizmos.color = gizmosColor;

        switch(overLapType)
        {
            case OverLapType.Box: Gizmos.DrawCube(offset, boxSize); break;
            case OverLapType.Sphere: Gizmos.DrawSphere(offset, sphereRadius); break;

            default: throw new ArgumentOutOfRangeException(nameof(overLapType));
        }
    }
}
