using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.scripts;

public class Playerv1 : MonoBehaviour
{
    private const float TURN_SPEED = 2f;
    private const float LANE_DISTANCE =1.5f;
    private CharacterController controller;
    private float jumpForce = 6.0f;
    private float gravity = 12.0f;
    private float verticalVelocity;
    public float speed = 100f;
    public float normalspeed = 15.0f;
    private int desiredLane = 1; // 0 = Left, 1 = Middle , 2 = Right
    private bool isDead = false;
    private int EnemyHit;
    private int Life  ;
    public bool LifeAdded;
    private float Coinscore;
    private bool slowmotion = false;
    private float slow = 0.0f;
    float t;
    public bool flyis;
    public int   Destruction;
    public FireButton firebtn;
    public PunchButton punchbtn;
    int punchcount;
    public bool walldestroied = false;

    
    private bool wallhit =false;
   //private float sprint = 1000.0f;
   // private float startsprint;
    private float maxspeed =100.0f;
   // private float flyspeed = 2.0f;
    private float animationDuration = 3.0f;
    private float StartTime;
    public Text SpeedText;
    public Text coinText;
    public Text LastcoinText;
    public Text LifeCount;
    public Text LifeText;
    public Text Destructions;
   
    public GameObject projectiles;
    private int DeathCount = 0;
    int punch;
    int Ammo;
    int MaxAmmo;
    
    //Animation
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Ammo = PlayerPrefs.GetInt("ammo");
        MaxAmmo = PlayerPrefs.GetInt("maxammo");
        Destruction = PlayerPrefs.GetInt("Destruct");
      
         Coinscore = PlayerPrefs.GetFloat("Coinscore");
       
        controller = GetComponent<CharacterController>();//accses to the character controll
        anim = GetComponent<Animator>();    //accses to the Animator
        StartTime = Time.time;
        //gameObject.tag = "Untagged";

    }

    // Update is called once per frame
    void Update()
    {
        if (normalspeed > 79)
        {
            firebtn.ToggleFirebtn();
        }
        else
        {
            firebtn.ToggleFirebtnOff();
        }
        speed += 2;
        slowmotion = projectiles.GetComponent<projectile>().slowmo;
       
        slowmotionactivate();
     
        Life = PlayerPrefs.GetInt("Life");
       // Debug.Log("LANE" + desiredLane);
       // LifeText.text = (Life).ToString();
       
        LifeText.text = (Life).ToString();
        LifeCount.text = (Life).ToString();
        coinText.text = ((int)Coinscore).ToString();
        SpeedText.text = ((int)speed).ToString(); //Input.acceleration.x.ToString();
        LastcoinText.text = ((int)Coinscore).ToString();
        Destructions.text = ((int)Destruction).ToString();
        if (Time.time - StartTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        
        if (speed > maxspeed)
        {
            normalspeed = 110.0f;
            gameObject.tag = "bullet";
        }
        
      
        //Debug.Log("speed"+speed);
        if (isDead)
            return;
        
        //Gather the inputs on which lane we should be
       //if (Input.acceleration.x < 0.1)
      //  {
          //  if (Input.acceleration.x > 0)
          //  desiredLane = 1;
       // }
       // if (Input.acceleration.x < -0.1)
          //  MoveLane(false);
       // if (Input.acceleration.x > -0.1)
       // {
          //  if(Input.acceleration.x < 0)
          //  desiredLane = 1;
    //    }
       // if (Input.acceleration.x > 0.1)
           // MoveLane(true);
        if (MobileInput.Instance.SwipeLeft)
            MoveLane(false);
        if (MobileInput.Instance.SwipeRight)
            MoveLane(true);
        //Calcilate where we should be in the future
        Vector3 targetPosition = transform.position.z*Vector3.forward;
        if (desiredLane == 0)
            targetPosition += Vector3.left * LANE_DISTANCE;
        else if(desiredLane == 2)
            targetPosition += Vector3.right * LANE_DISTANCE;
        //Let's calculate our move delta
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * 15.0f;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        //move player
        controller.Move(moveVector * Time.deltaTime);
        //rotate the player to where he is going
        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero)
        {
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, TURN_SPEED);
        }
        //calculated Y
        bool isGrounded = IsGrounded();//check is grounded or no
      // if (gravity < 5)
         //{
          //   anim.SetTrigger("Jump");
           // anim.SetBool("Grounded", isGrounded);//set for the bool value to change transition jump to run\
      //   }
        //else
      //  {
           // anim.SetTrigger("Jump");
      //  }
            anim.SetBool("Grounded", isGrounded);//set for the bool value to change transition jump to run\
        if (IsGrounded())//If grounded
        {
           
            if (speed < 5.0f)
            {
               // anim.SetTrigger("idle");
               

            }
            verticalVelocity = -0.1f; 

            if (MobileInput.Instance.SwipeUp)
            {
                //jump
               
                anim.SetTrigger("Jump");
                verticalVelocity = jumpForce;
                SoundManager.PlaySounds("jump");
               
            }
            else if (MobileInput.Instance.SwipeDown)
            {
                //Slide
                //StartSliding();
                //speed *= 2; 
               // Invoke("StopSliding", 10.0f);
                

            }
            else if (MobileInput.Instance.Tap)
            {
               
                

            }
            
            
        }
       
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            //Fast falling mechanic
            if (MobileInput.Instance.SwipeDown)
            {
                verticalVelocity = -jumpForce;

            }
        }
       
    }
    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);

    }
    
    //Death function
    public void Death()
    {
        Debug.Log("dead");
        DeathCount = DeathCount + 1;
        isDead = true;
        GetComponent<Score>().OnDeath();
        PlayerPrefs.SetFloat("Coinscore", Coinscore);
        SoundManager.PlaySounds("dead");
       

    }
    private bool IsGrounded()
    {
        Ray groundRay = new Ray(new Vector3(controller.bounds.center.x, (controller.bounds.center.y - controller.bounds.extents.y) + 0.5f, controller.bounds.center.z), Vector3.down);
        Debug.DrawRay(groundRay.origin, groundRay.direction, Color.cyan, 0.5f);

        return Physics.Raycast(groundRay, 0.5f + 0.1f);

    }
    public void SetSpeed(float modifier)
    {
        normalspeed += modifier;

    }
    private void StartSliding()
    {
      //  anim.SetBool("Sliding", true);
    }
    private void StopSliding()
    {
        
        anim.SetBool("aim", false);
       

    }
    
    //Check player hit something
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Enemy")&&!(flyis)) {
            if (Life > 0)
            {
                
                SoundManager.PlaySounds("playerhit");
                Life -= 1;

                PlayerPrefs.SetInt("Life", Life);

                EnemyHit += 1;

                Debug.Log("Enemy Hit" + EnemyHit + "Life" + Life);
            }

            if ( Life==0)
            {
                if (!(DeathCount > 0))
                {
                    anim.SetTrigger("death");

                    Death();
                }

            }

        }

        else if (other.tag == "Coin")
        {
            CoinAdder();
         
            SoundManager.PlaySounds("CoinColected");

          //  Debug.Log("Hitcoin");
            
        }
        else if (other.tag == "Coin2")
        {
            CoinAdder2();
            

        }
        else if(other.tag == "fly"){
           
            fly();
            Invoke("Stopfly", 50.0f);
            Debug.Log("Flying huththooo");
            SoundManager.PlaySounds("flysound");
            Coinscore = Coinscore + 100;
        }
        else if((other.tag == "Enemy")&&(flyis))
        {
            
            Destruction = Destruction - 1;
            Debug.Log("Destructiosn" + Destruction);
            SoundManager.PlaySounds("Explode");
            if (Destruction < 0){
                Destruction = PlayerPrefs.GetInt("Destruct");
                Life -= 1;
                PlayerPrefs.SetInt("Life", Life);
                if (Life == 0)
                {
                    if (!(DeathCount > 0))
                    {
                        anim.SetTrigger("death");

                        Death();
                    }

                }


            }

        }
        else if (other.tag == "wall")
        {
            wallhit = true;
            PunchBtnShow();
            anim.SetTrigger("idle");
            //SoundManager.PlaySounds("Explode");
        }
        else if (other.tag == "Life")
        {
            Life += 1;
            PlayerPrefs.SetInt("ammo",MaxAmmo);
            PlayerPrefs.SetInt("Life", Life);

            //SoundManager.PlaySounds("Explode");
        }
     
    }

   //Coin Score
    public void CoinAdder()
    {
        Coinscore += 1;
       // PlayerPrefs.SetFloat("Coinscore", Coinscore);
        Debug.Log("Hitcoin");
    }
    public void CoinAdder2()
    {
        Coinscore += 20;
      //  PlayerPrefs.SetFloat("Coinscore", Coinscore);
    }
    public void TimetravelActivate()
    {
        
    }
    public void slowmotionactivate()
    {
        if (slowmotion)
        {
            speed = slow;
        }
        else
            speed = normalspeed; 
    }

    public void fly()
    {
        int flyiss = 1;
        PlayerPrefs.SetInt("Flyis", flyiss);
       // anim.SetBool("FLY", true);
        flyis = true;
        
       anim.SetTrigger("Jump");
       verticalVelocity = 3;
      
        gameObject.tag = "bullet";
        gravity = 1;
         t = normalspeed;
        normalspeed = 110;
    }
    public void Stopfly()
    {
        int flyiss = 0;
        PlayerPrefs.SetInt("Flyis", flyiss);
       
        gameObject.tag = "bullet";
        gravity = 12.0f;
        normalspeed = t;
        Invoke("Afterfly", 4.0f);
    }
    public void Afterfly()
    {
        flyis = false;
        //int flyiss = 0;
        //PlayerPrefs.SetInt("Flyis", flyiss);
        //flyis = false;
        gameObject.tag = "Player";
        //gravity = 12.0f;
       // normalspeed = t;
        //Invoke("Stopfly", 10.0f);
        Debug.Log("hey i am player");
    }
    public void punching()
    {
        punch = Random.Range(1, 20);
        punchcount = punchcount + 1;
        Debug.Log("Punch: " + punch);
        if(punchcount > 10){
            walldestroied = true;
            anim.SetTrigger("run");
            Invoke("wall", 2f);
        }
        //Aim

        // anim.SetBool("aim", true);
        //Invoke("StopSliding",0.5f);
        if ((wallhit) && (punch < 10))
        {
            anim.SetTrigger("kik");
            Debug.Log("kikkkkkkkkkkkk");
            SoundManager.PlaySounds("kik");
        }
        if ((wallhit) && (punch > 10))
        {

            anim.SetTrigger("punch");
            Debug.Log("punchhhhhhh");
            SoundManager.PlaySounds("punch");
        }
    }
    
        public void PunchBtnShow()
        {
            punchbtn.TogglePunchButtonOn();
            Invoke("PunchBtnHide", 0.5f);

        }
        public void PunchBtnHide()
        {
            punchbtn.TogglePunchButtonOff();
            Invoke("PunchBtnShow", 0.5f);

        }
        public void wall()
        {
            
            walldestroied = false;
        }
        
   
   
   
}
