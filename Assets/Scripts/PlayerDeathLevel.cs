using System; // For Strings
using UnityEngine; // For Unity Functions
using UnityEngine.SceneManagement; // For the scene management

public class PlayerDeathLevel : MonoBehaviour
{
    // Fall off noise
    [SerializeField] private AudioClip fallOffSound;
    // First Scene
    private int firstLevel = 1;
    // Next Scene
    private int secondLevel = 2;
    // Next Scene
    private int thirdLevel = 3;
    // Next Scene
    private int winScreen = 4;
    // String for obtaining the current Scene;
    private String scene;

    // If the player touches the death barrier, restart the level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Play sound when falling off
            SoundEffectsManager.instance.PlaySoundEffecsClip(fallOffSound, transform, 1f);
            // If the death barrier is touched, restart the level
            scene = SceneManager.GetActiveScene().name;
            // Update scene depending on the one the player is loaded into
            switch (scene)
            {
                case "Level1":
                SceneManager.LoadScene(firstLevel);
                SoundEffectsManager.instance.PlaySoundEffecsClip(fallOffSound, transform, 1f);
                break;
                case "Level2":
                SceneManager.LoadScene(secondLevel);
                SoundEffectsManager.instance.PlaySoundEffecsClip(fallOffSound, transform, 1f);
                break;
                case "Level3":
                SceneManager.LoadScene(thirdLevel);
                SoundEffectsManager.instance.PlaySoundEffecsClip(fallOffSound, transform, 1f);
                break;
                default:
                Debug.Log("Error no scene available");
                break;
            }
        }
    }
}
