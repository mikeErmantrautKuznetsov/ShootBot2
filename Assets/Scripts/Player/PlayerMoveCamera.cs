using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCamera : MonoBehaviour, IPlayerMoveCamera
{
    //private float mouseSensivity = 1000f;
    //[SerializeField]
    //private Transform playerBody;
    //private float xRotation = 0;

    private float xMove;
    private float yMove;
    private float xRotation;
    [SerializeField] private Transform playerBody;
    public Vector2 LockAxis;
    private float sensitvity = 250f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MoveMousePosition()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitvity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitvity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50, 50);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    //public void MoveMousePosition()
    //{
    //    xMove = LockAxis.x * sensitvity * Time.deltaTime;
    //    yMove = LockAxis.y * sensitvity * Time.deltaTime;
    //    xRotation -= yMove;
    //    xRotation = Mathf.Clamp(xRotation, -20f, 30f);

    //    transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    //    playerBody.Rotate(Vector3.up * xMove);
    //}


}
