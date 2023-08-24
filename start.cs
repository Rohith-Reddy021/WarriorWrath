using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button startButton; // Reference to the UI Button

    private void Start()
    {
        // Attach a method to the button's click event
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        // Load the game scene when the button is clicked
        SceneManager.LoadScene("SampleScene"); // Replace "GameScene" with the actual name of your game scene
    }
}
