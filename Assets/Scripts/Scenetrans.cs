using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenetrans : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string playerTag = "Player";

    // This handles "Triggers" (Player walks OVER the object)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is the Player
        if (other.CompareTag(playerTag))
        {
            LoadScene();
        }
    }

    // This handles "Collisions" (Player bumps INTO a solid object)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("No scene name assigned to " + gameObject.name);
        }
    }
}