using UnityEngine;
using UnityEngine.SceneManagement; // Required for switching scenes

public class Scenechange : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    void Update()
    {
        // Check if the 'P' key was pressed this frame
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        // Check if a scene name was actually provided
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene name is empty! Please assign a scene in the Inspector.");
        }
    }
}