using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    
    public AudioSource keySound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitInfo.collider!=null && hitInfo.collider.gameObject.layer ==layerIndex)
        {

        
        if (keyboard.current.spaceKey.wasPressedThisFrame && Key == null)
        {
            Key = hitInfo.collider.gameObject;
            Key.GetComponent<Rigidbody2D>().isKinematic = true;
            Key.transform.position = grabPoint.position;
            Key.transform.SetParent(transform);
        }
        else if (keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Key.GetComponent<RigidBody2D>().isKinematic = false;
            Key.transform. SetParent(null);
            Key = null;
        }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("ive been collected!");
            //keySound.Play();
           //Destroy(this.game.Object); //destory the key
        }
    }
}
