/* 
 Alexander Barnes 101086806
 GAME2014_A1_BARNES_ALEXANDER
 PLAYER_SCRIPT
 CURRENTLY NOT WORKING SCRIPT, WAS GOING TO USE TO CHANGE SCENE, EVENT SYSTEM DOESNT SEEM TO RESPOND TO INPUT EVENTS 
 LAST MODIFIED 10/4/2020
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("enter pressed");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("enter");
            Debug.Log("enter pressed");
        }
        if (Input.GetMouseButtonDown(1))
        {
            print("enter");
            Debug.Log("enter pressed");
        }
    }

    public void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("enter");
            Debug.Log("enter pressed");
        }
    }
}
