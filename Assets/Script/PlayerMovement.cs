using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 1;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private int count = 0;

    private Vector3 moveDirection;
    private Vector3 velocity; //tracking gravity

    private CharacterController controller;
    private Animator anim;

    [SerializeField] private bool isGrounded;

    [SerializeField] private float groundCheckDistance;

    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;
    // Start is called before the first frame update
    private void Start()
    {
       // GetComponent<Rigidbody>().velocity = Vector3.down;
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    // private void FixedUpdate()
    // {
    //     if(GetComponent<Rigidbody>().IsSleeping() )
    //     {
    //         Debug.Log("sleep");
    //         // GetComponent<Rigidbody>().WakeUp();
    //     }
    //     else {
    //         Debug.Log("notsleep");
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Traped");
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            Debug.Log(count);
        }
    }

    // void OnCollisionEnter(Collision other)
    // {
    //    // Debug.Log("Traped");
	// 	if (other.gameObject.CompareTag("Trap"))
	// 	{
	// 		Debug.Log("Traped");
	// 	}
	// }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            anim.SetBool("IsGrounded",true);
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        //w -> moveZ = 1 ; s->moveZ=-1

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        // if(isGrounded)
        // {
            //anim.SetBool("IsGrounded", true);
            if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if(moveDirection == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;
            controller.Move(moveDirection * Time.deltaTime);
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
                Jump();
            }
        //}


        //controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1.0f, 0.1f, Time.deltaTime);
    }

    private void Idle(){
        anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    private void Jump(){
        anim.SetBool("IsGrounded",false);
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
