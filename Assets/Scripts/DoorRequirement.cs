/*
 * Author: Thaqif Adly Bin Mazalan
 * Date: 19/5/24
 * Description: This class is to set the score requirement for the door to the coloured box puzzle
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRequirement : MonoBehaviour
{
    /// <summary>
    /// int variable that sets the score requirement for the door.
    /// </summary>
    public int scoreRequirement = 3;

    /// <summary>
    /// This variable holds the corresponding door GameObject
    /// </summary>
    public Door linkedDoor;

    /// <summary>
    /// int variable that will hold the player's current score.
    /// </summary>
    int currentScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Gets the players current score
        currentScore = GameObject.Find("PlayerCapsule").GetComponent<player>().currentScore;

        // Checks if the player's score has met the door requirement,
        // then unlocks the door if true.
        if (currentScore >= scoreRequirement)
        {
            linkedDoor.SetLock(false);
        }

    }
}
