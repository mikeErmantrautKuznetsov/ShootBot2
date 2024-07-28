using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilGun : MonoBehaviour, IWeaponReact
{
    [SerializeField]
    private Camera cameraService;

    [SerializeField, Min(0f)] private float positionLerpSpeed = 5f;
    [SerializeField, Min(0f)] private float rotationLerpSpeed = 5f;

    private Transform cachedTransform;

    private Vector3 regularCameraLocalPosition;
    private Quaternion regularCameraLocalRotation;

    private float timeShoot = 0.04f;
    private float timeShootWait = 0.04f;

    private void Awake()
    {
        cachedTransform = transform;
        regularCameraLocalRotation = cachedTransform.localRotation;
        regularCameraLocalPosition = cachedTransform.localPosition;
    }

    public void ReactOnPrimaryAttack()
    {
        var cameraTransform = cameraService.transform;

        if (timeShoot <= 0f)
        {
            if (Input.GetMouseButton(0))
            {
                cameraTransform
                    .DOShakePosition(0.02f, 0.01f, 1, 2f, false, true, ShakeRandomnessMode.Harmonic)
                    .SetEase(Ease.InOutBounce)
                    .SetLink(cameraTransform.gameObject);

                cameraTransform
                    .DOShakeRotation(0.02f, 0.01f, 1, 2f, false, ShakeRandomnessMode.Harmonic)
                    .SetEase(Ease.InOutBounce)
                    .SetLink(cameraTransform.gameObject);
                timeShoot = timeShootWait;
            }

        }
        else
        {
            timeShoot -= Time.deltaTime;
        }

    }

    public void RegularAttack()
    {
        var position = cachedTransform.localPosition;
        var rotation = cachedTransform.localRotation;

        rotation = Quaternion.Lerp(rotation, regularCameraLocalRotation, Time.deltaTime * rotationLerpSpeed);
        position = Vector3.Lerp(position, regularCameraLocalPosition, Time.deltaTime * positionLerpSpeed);

        cachedTransform.localPosition = position;
        cachedTransform.localRotation = rotation;
    }
}
