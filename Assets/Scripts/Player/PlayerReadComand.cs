using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerReadComand : MonoBehaviour, IPlayerController, IEnemyZombie
{
    private float healthPerson = 10000f;

    [SerializeField] private CharacterController character;
    [SerializeField] private GameObject playerCamera;
    private float speed = 10f;
    private float gravity = -30f;
    private float jumpHeight = 3f;

    [SerializeField]
    private Transform groundCheck;
    private float groundDistance = 0.8f;
    [SerializeField]
    private LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    public bool isAlive = true;

    [SerializeField]
    private GameObject sceneLose;
    [SerializeField]
    private GameObject cameraLose;

    private void Start()
    {
        isAlive = true;
        cameraLose.SetActive(true);
        sceneLose.SetActive(false);
    }

    public void MovePlayer()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (isAlive == true)
        {
            Vector3 move = transform.right * horizontal + transform.forward * vertical;

            character.Move(move * speed * Time.deltaTime);

        }
    }

    public void PlayerGravityCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        character.Move(velocity * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        if (isAlive == true)
        {
            Debug.Log($"Damage {damage} is applied");
            healthPerson -= damage;
        }

        if (healthPerson == 0)
        {
            Debug.Log("спнм онксвем");
            isAlive = false;
            Cursor.lockState = CursorLockMode.Confined;
            sceneLose.SetActive(true);
            cameraLose.SetActive(false);
        }
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(2);
    }
}
