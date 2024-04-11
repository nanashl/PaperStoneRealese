//Mitchell Sturba 104750636
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
   
    public void PlayGame()
    {
        //loads the play sene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }

    public void QuitGame()
    {
        //quits the game
        Application.Quit();
    }
    public void BackToMenu()
    {
        //loads the previous scene. AKA the menu screen.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
