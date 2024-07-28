using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastAttack : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField, Min(0f)] private float damage = 20f;

    [Header("Ray")]
    [SerializeField] private LayerMask layerMask;
    [SerializeField, Min(0)] private float distance = Mathf.Infinity;
    [SerializeField, Min(0)] private int shotCount = 1;

    [Header("Spread")]
    [SerializeField] private bool useSpread;
    [SerializeField, Min(0)] private float spreadFactor = 1f;

    [Header("Partical System")]
    [SerializeField] private ParticleSystem muzzleEffect;
    [SerializeField] private ParticleSystem hitEffectPrefab;
    [SerializeField] private float hitEffectDestroyDelay = 2f;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    public void PerformAttack()
    {
        for (int i = 0; i < shotCount; i++)
        {
            PerformRaycast();
        }

        PerformEffects();
    }

    private void PerformRaycast()
    {
        var direction = useSpread ? transform.forward + CalculateSpread() : transform.forward;
        var ray = new Ray(transform.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, distance, layerMask))
        {
            var hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IEnemyZombie takeDamage))
            {
                takeDamage.TakeDamage(damage);
            }
            else
            {
                // Not Aim effect
            }

            SpawnParticalEffectOmHit(hitInfo);
            OnAtackVisitorIsNotFound(hitInfo);
        }
    }

    private void PerformEffects()
    {
        if (muzzleEffect != null)
        {
            muzzleEffect.Play();
        }

        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    private void SpawnParticalEffectOmHit(RaycastHit hitInfo)
    {
        if (hitEffectPrefab != null)
        {
            var hitEffectRotation = Quaternion.LookRotation(hitInfo.normal);
            var hitEffect = Instantiate(hitEffectPrefab, transform.position, hitEffectRotation);

            Destroy(hitEffect.gameObject, hitEffectDestroyDelay);
        }
    }

    private void OnAtackVisitorIsNotFound(RaycastHit raycastHit)
    {
        var position = raycastHit.point;
        var rotation = Quaternion.LookRotation(raycastHit.normal);

        var hitSmokeEffect = Instantiate(muzzleEffect, position, rotation);
        muzzleEffect.gameObject.SetActive(true);

        Destroy(hitSmokeEffect.gameObject, hitEffectDestroyDelay);
    }

    private Vector3 CalculateSpread()
    {
        return new Vector3
        {
            x = Random.Range(-spreadFactor, spreadFactor),
            y = Random.Range(-spreadFactor, spreadFactor),
            z = Random.Range(-spreadFactor, spreadFactor)
        };
    }

    private void OnDrawGizmos()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out var hitInfo, distance, layerMask))
        {
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        }
        else
        {
            var hitPosition = ray.origin + ray.direction * distance;

            DrawRay(ray, hitPosition, distance, Color.green);
        }
    }

    private static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        const float hitPointRadius = 0.1f;

        Debug.DrawRay(ray.origin, ray.direction * distance, color);

        Gizmos.color = color;
        Gizmos.DrawSphere(hitPosition, hitPointRadius);
    }
}
