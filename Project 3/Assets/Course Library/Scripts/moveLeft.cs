using UnityEngine;

public class moveLeft : MonoBehaviour
{
    private float speed = 20;                               //daclare a float variable for he speed to move
    private int leftBound = -15;                            //declare  a bound
    private playerController playerControllerScript;         //declare a variable for the playerControllerScript.   Another script in the game
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();        //uses the playercontrollerscript to assign the player controller script
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerControllerScript.gameOver == false){                  //if the playcontrollerscript is set to false then proceed to:
            transform.Translate(Vector3.left * Time.deltaTime * speed); //move the player forward at a the set speed above
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")){     //if the position x is lest than the left bound and the game object is as well then: 
            Destroy(gameObject);    //destroy the object
        }
    }
}
