using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : Player
{
    private void Update()
    {
        if(Input.GetButtonDown("Pause Key"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
 