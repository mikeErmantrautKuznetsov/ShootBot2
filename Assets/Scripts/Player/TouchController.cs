using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class TouchController : MonoBehaviour
{
    [SerializeField]
    private FixedTouchField fixedTouchField;
    [SerializeField]
    private PlayerMoveCamera playerMoveCamera;

    
    void Update()
    {
        playerMoveCamera.LockAxis = fixedTouchField.TouchDist;
    }
}
