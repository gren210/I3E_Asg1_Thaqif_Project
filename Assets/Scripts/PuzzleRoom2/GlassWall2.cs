/*
 * Author: Thaqif Adly Bin Mazalan
 * Date: 19/5/24
 * Description: This class is for the glass wall in puzzle room 2.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassWall2 : MonoBehaviour
{
    /// <summary>
    /// Stores the material that indicates/shows the puzzle is correct
    /// </summary>
    public Material correct;

    /// <summary>
    /// Stores the material that indicates/shows the puzzle is wrong
    /// </summary>
    public Material wrong;

    /// <summary>
    /// GameObject variable that will store the current colour that is being pressed and checked
    /// </summary>
    GameObject currentLight;

    /// <summary>
    /// GameObject variables that stores the first colour
    /// </summary>
    GameObject first;

    /// <summary>
    /// GameObject variables that stores the second colour
    /// </summary>
    GameObject second;

    /// <summary>
    /// GameObject variables that stores the third colour
    /// </summary>
    GameObject third;

    /// <summary>
    /// GameObject variables that stores the fourth colour
    /// </summary>
    GameObject fourth;

    /// <summary>
    /// bool variable to set whether the original materials have been obtained yet
    /// </summary>
    bool isnotCheck = true;

    /// <summary>
    /// array that stores the GameObjects in order
    /// </summary>
    public GameObject[] objectOrder;

    /// <summary>
    /// array that will store the original coloured materials in order
    /// </summary>
    Material[] originalMat = {null,null,null,null};

    /// <summary>
    /// array that will store the buttons pressed in order
    /// </summary>
    Material[] buttonOrder = { null, null, null, null };

    /// <summary>
    /// array that stores the material names
    /// </summary>
    string[] order = { "BluePlate", "OrangeMat", "CyanButton", "PurpleButton" };

    /// <summary>
    /// The count for looping through the array
    /// </summary>
    int count = 0;

    /// <summary>
    /// This function mainly checks whether the button pressed is pressed at the correct order. It will show the "correct" material if true. If false, it will flash "wrong" and reset the counter.
    /// </summary>
    /// <param name="buttonMat"></param>
    public void ButtonCheck(PuzzleButton buttonMat)
    {
        // Sets the lights GameObject array
        GameObject[] objectOrder = new GameObject[] {first, second, third, fourth};

        // For the first call, this will set the light materials in order in the array.
        if (count == 0 && isnotCheck)
        {
            for (int i = 0; i < 4; i++)
            {
                // GetComponent<MeshRender>() retrieves the MeshRenderer component from the gameObject
                // which holds information on the material of the gameObject.
                originalMat[i] = objectOrder[i].GetComponent<MeshRenderer>().material;
            }
            isnotCheck = false;
        }

        // Checks if the material of the button pressed is in the correct order
        if (buttonMat.colour.name == order[count])
        {
            buttonOrder[count] = buttonMat.colour;
            currentLight = objectOrder[count];
            currentLight.GetComponent<MeshRenderer>().material = correct;
            count++;
        }
        
        // If it is in the wrong order, the button order is reset and it will flash red,
        // followed by returning to its original colour.
        else
        {
            Material[] buttonOrder = {null,null,null,null};
            count = 0;
            WrongLight();
            
            // A coroutine delays the execution of the function
            StartCoroutine(DelayedLight(originalMat));
        }
    }

    /// <summary>
    /// This function gets all the lights to flash red once the wrong button is pressed.
    /// </summary>
    private void WrongLight()
    {
        GameObject[] objectOrder = new GameObject[] { first, second, third, fourth };
        for (int i = 0; i < 4; i++)
        {
            objectOrder[i].GetComponent<MeshRenderer>().material = wrong;
        }
    }

    /// <summary>
    /// This function gets the light gameObjects to display its original colours after flashing red.
    /// </summary>
    /// <param name="originalMat"></param>
    private void OriginalLight(Material[] originalMat)
    {
        GameObject[] objectOrder = new GameObject[] { first, second, third, fourth };
        for (int i = 0; i < 4; i++)
        {
            objectOrder[i].GetComponent<MeshRenderer>().material = originalMat[i];
        }
    }

    /// <summary>
    /// This function delays the function OriginalLight so that the "wrong" lights have time to show itself. 
    /// For this and coroutines, I got help from unity documentation.
    /// </summary>
    /// <param name="originalMat"></param>
    /// <returns></returns>
    private IEnumerator DelayedLight(Material[] originalMat)
    {
        // waits for 1 second
        yield return new WaitForSeconds(1.0f);
        OriginalLight(originalMat);
    }


    // Start is called before the first frame update
    void Start()
    {
        // Finds all the light gameObjects at the start of the game
        first = GameObject.Find("Ocean Blue");
        second = GameObject.Find("Orange");
        third = GameObject.Find("Cyan");
        fourth = GameObject.Find("Purple");

    }


    // Update is called once per frame
    void Update()
    {
        // Constantly checks if the buttons are pressed in the correct order, which is indicated
        // when all the lights are green (correct)
        if ((buttonOrder[0] && buttonOrder[1] && buttonOrder[2] && buttonOrder[3]) == correct)
        {
            gameObject.SetActive(false);
        }
    }
}
