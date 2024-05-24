/*
 * Author: Thaqif Adly Bin Mazalan
 * Date: 19/5/24
 * Description: This class is for the light indicators on the doors, properly telling the player and showing the correct light for when it is locked or unlocked 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockIndicator : MonoBehaviour
{
    /// <summary>
    /// This variable holds the corresponding door GameObject
    /// </summary>
    public Door linkedDoor;

    /// <summary>
    /// This variable holds the material for an unlocked door
    /// </summary>
    public Material unlockedLight;

    /// <summary>
    /// This variable holds the material for an locked door
    /// </summary>
    public Material lockedLight;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the door is locked, and displays the correct corresponding material,
        if (linkedDoor.locked == false)
        {
            gameObject.GetComponent<MeshRenderer>().material = unlockedLight;
        }
        else if (linkedDoor.locked == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = lockedLight;
        }
    }
}
