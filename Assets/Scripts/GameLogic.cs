using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    private int randomNum;
    public InputField userInput;
    public Text text;
    public int min;
    public int max;
    public Button gameButton;
    public Button Restart;


    void Start()
    {
        restart();
        Restart.gameObject.SetActive(false);
    }

    void Update()
    {

    }
    public void restart()
    {
        gameButton.interactable = true;
        randomNum = GetRandomNumber(min, max);
        text.text = $"get number {min} to {max - 1}";
    }

    public void OnButtonClick()
    {

        string userInputValue = userInput.text;
        if (userInputValue != "")
        {
            int answer = int.Parse(userInputValue);

            if (answer == randomNum)
            {
                text.text = answer + " is correct";
                Debug.Log(answer + " is correct");
                gameButton.interactable = false;
                Restart.gameObject.SetActive(true);
            }
            else if (answer > randomNum)
            {
                text.text = "Try Lower!";
                Debug.Log("Try Lower!");
            }
            else
            {
                text.text = "Try Higher!";
                Debug.Log("Try Higher!");
            }

            userInput.text = "";
        }
        else
        {
            Debug.Log("Enter a number");
        }
    }

    private int GetRandomNumber(int min, int max)
    {
        int random = Random.Range(min, max);
        return random;
    }



}
