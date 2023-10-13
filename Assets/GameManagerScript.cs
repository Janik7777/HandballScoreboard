using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using TMPro; // Import the TMPro namespace
using static GameManagerScript;

public class GameManagerScript : MonoBehaviour
{

    public TextMeshProUGUI gameClockText;
    public TextMeshProUGUI pauseClockText;
    public TextMeshProUGUI homeScoreText;
    public TextMeshProUGUI guestScoreText;
    public TextMeshProUGUI homePenaltyText;
    public TextMeshProUGUI guestPenaltyText;

    public float maxTime = 60*60.0f;
    private bool isPaused = false;
    private float currentTime;

    public int homeScore = 0;
    public int guestScore = 0;

    [System.Serializable]
    public struct NumberPair
    {
        public int playerNumber;
        public float penaltyUntil;
    }

    public List<NumberPair> homePenalty = new List<NumberPair>();
    public List<NumberPair> guestPenalty = new List<NumberPair>();

    
    public InputField homeInputField; // Drag your InputField component here in the inspector

    public void add_home_penalty()
    {
        if (!string.IsNullOrEmpty(homeInputField.text))
        {
            int enteredNumber;

            if (int.TryParse(homeInputField.text, out enteredNumber))
            {
                // Successfully parsed the number
                Debug.Log("Entered number: " + enteredNumber);

                // TODO: Further processing or usage of the entered number
            }
            else
            {
                Debug.LogWarning("Invalid number entered.");
            }
        }
        else
        {
            Debug.LogWarning("No number entered.");
        }
    }

    /*public void AddNumberPair(int num1, float num2)
    {
        NumberPair newPair;
        newPair.playerNumber = num1;
        newPair.number2 = num2;

        numberPairs.Add(newPair);
        UpdateDisplay();
    }*/

    // Call this function to remove a number pair at a specific index
    /*public void RemoveNumberPairAt(int index)
    {
        if (index >= 0 && index < numberPairs.Count)
        {
            numberPairs.RemoveAt(index);
            UpdateDisplay();
        }
        else
        {
            Debug.LogWarning("Invalid index. Can't remove number pair.");
        }
    }*/

    /*private void UpdateDisplay()
    {
        displayText.text = "Number Pairs:\n";
        for (int i = 0; i < numberPairs.Count; i++)
        {
            displayText.text += (i + 1) + ". (" + numberPairs[i].number1 + ", " + numberPairs[i].number2 + ")\n";
        }
    }*/


    private void Start()
    {
        homeScoreText.text = homeScore.ToString();
        guestScoreText.text = guestScore.ToString();

        currentTime = 0f;
        UpdateClockDisplay();
    }

    private void Update()
    {
        if (!isPaused && currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            UpdateClockDisplay();
        }
    }

    private void UpdateClockDisplay()
    {
        int minutes = (int)(currentTime / 60);
        int seconds = (int)(currentTime % 60);

        gameClockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnMouseDown()
    {
        TogglePause();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
    }
    public void IncrementHomeScore()
    {
        homeScore++;
        homeScoreText.text = homeScore.ToString();

    }
    public void IncrementGuestScore()
    {
        guestScore++;
        guestScoreText.text = guestScore.ToString();
    }
}
