using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameClockScript : MonoBehaviour
{
    public float totalTime = 300.0f; // 5 minutes in seconds as an example
    private bool isPaused = false;
    private float timeLeft;

    public TextMeshProUGUI gameClockText; // Reference to the Game Over text UI element

    private void Start()
    {
        timeLeft = totalTime;
        UpdateClockDisplay();
    }

    private void Update()
    {
        if (!isPaused && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateClockDisplay();
        }
    }

    private void UpdateClockDisplay()
    {
        int minutes = (int)(timeLeft / 60);
        int seconds = (int)(timeLeft % 60);

        gameClockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnMouseDown()
    {
        TogglePause();
    }

    public void TogglePause()
    {
        Debug.Log("Pressed the button");
        isPaused = !isPaused;
    }
}
