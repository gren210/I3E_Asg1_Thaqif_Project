/*
 * Author: Thaqif Adly Bin Mazalan
 * Date: 19/5/24
 * Description: This class is for the doors, mainly responsible for the rotation of doors and locking them
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /// <summary>
    /// Boolean function to determine whether door is opened or closed.
    /// </summary>
    public bool opened = false;

    /// <summary>
    /// Boolean function to determine whether the requirements for the door opening has been met.
    /// </summary>
    public bool locked = true;

    /// <summary>
    /// This variable holds the corresponding door GameObject
    /// </summary>
    public GameObject doorbox;

    /// <summary>
    /// OpenDoor() is a function to rotate the door and set opened = true.
    /// </summary>
    public void OpenDoor()
    {
        // Checks if the requirement for door opening has been met before opening the door.
        if (!locked)
        {
            // This code gets the door's rotational information, rotates the y axis by 90 degrees
            // and the set the doors rotational values to the new values.
            Vector3 currentRotation = doorbox.transform.eulerAngles;
            currentRotation.y += 90f;
            doorbox.transform.eulerAngles = currentRotation;
            opened = true;
        }
    }

    /// <summary>
    /// CloseDoor() is a function to rotate back the door after it is opened.
    /// </summary>
    public void CloseDoor()
    {
        // This code gets the door's rotational information, rotates the y axis by 90 degrees
        // and the set the doors rotational values to the new values.
        Vector3 currentRotation = doorbox.transform.eulerAngles;
        currentRotation.y -= 90f;
        doorbox.transform.eulerAngles = currentRotation;
        opened = false;
    }

    /// <summary>
    /// This function sets whether the requirement for the door has been met.
    /// </summary>
    /// <param name="lockStatus"></param>
    public void SetLock(bool lockStatus)
    {
        locked = lockStatus;
    }


    /// <summary>
    /// This function calls when a rigidbody/object enters the collider.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // Checks if the object that entered the collider is the player
        // and whether the door is not opened to prevent infinite opening
        if (other.gameObject.tag == "Player" && !opened)
        {
            // This updates the player that the player is detected in the collider
            // and returns itself indicating that the player is near this door.
            other.gameObject.GetComponent<player>().UpdateDoor(this);
        }

    }

    /// <summary>
    /// This function calls when a rigidbody/object exits the collider.
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerExit(Collider collider)
    {
        // Checks if the object that entered the collider is the player.
        if (collider.gameObject.tag == "Player")
        {
            // This checks whether the door has been opened to call CloseDoor().
            // This is to prevent unintentional rotation of the door.
            if (opened)
            {
                CloseDoor();
            }

            // Updates the player that the player has left the collider, and
            // returns null indicating the player is not near the door (or any door)
            collider.gameObject.GetComponent<player>().UpdateDoor(null);
        }
        // Start is called before the first frame update
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
