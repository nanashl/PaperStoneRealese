using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        //Application.Quit();
        //var myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/scenes/Game.unity");
        SceneManager.LoadScene("Assets/scenes/Game.unity", LoadSceneMode.Single);
    }
}
