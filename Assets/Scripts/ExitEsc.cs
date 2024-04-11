using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class ExitEsc : MonoBehaviour
    {
        public string sceneName = "Assets/Scenes/Menu.unity"; // Название сцены для открытия

        void Update()
        {
            // Проверяем нажатие кнопки Esc
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Загружаем сцену по её названию
                SceneManager.LoadScene(sceneName);
            }
        }

        public static int score = 100000;
    }
}
