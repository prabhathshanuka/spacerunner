using System.Collections;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private const float TURN_SPEED = 0.05F;
    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5.0f;
    private float jumpForce = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 5.0f;
    private float StartTime;

    private bool isDead = false;
    //Animation
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
        controller = GetComponent<CharacterController>();
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update(){
        Debug.Log(speed);

        if (isDead)
            return;

        if (Time.time - StartTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;

        bool isGrounded = IsGrounded();
        anim.SetBool("Grounded", isGrounded);
        if (IsGrounded())//If grounded
        {
            verticalVelocity = -0.8f;
           
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //jump
                anim.SetTrigger("Jump");
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity*Time.deltaTime;
            //Fast falling mechanic
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = -jumpForce;
            }
        }
        //X -Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed/2;
        if (Input.GetMouseButton(0))
        {   
            //Are we holding touch on the right side?
            if (Input.mousePosition.x > Screen.width / 2)
                moveVector.x = speed;
            else
                moveVector.x = -speed;
          

        }
        //y - Up and Down
        moveVector.y = verticalVelocity;
        //z -forward and backward
        moveVector.z = speed;

      
    {
        controller.Move((moveVector * speed) * Time.deltaTime);
        //rotate the player to where he is going
        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero) {
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, TURN_SPEED);
        }
        

    }
}

    public void SetSpeed(float modifier)
    {
        speed += 1;
    }
    //it is beign called every time our capsule hits somethong
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if ( hit.gameObject.tag == "Enemy")
            Death();
        if (hit.gameObject.tag == "Arrow")
        {
            speed = 4;

        }
        else
        {
            return;
        }
           
    }
    private void Death()
    {
        Debug.Log("dead");
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
    private bool IsGrounded()
    {
        Ray groundRay = new Ray(new Vector3(controller.bounds.center.x, (controller.bounds.center.y - controller.bounds.extents.y)+0.2f,controller.bounds.center.z),Vector3.down);
        Debug.DrawRay(groundRay.origin, groundRay.direction,Color.cyan, 0.3f);

         return Physics.Raycast(groundRay,0.2f + 0.1f);
       
    }
}
