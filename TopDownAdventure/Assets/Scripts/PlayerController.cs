using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sr;

    //Sprite Variables 
    public Sprite upSprite;
    public 
    //public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       //set a variable to hold a position informaton 
        Vector3 newPosition = transform.position;

        //go up
        if (Input.GetKey("w"))
        {
            newPosition.y += speed;
            //change sprite to up sprite
            //sr.sprite = upSprite;
        }

        //go left 
        if(Input.GetKey("a")) 
        {
            newPosition.x -= speed;
        }

        //go down
        if(Input.GetKey("s")) 
        {
            newPosition.y -= speed;
        }

        //go right
        if(Input.GetKey("d")) 
        { 
            newPosition.x += speed;
        }
        transform.position = newPosition;
    } 
    
}




