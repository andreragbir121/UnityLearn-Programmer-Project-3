using UnityEngine;

public class repeatBackground : MonoBehaviour
{
    private Vector3 startPos;                       //variable for detecting the position of background
    private float repeatWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;                          //assign the position of the background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;   //gets the size of the background and divides by 2 so that it can repeat again, where player would not notice the repeat
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth){      //if the position of the background is less than original starting position minus the width then the below function is performed
            transform.position = startPos;                          //reset the position of the background
        }
    }
}
