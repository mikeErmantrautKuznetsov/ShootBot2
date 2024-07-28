using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSway : MonoBehaviour
{
    [Header("Common")]
    [SerializeField] private Vector2 force = Vector2.one;
    [SerializeField, Min(0f)] private float multiplier = 5f;
    [SerializeField] private bool inverseX;
    [SerializeField] private bool inverseY;

    [Header("Clamp")]
    [SerializeField] private Vector2 minMaxX;
    [SerializeField] private Vector2 minMaxY;

    protected float AdditionalX;
    protected float AdditionalY;

    private float mouseX, mouseY;
    private float velocityY;

    private void LateUpdate()
    {

        PerformTransformSway();
    }

    private void PerformTransformSway()
    {


        var deltaTime = Time.deltaTime;
        var inverseSwayX = inverseX ? -1f : 1f;
        var inverseSwayY = inverseY ? -1f : 1f;

        mouseX = Input.GetAxis("MouseX") + inverseSwayX;
        mouseY = Input.GetAxis("MouseY") + inverseSwayY;

        OnSwayPreforming(deltaTime);

        var currentX = mouseY * force.y;
        var currentY = mouseX * force.x;

        var endEulerAngleX = Mathf.Clamp(currentX + AdditionalX, minMaxX.x, minMaxX.y);
        var endEulerAngleY = Mathf.Clamp(currentY + AdditionalY, minMaxX.x, minMaxX.y);

        var moment = deltaTime * multiplier;
        var localEulerAngels = transform.localEulerAngles;

        localEulerAngels.x = Mathf.LerpAngle(localEulerAngels.x, endEulerAngleX, moment);
        localEulerAngels.y = Mathf.LerpAngle(localEulerAngels.y, endEulerAngleY, moment);
        localEulerAngels.z = 0f;

        transform.localEulerAngles = localEulerAngels;


    }

    protected virtual void OnSwayPreforming(in float deltaTime)
    {

    }
}
