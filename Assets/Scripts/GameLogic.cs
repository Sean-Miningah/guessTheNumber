using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

    public InputField userInput;
    public Text gameLabel;
    public int minValue;
    public int maxValue;
    public Button gameButton;
    private bool isGameWon=false;
    private int randomNum;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        if (isGameWon)
        {
            gameLabel.text = $"You Won! Guess a number between {minValue} and "+ (maxValue - 1);
            isGameWon = false;
        }
        else 
        {
            gameLabel.text = $"Guess a number between {minValue} and "+ (maxValue - 1);

        }
        userInput.text= "";
        randomNum = GetRandomNumber(minValue,maxValue);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonClick()
    {
        string userInputValue = userInput.text; 


        // Check if the user input value is an empty string

        if(userInputValue != "")
        {

            // converts string to integer
            int answer = int.Parse(userInputValue);

            if(answer == randomNum)
            {
                gameLabel.text = "correct";
                // gameButton.interactable = false;
                isGameWon = true;
                ResetGame();
                Debug.Log("Correct!");
            }
            else if(answer > randomNum)
            {
                gameLabel.text = "Try Lower";
                Debug.Log("Try Lower!");
            }
            else
            {
                gameLabel.text = "Try Higher";
                Debug.Log("Try Higher!");
            }
        }
        else
        {
            gameLabel.text = "Please enter a number";
            Debug.Log("Please enter a number!");
        }
        
    }

    private int GetRandomNumber(int min, int max)
    {
        int random = Random.Range(min, max);

        return random;
    }
}
