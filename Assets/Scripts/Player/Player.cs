using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IPlayerController iPlayerController;

    void Start()
    {
        iPlayerController = GetComponent<IPlayerController>();
    }

    void Update()
    {
        iPlayerController.MovePlayer();
        iPlayerController.PlayerGravityCheck();
    }
}
