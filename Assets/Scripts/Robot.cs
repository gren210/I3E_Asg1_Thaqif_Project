/*
 * Author: Thaqif Adly Bin Mazalan
 * Date: 19/5/24
 * Description: This class is for the tutorial robot at the start
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    /// <summary>
    /// This function calls when a rigidbody/object enters the collider.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // Checks if the object that entered the collider is the player
        if (other.gameObject.tag == "Player")

        {
            // Updates the player that it is near the robot and
            // returns itself indicating that it is near the robot.
            other.gameObject.GetComponent<player>().UpdateRobot(this);
        }

    }

    /// <summary>
    /// This function calls when a rigidbody/object enters the collider.
    /// </summary>

     private void OnTriggerExit(Collider other)
    {
        // Checks if the object that exited the collider is the player.
        if (other.gameObject.tag == "Player")
        {
            // Updates the player that it is not near the robot and
            // returns null indicating that it is not near the robot.
            other.gameObject.GetComponent<player>().UpdateRobot(null);
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
