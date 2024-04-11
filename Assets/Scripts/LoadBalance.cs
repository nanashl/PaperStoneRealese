using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadBalance : MonoBehaviour
{
    public Text BalanceText;
    public string filePath;

    void Start()
    {
        if (File.Exists(filePath))
        {
            string textFromFile = File.ReadAllText(filePath);
            BalanceText.text = textFromFile;
        }
        else
        {
            Debug.LogWarning("Файл не найден: " + filePath);
        }
    }
}
