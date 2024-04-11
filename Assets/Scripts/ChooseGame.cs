using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class ChooseGame : MonoBehaviour
    {
        public void Roulett()
        {
            
            SceneManager.LoadScene("Assets/scenes/Game.unity", LoadSceneMode.Single);
        }
        public void BJ()
        {

            SceneManager.LoadScene("Assets/scenes/BlackJack.unity", LoadSceneMode.Single);
        }
        public void PRS()
        {

            SceneManager.LoadScene("Assets/scenes/Paper.unity", LoadSceneMode.Single);
        }
        public void Crash()
        {

            SceneManager.LoadScene("Assets/scenes/Crush.unity", LoadSceneMode.Single);
        }
    }
}
