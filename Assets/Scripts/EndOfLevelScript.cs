using System;
using UnityEngine; // For Unity functions
using UnityEngine.SceneManagement;

public class EndOfLevelScript : MonoBehaviour
{
    // Next Scene
    private int secondLevel = 1;
    // Next Scene
    private int thirdLevel = 2;


    // Sound effect for beating the stage
    [SerializeField] private AudioClip winSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {  
            // Get the current name of the scene that the player is in
            String scene = SceneManager.GetActiveScene().name;
            switch (scene)
            {
                case "Level1":
                // Play the win sound effect
                SoundEffectsManager.instance.PlaySoundEffecsClip(winSound, transform, 1f);
                // Load the next level if we are on Level 1
                SceneManager.LoadScene(secondLevel);
                break;
                case "Level2":
                // Play the win sound effect
                SoundEffectsManager.instance.PlaySoundEffecsClip(winSound, transform, 1f);
                // Load the next level if we are on Level 1
                SceneManager.LoadScene(thirdLevel);
                break;
            }
            
        }
    }
}
