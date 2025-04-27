using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody playerRb; //declares a Rigidbody variable from unity
    private Animator playerAnim;    //declares an animator variable from inside unity
    public int jumpForce =  10; //declares an integer to apply a jump force for the character
    public float gravityModifier; //creates a int var for physics gravity
    public ParticleSystem explosionParticle;        //creates a particleSystem variable for the player death explosion particle effect
    public ParticleSystem dirtParticle;        //creates a particleSystem variable for the player running on dirt effect
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   //forces to get the rigidbody, which is applied to the player character.
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space ) && isOnGround && !gameOver){               //gets input key from users and perform the function below. also tells the game you are no longer on the ground 
            playerRb.AddForce(Vector3.up *jumpForce,ForceMode.Impulse);    //Adds a jump force to the character
            isOnGround = false;                                            //tells the game you are no longer on the ground after hitting space bar
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1);
        }
    }

    void OnCollisionEnter(Collision collision)                              //detects collision with the player and the ground
    {

        if (collision.gameObject.CompareTag("Ground")){                     //detect collision with object tagged Ground
            isOnGround = true;                                                  //once player and ground is collided again, the isOnGround is set to true to restart the process
            dirtParticle.Play();

        }else if(collision.gameObject.CompareTag("Obstacle")){              //else if the player collides with an object tagged obstacle then 
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);            //uses the animator from within unity to set the animation to death in the end after dying;
            playerAnim.SetInteger("DeathType_int", 1);  
            explosionParticle.Play();                       //plays the explosion particles when player dies
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1);


        }
    }   
}
