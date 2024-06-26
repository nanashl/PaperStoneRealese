using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
//using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;
using Scripts;
using System;

public enum GameChoices
{
    NONE,
    ROCK,
    PAPER,
    SCISSORS
}

public class GameplayController : MonoBehaviour
{

    [SerializeField]
    private Sprite rock_Sprite, paper_Sprite, scissor_Sprite;

    [SerializeField]
    private Image playerChoice_Img, opponentChoice_Img;

    [SerializeField]
    private Text infoText;

    [SerializeField]
    private Text Balance;

    [SerializeField]
    private Button Button;

    private GameChoices player_Choice = GameChoices.NONE, opponent_Choice = GameChoices.NONE;

    private AnimationController animationController;


    private void Awake()
    {
        Balance.text = Convert.ToString(ExitEsc.score);
        animationController = GetComponent<AnimationController>();
    }

    public void SetChoices(GameChoices gameChoices)
    {
        switch (gameChoices)
        {
            case GameChoices.ROCK:
                playerChoice_Img.sprite = rock_Sprite;

                player_Choice = GameChoices.ROCK;

                break;
            case GameChoices.PAPER:
                playerChoice_Img.sprite = paper_Sprite;

                player_Choice = GameChoices.PAPER;
                break;
            case GameChoices.SCISSORS:
                playerChoice_Img.sprite = scissor_Sprite;

                player_Choice = GameChoices.SCISSORS;
                break;
        }//switch / case

        SetOpponentChoice();

        DetermineWinner();
    }

    void SetOpponentChoice()
    {
        int rnd = UnityEngine.Random.Range(0, 3);
        switch (rnd)
        {
            case 0:

                opponent_Choice = GameChoices.ROCK;

                opponentChoice_Img.sprite = rock_Sprite;
                break;
            case 1:
                opponent_Choice = GameChoices.PAPER;

                opponentChoice_Img.sprite = paper_Sprite;
                break;
            case 2:
                opponent_Choice = GameChoices.SCISSORS;

                opponentChoice_Img.sprite = scissor_Sprite;
                break;
        }
    }

    void DetermineWinner()
    {

        if (player_Choice == opponent_Choice)
        {
            //draw
            infoText.text = "It's a Draw!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

        if (player_Choice == GameChoices.PAPER && opponent_Choice == GameChoices.ROCK)
        {
            //player won
            infoText.text = "You Win!";
            ExitEsc.score += 100;
            Balance.text = Convert.ToString(ExitEsc.score);
                        StartCoroutine(DisplayWinnerAndRestart());


            return;
        }

        if (opponent_Choice == GameChoices.PAPER && player_Choice == GameChoices.ROCK)
        {
            //player lose
            infoText.text = "You Lose!";
            ExitEsc.score -= 100;
            Balance.text = Convert.ToString(ExitEsc.score);
            StartCoroutine(DisplayWinnerAndRestart());
            return;
        }

        if (player_Choice == GameChoices.ROCK && opponent_Choice == GameChoices.SCISSORS)
        {
            //player won
            infoText.text = "You Win!";
            ExitEsc.score += 100;
            Balance.text = Convert.ToString(ExitEsc.score);
            StartCoroutine(DisplayWinnerAndRestart());


            return;
        }

        if (opponent_Choice == GameChoices.ROCK && player_Choice == GameChoices.SCISSORS)
        {
            //opponent won
            infoText.text = "You Lose!";
            ExitEsc.score -= 100;
            Balance.text = Convert.ToString(ExitEsc.score);
            StartCoroutine(DisplayWinnerAndRestart());


            return;
        }

        if (player_Choice == GameChoices.SCISSORS && opponent_Choice == GameChoices.PAPER)
        {
            //player won
            infoText.text = "You Win!";
            ExitEsc.score += 100;
            Balance.text = Convert.ToString(ExitEsc.score);
            StartCoroutine(DisplayWinnerAndRestart());


            return;
        }

        if (opponent_Choice == GameChoices.SCISSORS && player_Choice == GameChoices.PAPER)
        {
            //opponents won
            infoText.text = "You Lose!";
            ExitEsc.score -= 100;
            Balance.text = Convert.ToString(ExitEsc.score);
            StartCoroutine(DisplayWinnerAndRestart());


            return;
        }
    }

    IEnumerator DisplayWinnerAndRestart()
    {
        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(false);

        animationController.ResetAnimations();
    }

}//class






















