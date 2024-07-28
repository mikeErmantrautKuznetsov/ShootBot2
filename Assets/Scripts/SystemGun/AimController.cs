using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    public float currentSpread;
    public float speedSpread;

    public Parts[] parts;
    public CharacterController characterMovement;

    float t;
    float curSpeed;

    void Update()
    {
        CrosshairUpdate();
    }

    public void CrosshairUpdate()
    {
        t = 0.005f * speedSpread;
        curSpeed = Mathf.Lerp(curSpeed, currentSpread, t);

        for (int i = 0; i < parts.Length; i++)
        {
            Parts p = parts[i];
            p.trans.anchoredPosition = p.pos * curSpeed;
        }
    }

    [System.Serializable]
    public class Parts
    {
        public RectTransform trans;
        public Vector2 pos;
    }
}
