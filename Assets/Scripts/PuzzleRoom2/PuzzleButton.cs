/*
 * Author: Thaqif Adly Bin Mazalan
 * Date: 19/5/24
 * Description: This class is for the coloured buttons in the puzzle locked behind the purple door.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    /// <summary>
    /// Stores the material that it has itself.
    /// </summary>
    public Material colour;

    /// <summary>
    /// This function calls when a rigidbody/object enters the collider.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider collision)
    {
        // Checks if the object that entered the collider is the player
        if (collision.gameObject.tag == "Player")
        {
            // Updates the player that it is near the button and
            // returns itself indicating that it is near this button
            collision.gameObject.GetComponent<player>().UpdateButton(this);
        }
    }

    /// <summary>
    /// This function calls when a rigidbody/object exits the collider.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit(Collider collision)
    {
        // Checks if the object that exited the collider is the player
        if (collision.gameObject.tag == "Player")
        {
            // Updates the player that it has left the button and
            // returns null indicating that it is not near this button (or any button)
            collision.gameObject.GetComponent<player>().UpdateButton(null);
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
