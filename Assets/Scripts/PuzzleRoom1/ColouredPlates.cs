/*
 * Author: Thaqif Adly Bin Mazalan
 * Date: 19/5/24
 * Description: This class is for the coloured pressure plates in puzzle room 1, which checks whether the correct coloured box is touching it.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColouredPlates : MonoBehaviour
{
    /// <summary>
    /// bool variable to set whether the pressure plate is triggered
    /// </summary>
    public bool triggered = false;

    /// <summary>
    /// Material type variable that will store its own colour
    /// </summary>
    public Material colour;

    /// <summary>
    /// Stores the wall GameObject
    /// </summary>
    private GameObject wall;


    // Start is called before the first frame update
    void Start()
    {
        // Finds the glass wall in unity
        wall = GameObject.Find("Glass Wall");
    }

    /// <summary>
    /// This function calls when a rigidbody/object enters the collider.
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter(Collider collider)
    {
        // Checks if the object has the same material as itself, which the plate will be triggered if true.
        if (colour == collider.gameObject.GetComponent<MeshRenderer>().sharedMaterial)
        {
            triggered = true;
        }
    }

    /// <summary>
    /// This function calls when a rigidbody/object exits the collider.
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerExit(Collider collider)
    {
        // Checks if the object has the same material as itself, which the plate will not be triggered if true.
        // This function is necessary as it ensures that it is the correct box that left the plate.
        if (colour == collider.gameObject.GetComponent<MeshRenderer>().sharedMaterial)
        {
            wall.SetActive(true);
            triggered = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
