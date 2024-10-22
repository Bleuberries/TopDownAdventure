using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importing SceneManagement.Library , always make sure to add when creating new scenes

public class PlayerController : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sr;
    public bool hasKey = false;

    //Sprite Variables 
    public Sprite upSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite frontSprite;


   //audio variables 
   public AudioSource soundEffects;
   public AudioClip itemCollect;
   public AudioClip doorEnter;
   

    //public Rigidbody2D rb;

    public static PlayerController instance;
    // Start is called before the first frame update
    void Start()
    {
        soundEffects = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        if(instance != null) //if another instance of the player is in the scene
        {
            Destroy(gameObject); //then destory it 
        }
        instance = this; //reassign the instance to the current player
        GameObject.DontDestroyOnLoad(this.gameObject);
        
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
            sr.sprite = upSprite;
        }

        //go left 
        if(Input.GetKey("a")) 
        {
            newPosition.x -= speed;
            sr.sprite = leftSprite;
        }

        //go down
        if(Input.GetKey("s")) 
        {
            newPosition.y -= speed;
            sr.sprite = frontSprite;
        }

        //go right
        if(Input.GetKey("d")) 
        { 
            newPosition.x += speed;
            sr.sprite = rightSprite;
        }
        transform.position = newPosition;
    } 

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        //check if colliding with a game object with specific tag 
        if (collision.gameObject.tag.Equals("door1"))
        {
            Debug.Log("change scene");
            soundEffects.PlayOneShot(doorEnter, .7f); //play door sound effect
            SceneManager.LoadScene(1);
        }
        if (collision.gameObject.tag.Equals("Key")) 
        {
            Debug.Log("obtained key");
            soundEffects.PlayOneShot(itemCollect, .7f); //play item collect sound effect
            hasKey = true; //player has the key now 
        }
        if(collision.gameObject.tag.Equals("door2") && hasKey == true) 
        {
            Debug.Log("unlocked door!");
            soundEffects.PlayOneShot(doorEnter, .7f);
            SceneManager.LoadScene(0); //take the new scene 
        }

        if (collision.gameObject.tag.Equals("door3") && hasKey == true)
        {
            Debug.Log("unlocked door!");
            soundEffects.PlayOneShot(doorEnter, .7f);
            SceneManager.LoadScene(2); //take to new scene
        }
    }    
}





      
