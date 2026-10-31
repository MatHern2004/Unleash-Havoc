using UnityEngine; // for Unity functions
using UnityEngine.SceneManagement; // For loading the scenes

public class MainMenu : MonoBehaviour
{

    // Music for winning
    [SerializeField] private AudioClip winMusic;
    void Start()
    {
        // Play the win sound when the scene loads
        SoundEffectsManager.instance.PlaySoundEffecsClip(winMusic, transform, 1f);
    }
    // main menu scene
    private int mainMenu = 0;
    // first level scene
    private int firstLevel = 1;
    // To load the first level
    public void PlayGame()
    {
        SceneManager.LoadScene(firstLevel);
    }
    // To quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    // When finshing the game allow for a retry
    public void RetryGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    // To return to the Main Menu
    public void BackToMenu()
    {
         SceneManager.LoadScene(mainMenu);
    }
}
