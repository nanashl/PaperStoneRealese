using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class ButtonTap : MonoBehaviour
{
    public string newText = "HUI"; 

    public Text TextTEST; 

    public void ChangeText()
    {
        
        
            TextTEST.text = newText; // Изменение текста
        
        
    }
}
