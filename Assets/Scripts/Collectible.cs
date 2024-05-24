/*
 * Author: Thaqif Adly Bin Mazalan
 * Date: 19/5/24
 * Description: This class is for the collectibles
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    /// <summary>
    /// int variable that holds the collectible's score.
    /// </summary>
    public int myScore = 1;

    /// <summary>
    /// This function destroys the collectible once it is collected.
    /// </summary>
    public void Collected() 
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// This function calls when a rigidbody/object enters the collider.
    /// </summary>
    private void OnTriggerEnter(Collider collision)
    {
        // Checks if the object that entered the collider is the player
        if (collision.gameObject.tag == "Player")
        {
            // Updates the player that it is near the collectible and
            // returns itself indicating that it is near this collectible
            collision.gameObject.GetComponent<player>().UpdateCollectible(this);
        }
    }

    /// <summary>
    /// This function calls when a rigidbody/object exits the collider.
    /// </summary>
    private void OnTriggerExit(Collider collision)
    {
        // Checks if the object that exited the collider is the player
        if (collision.gameObject.tag == "Player")
        {
            // Updates the player that it is not near the collectible and
            // returns null indicating that it is not near the collectible (or any collectible)
            collision.gameObject.GetComponent<player>().UpdateCollectible(null);
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
