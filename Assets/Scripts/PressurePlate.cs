/*
 * Author: Thaqif Adly Bin Mazalan
 * Date: 19/5/24
 * Description: This class is for the pressure plate linked to the door leading to the maze.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    /// <summary>
    /// This variable holds the corresponding door GameObject
    /// </summary>
    public Door linkedDoor;

    /// <summary>
    /// bool variable that holds information on whether the pressure plate is stepped on
    /// </summary>
    public bool triggered = false;

    /// <summary>
    /// int variable that counts how many objects are in its colliders to prevent bugs
    /// </summary>
    int numberColliders = 0;

    /// <summary>
    /// This function calls when a rigidbody/object enters the collider.
    /// </summary>
    private void OnTriggerEnter(Collider collider)
    {
        // Unlocks the door
        linkedDoor.SetLock(false);
        numberColliders++;
    }

    /// <summary>
    /// This function calls when a rigidbody/object exits the collider.
    /// </summary>
    private void OnTriggerExit(Collider collider)
    {
        numberColliders--;

        // The bug is when both the box and player are on the pressure plate and either of the
        // objects leave the collider, it triggers OnTriggerExit() which sets Lock = true.
        // Hence, this code prevents that by checking if when the object leaves the plate, there
        // are no more objects on the plate and can lock the door.
        if (numberColliders == 0)
        {
            linkedDoor.SetLock(true);
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
