using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class ExitEsc : MonoBehaviour
    {
        public string sceneName = "Assets/Scenes/Menu.unity"; // �������� ����� ��� ��������

        void Update()
        {
            // ��������� ������� ������ Esc
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // ��������� ����� �� � ��������
                SceneManager.LoadScene(sceneName);
            }
        }

        public static int score = 100000;
    }
}
