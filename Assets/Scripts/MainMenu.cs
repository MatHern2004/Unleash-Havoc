using UnityEngine; // for Unity functions
using UnityEngine.SceneManagement; // For loading the scenes

public class MainMenu : MonoBehaviour
{
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
}
