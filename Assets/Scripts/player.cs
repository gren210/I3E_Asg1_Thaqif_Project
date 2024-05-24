/*
 * Author: Thaqif Adly Bin Mazalan
 * Date: 19/5/24
 * Description: This class is for the player, responsible mostly for detecting inputs and acting upon them as well as showing the appropriate UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour

{

    /// <summary>
    /// TMP text to display score
    /// </summary>
    public TextMeshProUGUI scoreText;

    /// <summary>
    /// TMP text to display collectibles collected
    /// </summary>
    public TextMeshProUGUI collectibleText;

    /// <summary>
    /// TMP text to display directions/help on screen
    /// </summary>
    public TextMeshProUGUI helpText;
    /// <summary>
    /// Stores image of pink key as GameObject to be used in the UI
    /// </summary>
    public GameObject keyIndicator;

    /// <summary>
    /// Store image of keycard as GameObject to be used in the UI
    /// </summary>
    public GameObject keycardIndicator;

    /// <summary>
    /// Store congratulations text as GameObject so that SetActive() can be used ( same for next 3 variables)
    /// </summary>
    public GameObject congrats;

    /// <summary>
    /// Store description text for congrats screen as GameObject
    /// </summary>
    public GameObject description;

    /// <summary>
    /// Store the beginning tutorial text as GameObject
    /// </summary>
    public GameObject tutorial;

    /// <summary>
    /// Store the image box for the tutorial as GameObject
    /// </summary>
    public GameObject tutorialPanel;

    /// <summary>
    /// Count current score of the player
    /// </summary>
    public int currentScore = 0;

    /// <summary>
    /// Count collectibles collected by the player
    /// </summary>
    public int collectibleScore = 0;

    /// <summary>
    /// This is the number of collectibles in the level, made public to make changes easier
    /// </summary>
    public int totalCollectibles = 9;

    /// <summary>
    /// Used to keep track if pink key has been collected, required as the cage opening is different from door opening
    /// </summary>
    public bool isKey = false;

    /// <summary>
    /// Used to check if tutorial is done, so it doesnt appear again
    /// </summary>
    bool isTutorial = false;

    /// <summary>
    /// Used to prevent bugs when the tutorial is done and still runs the code.
    /// </summary>
    int tutCount = 0;



    /// <summary>
    /// Stores the current interactive door in the level.
    /// </summary>
    Door currentDoor;

    /// <summary>
    /// Stores the current interactive collectible in the level.
    /// </summary>
    Collectible currentCollectible;

    /// <summary>
    /// Stores the current interactive keycard in the level.
    /// </summary>
    Keycard currentKeycard;

    /// <summary>
    /// Stores the current interactive key in the level.
    /// </summary>
    PinkKey currentPinkKey;

    /// <summary>
    /// Stores the current interactive button in the level.
    /// </summary>
    PuzzleButton currentButton;

    /// <summary>
    /// Stores the current interactive robot in the level.
    /// </summary>
    Robot currentRobot;

    /// <summary>
    /// This function increases the score of the player and displays his collectible info. 
    /// Takes in parameter of scoreToAdd, which holds information on the score of the collectible collected
    /// </summary>
    public void IncreaseScore(int scoreToAdd)
    {
        // Increases the player score and the number of collectibles the player has collected.
        currentScore += scoreToAdd;
        collectibleScore++;

        // Displays information on the score and collectibles of the player.
        scoreText.text = "Score: " + currentScore.ToString();
        collectibleText.text = "Collectibles: " + collectibleScore + " / 9";
    }

    /// <summary>
    /// Function which is called by the door script to update the player with its gameObject, 
    /// used to check which door it is and display the correct text, and allow for opening the door.
    /// </summary>

    public void UpdateDoor(Door newDoor)
    {
        // Sets currentDoor with the door that the player is touching
        currentDoor = newDoor;

        // This if block is for displaying the correct text at the different doors
        if (currentDoor != null)
        {
            if (currentDoor.locked == false)
            {
                helpText.text = "Press E to open door";
            }
            else if (currentDoor.name == "Lock" && isKey == true)
            {
                helpText.text = "Press E to open cage";
            }
            else
            {
                if (currentDoor.name == "Door Limit" && currentDoor.locked == true)
                {
                    helpText.text = "The door is locked. Get at least 25 score to unlock.";
                }
                else if (currentDoor.name == "Door Special" && currentDoor.locked == true)
                {
                    helpText.text = "The door is locked. Find something to unlock it.";
                }
                else if (currentDoor.name == "Door Box" && currentDoor.locked == true)
                {
                    helpText.text = "The door is locked. Look around...";
                }
                else if (currentDoor.name == "Lock" && isKey == false)
                {
                    helpText.text = "The cage is locked. Find something to unlock it.";
                }
            }                      
        }

        // if there is no door, remove the help text from the screen
        else if (currentDoor == null)
        {
            helpText.text = " ";
        }
    }

    /// <summary>
    /// This function updates what collectible the player is touching, and then displays the correct help text to the player.
    /// </summary>
    public void UpdateCollectible(Collectible newCollectible) 
    {
        currentCollectible = newCollectible;
        if (currentCollectible != null)
        {
            helpText.text = "Press E to collect";
        }
        else
        {
            helpText.text = " ";
        }
    }

    /// <summary>
    /// This function updates the keycard the player is touching, then makes the corresponding door unlocked
    /// and displays an indicator that the player has the keycard.
    /// </summary>
    public void UpdateKeycard(Keycard newKeycard)
    {
        currentKeycard = newKeycard;
        if (currentKeycard != null)
        {
            currentKeycard.linkedDoor.SetLock(false);
            keycardIndicator.SetActive(true);
        }
        else
        {
            helpText.text = " ";
        }
    }
    /// <summary>
    /// This function updates the key the player is touching, then updates if the key has been collected and 
    /// displays an indicator that the player has the keycard.
    /// </summary>
    public void UpdatePinkKey(PinkKey newPinkKey)
    {
        currentPinkKey = newPinkKey;
        if (currentPinkKey != null)
        { 
            isKey = true;
            keyIndicator.SetActive(true);
        }
        else
        {
            helpText.text = " ";
        }
    }

    /// <summary>
    /// This function updates the button the player is near, then displays the correct help text.
    /// </summary>
    public void UpdateButton(PuzzleButton newButton)
    {
        currentButton = newButton;
        if (currentButton != null)
        {
            helpText.text = "Press E to push button";
        }
        else
        {
            helpText.text = " ";
        }
    }

    /// <summary>
    /// This function updates the robot when the player is near, checks whether the player has done the tutorial yet and then displays the correct help text.
    /// </summary>
    public void UpdateRobot(Robot newRobot)
    {
        currentRobot = newRobot;
        if (currentRobot != null && !isTutorial)
        {
            helpText.text = "Press E to talk";
        }
        else
        {
            helpText.text = " ";
        }

    }
    
    /// <summary>
    /// Function which runs when the interact input is pressed (E in this case)
    /// </summary>
    void OnInteract()
    {
        // On interact, checks whether the player is near the collectible. If he is,
        // increase the players score by calling IncreaseScore() and passing through 
        // the parameter of the collectibles score, then calls Collected() to destroy collectible
        if (currentCollectible != null)
        {
            IncreaseScore(currentCollectible.myScore);
            currentCollectible.Collected();
            helpText.text = " ";
        }
        
        // On interact, checks whether the player is near the door.
        if(currentDoor != null)
        {
            // Checks whether the door name is Lock and whether the Pink Key has been collected.
            // This is made specially for the cage opening as it does not require rotation and just
            // needs to be destroyed or set inactive.
            if (currentDoor.name == "Lock" && isKey == true)
            {
                currentDoor.doorbox.SetActive(false);
                helpText.text = " ";
            }

            // Checks if the door is any other door, if its not locked and not opened. If true, 
            // call OpenDoor() which rotates the door.
            else if (currentDoor.name != "Lock" && currentDoor.locked == false && currentDoor.opened == false)
            {
                currentDoor.OpenDoor();
                helpText.text = " ";
            }
        }

        // Checks if the player is near the button. This check is for the button parkour puzzle locked
        // behind the purple door.
        if (currentButton != null)
        {
            // This line gets the script component from the glass barrier mesh, and calls ButtonCheck()
            // which checks whether the correct button has been pressed. The rest of the code will
            // be in GlassWall2.cs
            GameObject.Find("Glass Wall 2").GetComponent<GlassWall2>().ButtonCheck(currentButton);

        }

        // Checks if the player is near the robot, and if the tutorial has not been done yet.
        if (currentRobot != null && !isTutorial)
        {
            tutorial.SetActive(true);
            tutorialPanel.SetActive(true);
            isTutorial = true;
        }
        // Once the tutorial is done, this code closes the tutorial text and box on screen.
        else if (isTutorial && tutCount == 0)
        {
            tutorial.SetActive(false);
            tutorialPanel.SetActive(false);
            tutCount++;
            helpText.text = " ";

        }


    }

    // Start is called before the first frame update
    void Start()
    {
        // Displays the UI for the score and collectible count at the start of the game.
        scoreText.text = "Score: 0";
        collectibleText.text = "Collectibles: 0 / 9";

    }

    // Update is called once per frame
    void Update()
    {
        // Constantly checks whether all the collectibles have been collected,
        // which then displays the congratulations screen.
        if (collectibleScore == totalCollectibles)
        {
            congrats.SetActive(true);
            description.SetActive(true);
        }
    }
}
