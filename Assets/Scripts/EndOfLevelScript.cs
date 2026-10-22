using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelScript : MonoBehaviour
{
    // SceneManager class to load the next level
    private SceneManager nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("You've beat the level!");
        }
    }
}
