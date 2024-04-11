using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Button betBtn;


    private int standClicks = 0;

    public PlayerScript playerScript;
    public PlayerScript dealerScript;
    // Start is called before the first frame update

    public Text scoreText;

    public Text dealerScoreText;
    public Text betsText;
    public Text cashText;
    public Text mainText;
    public Text standBtnText;
    public GameObject hideCard;
    int pot = 0;
    void Start()
    {
        dealBtn.onClick.AddListener(() => DealClicled());
        hitBtn.onClick.AddListener(() => HitClicled());
        standBtn.onClick.AddListener(() => StandClicled());
        betBtn.onClick.AddListener(() => BetClicked());

    }
    private void DealClicled()
    {
        playerScript.ResetHand();
        dealerScript.ResetHand();
        mainText.gameObject.SetActive(false);
        dealerScoreText.gameObject.SetActive(false);
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();
        scoreText.text = "Hand: " + playerScript.handValue.ToString();
        dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();
        hideCard.GetComponent<Renderer>().enabled = true;
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "Stand";
        pot = 40;
        betsText.text = "Bets: $" + pot.ToString();
        playerScript.AdjustMoney(-20);
        cashText.text = "$" + playerScript.GetMoney().ToString();

    }
    private void HitClicled()
    {
        if (playerScript.cardIndex <= 10)
        {
            playerScript.GetCard();
            scoreText.text = "Hand: " + playerScript.handValue.ToString();
            if (playerScript.handValue > 20) RoundOver();
        }

    }



    private void StandClicled()
    {
        standClicks++;
        if (standClicks > 1) RoundOver();
        HitDealer();
        standBtnText.text = "Call";
    }

    private void HitDealer()
    {
        while (dealerScript.handValue < 17 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();
            if (dealerScript.handValue > 20) RoundOver();
        }
    }
    void RoundOver()
    {
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = playerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = playerScript.handValue == 21;

        if (standClicks < 2 && !playerBust && !dealerBust && !player21 && !dealer21) return;
        bool roundOver = true;
        if (playerBust && dealerBust)
        {
            mainText.text = "All Bust: Bets return";
            playerScript.AdjustMoney(pot / 2);
        }
        else if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            mainText.text = "Dealer wins!";
        }
        else if (dealerBust || dealerScript.handValue < playerScript.handValue)
        {
            mainText.text = "You win!";
            playerScript.AdjustMoney(pot);
        }
        else if (playerScript.handValue == dealerScript.handValue)
        {
            mainText.text = "Push: Bets returned";
        }
        else
        {
            roundOver = false;
        }
        if (roundOver)
        {
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(true);
            mainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Renderer>().enabled = false;
            cashText.text = "$" + playerScript.GetMoney().ToString();
            standClicks = 0;
        }
    }

    void BetClicked()
    {
        Text newBet = betBtn.GetComponentInChildren(typeof(Text)) as Text;
        playerScript.AdjustMoney(-20);
        cashText.text = "$" + playerScript.GetMoney().ToString();
        pot += (20 * 2);
        betsText.text = "Bets: $" + pot.ToString();
    }


    // Update is called once per fram
}
