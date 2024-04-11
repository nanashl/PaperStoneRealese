using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public int value = 0;

    public int GetValueOfCard()
    {
        return value;
    }

    public void SetValue(int new_value)
    {
        value = new_value;  
    }
    public string GetSpriteName()
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }
    public void SetSprite(Sprite new_sprite)
    {
       gameObject.GetComponent<SpriteRenderer>().sprite = new_sprite;
    }

    public void ResetCard()
    {

        Sprite back = GameObject.Find("Deck").GetComponent<DeckScript>().GetCardBack();
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0;

    }
}
