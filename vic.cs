using UnityEngine;
using UnityEngine.SceneManagement;

public class vic : MonoBehaviour
{
    public GameObject victoryScreen; // Reference to the Victory Screen GameObject

    // Your other variables and methods for enemy behavior...

    public void EnemyDestroyed()
    {
        Debug.Log("Enemy destroyed. Loading 'vict' scene...");
        SceneManager.LoadScene("vict");
    }
}
