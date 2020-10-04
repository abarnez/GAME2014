/* 
 Alexander Barnes 101086806
 GAME2014_A1_BARNES_ALEXANDER
 BUTTON_MANAGER
 SCRIPT USED TO CHANGE SCENES AFTER BUTTON ONCLICK EVENT IS CALLED WITH PUBLIC STRING FIELD SO YOU CAN TYPE NAME OF SCENE YOU WANT
 IN EDITOR, CURRENTLY SET UP FOR ONLY TWO BUTTONS AS NONE OF MY SCENES HAVE MORE THAN 2 BUTTONS
 LAST MODIFIED 10/4/2020
 VERSION 1.0.0
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button StartButton;
    public Button InstructButton;
    public string scene1;
    public string scene2;
 
    void Start()
    {
        Button btn = StartButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Button btn2 = InstructButton.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);
    }
    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(scene1);
    }
    void TaskOnClick2()
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(scene2);
    }

}