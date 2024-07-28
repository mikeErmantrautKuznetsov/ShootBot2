using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    [SerializeField] private RayCastAttack rayCastAttack;
    private PlayerReadComand readComand;

    private const KeyCode LeftMouseButton = KeyCode.Mouse0;

    private float startFire = 0.5f;
    private float startFireWait = 0.25f;

    private void Start()
    {
        readComand = GetComponent<PlayerReadComand>();
        readComand.isAlive = true;
    }

    private void Update()
    {
        if (startFire <= 0)
        {
            if (Input.GetKey(LeftMouseButton) && readComand.isAlive == true)
            {
                rayCastAttack.PerformAttack();
                startFire = startFireWait;
            }
        }
        else
        {
            startFire -= Time.deltaTime;
        }
    }
}
