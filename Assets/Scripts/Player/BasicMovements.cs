using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicMovements : MonoBehaviour
{
    
    // SERIALIZE FIELD 
    [SerializeField] private float moveSpeed; 
    [SerializeField] private float walkSpeed;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    
	//VARIABLES
	public float jumpHeight;
    private Vector3 velocity;
    private Vector3 moveDirection;
    private CharacterController controller;
    private Animator animator;
    private Vector2 input;
	private bool isJumping;
    
    //START	 
	void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
	//UPDATE	
    void Update()
    {
        defaultMovement();
    }

    //PRINCIPAL METHOD
    private void defaultMovement()
    {
       
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);  //CREA UNA SFERA SOTTO IL PLAYER E CONTROLLA SE E' GROUNDED 
        
        //NECESSARIO PER FERMARE LA GRAVITA' QUANDO TOCCA IL PIANO
        if (isGrounded && velocity.y < 0)
        {
			isJumping=false;
            velocity.y = -2f;
        }
        
        if (isGrounded)
        {
            animator.SetBool("Falling", false); // E' GROUNDED QUINDI NON DEVE FARE L'ANIMAZIONE "FALLING"
            input.x = Input.GetAxis("Horizontal"); //INPUT X
            input.y = Input.GetAxis("Vertical"); // INPUT Y
            animator.SetFloat("InputX", input.x); // CONDIZIONE PER L'ANIMATOR, IL CORRISPETTIVO LO TROVIAMO NELLA SEZIONE ANIMATOR
            animator.SetFloat("InputY", input.y); // CONDIZIONE PER L'ANIMATOR, IL CORRISPETTIVO LO TROVIAMO NELLA SEZIONE ANIMATOR
            moveDirection = new Vector3(input.x, 0, input.y);// SET DIREZIONE PLAYER
            moveDirection = transform.TransformDirection(moveDirection); //MUOVE EFFETTIVAMENTE IL PLAYER
            //KEY INPUT
			if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
    		 if ( Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }        

			moveDirection *= moveSpeed;
        }
        else
        {	
				//SE NON E' GROUNDED E NON STAI SALTANDO ALLORA "FALLING"
               if(isJumping==false){
			  	  animator.SetLayerWeight(animator.GetLayerIndex("Falling"), 1);//SET ANIMAZIONE
              	  animator.SetBool("Falling", true);//SET ANIMAZIONE
				}
             
        }

        controller.Move(moveDirection * Time.deltaTime); //DeltaTime per il controllo dei frame
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
	//BASIC MOVEMENT
    private void Walk()
    {
        moveSpeed = walkSpeed;
    }
    
    private void Jump()
    {		
		//	setJumpHeight(1.5f);
			isJumping=true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); //Equazione per il calcolo del salto
            animator.SetLayerWeight(animator.GetLayerIndex("Jump"), 1); //SET ANIMAZIONE
            animator.SetTrigger("Jump"); //SET ANIMAZIONE
     }

	//UTILS
	
	private void setJumpHeight(float height){

		jumpHeight=height; //Altezza del salto
	}


    




}
    
    
    
    


