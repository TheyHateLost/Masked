using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLobbyScene : MonoBehaviour
{
    public string NewScene;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(NewScene);
            Debug.Log(NewScene);
        }
    }
}