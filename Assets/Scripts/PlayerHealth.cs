using System;
using System.Threading.Tasks;
using TMPro; // For TextMeshPro
using Unity.VisualScripting;
using UnityEngine; // For using Unity functions
using UnityEngine.SceneManagement; // For Unity SceneManagement

public class PlayerHealth : MonoBehaviour
{
    // Health of the player
    [SerializeField] private int health = 3;
    // Invincibility Frames
    [SerializeField] private float invincibilityTime = 5.0f;
    // Sound for when an enemy hits the player
    [SerializeField] private AudioClip enemyHitPlayerSound;
    // TextMeshProEdit
    [SerializeField] private TextMeshProUGUI healthText;
    // Actual Invincibility Until
    private float invincibleUntil;
    // Invinsibility alpha value
    private SpriteRenderer flashing;
    // private flash count
    private int flashCount = 3;
    // EnemyMovement script for its Type
    EnemyMovement enemyName;
    // Beginning Scene
    private int firstLevel = 0;
    // Next Scene
    private int secondLevel = 1;
    // Next scene
    private int thirdLevel = 2;
    // To get the name of the scene
    private String scene;
    // color for changing alpha
    private Color color;

    private void Awake()
    {
        flashing = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        // If the player health is less than one
        if (health < 1)
        {
            scene = SceneManager.GetActiveScene().name;
            // Update scene depending on the one the player is loaded into
            switch (scene)
            {
                case "Level1":
                SceneManager.LoadScene(firstLevel);
                break;
                case "Level2":
                SceneManager.LoadScene(secondLevel);
                break;
                case "Level3":
                SceneManager.LoadScene(thirdLevel);
                break;
                default:
                Debug.Log("Error no scene available");
                break;
            }
        }
    }
        

    public void TakeDamage(String enemyType)
    {
        // If the enemyType is basic and the invincibilityTime is less than the current time, allow for damage by 1
        if (enemyType == "Basic" && Time.time > invincibleUntil)
        {
            // Remove one health point from the player
            health -= 1;
            // Update the text above the player
            UpdateHealthText();
            // Play the sound of the enemy hitting the player
            SoundEffectsManager.instance.PlaySoundEffecsClip(enemyHitPlayerSound, transform, 1f);
            // Give them some invinsibility time
            invincibleUntil = invincibilityTime + Time.time;
            
        }
          // If the enemyType is basic and the invincibilityTime is less than the current time, allow for damage by 1
        else if (enemyType == "Big" && Time.time > invincibleUntil)
        {
            // Remove one health point from the player
            health -= 2;
            // Update the text above the player
            UpdateHealthText();
             // Play the sound of the enemy hitting the player
            SoundEffectsManager.instance.PlaySoundEffecsClip(enemyHitPlayerSound, transform, 1f);
            // Give them some invinsibility time
            invincibleUntil = invincibilityTime + Time.time;
        }
    }

    // Function to modify the TextMeshProText
    private void UpdateHealthText()
    {
        // Update the health
        healthText.text = "Health: " + health;
    }
}
