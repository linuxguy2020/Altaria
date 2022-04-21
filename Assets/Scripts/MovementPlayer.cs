using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    //VARIABLES
    // SERIALIZE FIELD MI PERMETTE DI MODIFICARE IL VALORE NELL'INSPECTOR
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    private Vector3 velocity;
    private Vector3 moveDirection;
    private CharacterController controller;
    private Animator animator;
    private Vector2 input;

    //START & UPDATE
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        Move();
        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }
        */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey("w"))
        {
            JumpForward();
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey("s"))
        {
            JumpBackWard();
        }

    }

    //UTILS
    private void Move()
    {
        //Ferma la gravità quando tocca il piano
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded)
        {
            animator.SetBool("Falling", false);
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            animator.SetFloat("InputX", input.x);
            animator.SetFloat("InputY", input.y);
            moveDirection = new Vector3(input.x, 0, input.y);
            moveDirection = transform.TransformDirection(moveDirection);
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }

            moveDirection *= moveSpeed;
        }
        else
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Falling"), 1);
            animator.SetBool("Falling", true);
        }

        controller.Move(moveDirection * Time.deltaTime); //DeltaTime per il controllo dei frame
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void Walk()
    {
        moveSpeed = walkSpeed;

    }

    private IEnumerator Attack()
    {
        animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 1);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.9f);
    }



    private void Jump()
    {
        //Equazione per il calcolo del salto
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        animator.SetLayerWeight(animator.GetLayerIndex("Jump"), 1);
        animator.SetTrigger("Jump");
    }

    private void JumpForward()
    {
        //Equazione per il calcolo del salto
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        animator.SetLayerWeight(animator.GetLayerIndex("JumpForward"), 1);
        animator.SetTrigger("JumpForward");
    }

    private void JumpBackWard()
    {
        //Equazione per il calcolo del salto
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        animator.SetLayerWeight(animator.GetLayerIndex("JumpBackWard"), 1);
        animator.SetTrigger("JumpBackWard");
    }

    


}
    
    
    
    


