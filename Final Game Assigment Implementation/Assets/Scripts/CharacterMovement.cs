using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    Vector3 move;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private CharacterController controller;
    private Animator animator;
    private float walkSpeed = 5;
    private float runSpeed = 8; 

    Rigidbody m_rigidBody;
    public GameObject respawnPoint;
 
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        m_rigidBody = GetComponent<Rigidbody>();
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
       ProcessMovement();
       UpdateAnimator();
       
    }

    public void RespawnPlayer()
    {
        transform.position = respawnPoint.transform.position;
    }

    void UpdateAnimator()
    {
        if (move.magnitude == 0.0f)
        {
            animator.SetFloat("CharacterSpeed",0.0f);
        }
        else if (move.magnitude > 0.0f)
        {
             if (Input.GetButton("Fire3"))// Left shift
            {
                animator.SetFloat("CharacterSpeed",1.0f);
            }
            else
            {
                animator.SetFloat("CharacterSpeed",0.5f);
            }

        }
        
        // TODO add animation SetParameters for Idle/Walk/Run
    }

    void ProcessMovement()
    { 
        // Moving the character foward according to the speed
        float speed = GetMovementSpeed();

        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Turning the character
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        // Making sure we dont have a Y velocity if we are grounded
        // controller.isGrounded tells you if a character is grounded ( IE Touches the ground)
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            if (Input.GetButtonDown("Jump") )
            {
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
            else 
            {
                // Dont apply gravity if grounded and not jumping
                gravity.y = -1.0f;
            }
        }
        else 
        {
            // Since there is no physics applied on character controller we have this applies to reapply gravity
            gravity.y += gravityValue * Time.deltaTime;
        }  
        playerVelocity = gravity * Time.deltaTime + move * Time.deltaTime * speed;
        controller.Move(playerVelocity);

    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }
}
