/*
 * Author: Thaqif Adly Bin Mazalan
 * Date: 19/5/24
 * Description: This class is for the keycard 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    /// <summary>
    /// This variable holds the corresponding door GameObject
    /// </summary>
    public Door linkedDoor;

    /// <summary>
    /// This function destroys the collectible once it is collected.
    /// </summary>
    public void Collected()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// This function is called when there is a rigidbody/object colliding with the collider.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        // Checks whether the object colliding with itself is the player.
        if(collision.gameObject.tag == "Player")
        {
            // Updates the player that a collision is detected, and calls Collected()
            // to destroy the collectible.
            collision.gameObject.GetComponent<player>().UpdateKeycard(this);
            Collected();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
