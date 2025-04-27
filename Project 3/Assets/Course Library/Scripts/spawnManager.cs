using System;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject []obstaclePrefab;                     //create a gameobject array for storing the obstacle prefab
    private Vector3 spawnPos= new Vector3(25, 0, 0);        //create a vector3 position to assign a specified position

    private int startDelay = 2;                             //set a start delay 
    private int repeatRate = 2;                             //set a repeat rate 

    public playerController playerControllerScript;                 //creates a variable based on playercontroller script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();    //assign the playercontroller to variable declared above
        InvokeRepeating("spawnObstacles", startDelay, repeatRate);   // Calls the spawnObstacles method repeatedly, starting after 'startDelay' seconds, and repeating every 'repeatRate' seconds.

    }

    // Update is called once per frame
    void Update()
    {
    }

    void spawnObstacles()
    {
        if (playerControllerScript.gameOver == false){                 //tells the game to keep spawning obstacles as long as the bool gameOver is false.
            Instantiate (obstaclePrefab[0], spawnPos, obstaclePrefab[0].transform.rotation);        //constantly spawn the obstacle prefab from above at the given spawnpos 

        }

    }
}
