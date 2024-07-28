using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMoveMousePosition : MonoBehaviour
{
    private IPlayerMoveCamera moveCameraAround;

    private void Start()
    {
        moveCameraAround = GetComponent<IPlayerMoveCamera>();
    }

    void Update()
    {
        moveCameraAround.MoveMousePosition();
    }
}
