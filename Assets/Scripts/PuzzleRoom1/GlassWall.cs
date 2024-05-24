/*
 * Author: Thaqif Adly Bin Mazalan
 * Date: 19/5/24
 * Description: This class is for the glass wall in puzzle room 1 that deactivates when the puzzle is solved
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassWall : MonoBehaviour
{
    /// <summary>
    /// Stores the red pressure plate
    /// </summary>
    private GameObject redPlate;

    /// <summary>
    /// Stores the green pressure plate
    /// </summary>
    private GameObject greenPlate;

    /// <summary>
    /// Stores the blue pressure plate
    /// </summary>
    private GameObject bluePlate;

    /// <summary>
    /// bool variable that stores the red trigger information
    /// </summary>
    private bool redTrigger = false;

    /// <summary>
    /// bool variable that stores the red trigger information
    /// </summary>
    private bool greenTrigger = false;

    /// <summary>
    /// bool variable that stores the red trigger information
    /// </summary>
    private bool blueTrigger = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This code keeps checking the status of the plates
        redPlate = GameObject.Find("Red Plate");
        redTrigger = redPlate.gameObject.GetComponent<ColouredPlates>().triggered;

        greenPlate = GameObject.Find("Green Plate");
        greenTrigger = greenPlate.gameObject.GetComponent<ColouredPlates>().triggered;

        bluePlate = GameObject.Find("Blue Plate");
        blueTrigger = bluePlate.gameObject.GetComponent<ColouredPlates>().triggered;

        // Once all plates are triggered, the glass wall deactivates.
        // If one or more of the plates get untriggered, the glass wall activates back from ColouredPlates.cs
        if (redTrigger && greenTrigger && blueTrigger)
        {
            gameObject.SetActive(false);
        }
    }
}
