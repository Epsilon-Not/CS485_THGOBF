using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Switch statement to handle collisions with different objects
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly Collision");
                break;
            case "Finish":
                Debug.Log("Level Finished");
                break;
            case "Power Up":
                Debug.Log("Power Up Collision");
                break;
            case "Hazard":
                ReloadLevel();
                break;
            default:
                break;

        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}