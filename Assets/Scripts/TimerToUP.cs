using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.UIElements;
using UIButton = UnityEngine.UI.Button;


public class TimerToUP : MonoBehaviour
{
    public string filePath;

    public Text BalanceText;

    public TMP_InputField inputSumm1;
    public TMP_InputField inputSumm2;

    public TMP_InputField inputX1;
    public TMP_InputField inputX2;

    private float Bet1 = 0;
    private float Bet2 = 0;

    private float Xtap1 = 10000;
    private float Xtap2 = 10000;

    private bool Playing1 = false;
    private bool Playing2 = false;

    private bool MomentPrize1 = false;
    private bool MomentPrize2 = false;

    private bool AutoTap1 = false;
    private bool AutoTap2 = false;

    public UIButton buttonAuto1;
    public UIButton buttonAuto2;

    private bool changetimer = true;
    public Text textTimer;
    public Text textScore; 
    private float timer = 10f; // Таймер для отслеживания времени
    private float countdown = 0f; // Интервал для увеличения счетчика
    private float maxRandomValue = 4; // Максимальное значение для генерации случайного числа
    private float score = 0; // Счетчик
    public float increaseSpeed = 1f;
    private int cntWin = 0;

    void Update()
    {
        
        if (changetimer)
        {
            timer -= Time.deltaTime;
        }

        textTimer.text = "Time to play: " + timer.ToString("F2");

        if (timer <= countdown && changetimer)
        {
            if(cntWin > 7 ) { maxRandomValue = 15; cntWin = 0; }
            score = Random.Range(0f, maxRandomValue);
            Debug.Log("Счет: " + score);
            maxRandomValue = 4;
            StartCoroutine(IncreaseScoreSmoothly(score));
            
        }
    }

    public void BetOneTap()
    {
        string tmpBet = inputSumm1.text; //tut
        string tmpBalance = BalanceText.text;

        if(changetimer && float.Parse(tmpBet) < float.Parse(tmpBalance) && !Playing1)
        {
            Bet1 = float.Parse(tmpBet);
            float newbalance = float.Parse(tmpBalance) - float.Parse(tmpBet);
            BalanceText.text = newbalance.ToString();
            Playing1 = true;
        }
    }
    public void BetTwoTap()
    {
        string tmpBet = inputSumm2.text; //tut
        string tmpBalance = BalanceText.text;

        if (changetimer && float.Parse(tmpBet) < float.Parse(tmpBalance) && !Playing2)
        {
            Bet2 = float.Parse(tmpBet);
            float newbalance = float.Parse(tmpBalance) - float.Parse(tmpBet);
            BalanceText.text = newbalance.ToString();
            Playing2 = true;
        }
    }
    public void XOneTapAuto()
    {

        if (!AutoTap1)
        {
            
            string tmp23 = inputX1.text;
            Xtap1 = float.Parse(tmp23);
            Debug.Log(Xtap1 + " XTAP2");
            AutoTap1 = true;
            buttonAuto1.image.color = Color.green;

        }
        else
        {
            
            Xtap1 = 1000;
            Debug.Log(Xtap1 + " XTAP1");
            AutoTap1 = false;
            buttonAuto1.image.color = Color.red;
        }
    }

    public void XTwoTapAuto()
    {
        if (!AutoTap2)
        {
            string tmp23 = inputX2.text;
            Xtap2 = float.Parse(tmp23);
            Debug.Log(Xtap2 + " XTAP2");
            AutoTap2 = true;
            buttonAuto2.image.color = Color.green;
        }
        else
        {
            Xtap2 = 1000;
            Debug.Log(Xtap2 + " XTAP2");
            AutoTap2 = false;
            buttonAuto2.image.color = Color.red;
        }
    }

    public void XOneTapMoment()
    {
        if(Playing1 && !changetimer) 
        {
            MomentPrize1 = true;
        }
    }

    public void XTwoTapMoment()
    {
        if (Playing2 && !changetimer)
        {
            MomentPrize2 = true;
        }
    }

    IEnumerator IncreaseScoreSmoothly(float targetScore)
    {
        changetimer = false;
        float currentScore = 0;
        float elapsedTime = 0;

        while (currentScore < score)
        {
            elapsedTime += Time.deltaTime;
            currentScore = Mathf.Lerp(0, score, elapsedTime / (score * increaseSpeed));
            textScore.text = currentScore.ToString() + "x";
            if (Playing1 && BalanceText != null &&  Xtap1 <= currentScore && AutoTap1)
            {
                float tmp = float.Parse(BalanceText.text) + Xtap1 * Bet1;
                BalanceText.text = tmp.ToString();
                Playing1 = false;
            }
            if (Playing2 && BalanceText != null && Xtap2 <= currentScore && AutoTap2)
            {
                float tmp = float.Parse(BalanceText.text) + Xtap2 * Bet2;
                BalanceText.text = tmp.ToString();
                Playing2 = false;
            }
            if(Playing1 && MomentPrize1)
            {
                float tmp = float.Parse(BalanceText.text) + currentScore * Bet1;
                BalanceText.text = tmp.ToString();
                Playing1 = false;
                MomentPrize1 = false;
            }
            if (Playing2 && MomentPrize2)
            {
                float tmp = float.Parse(BalanceText.text) + currentScore * Bet2;
                BalanceText.text = tmp.ToString();
                Playing2 = false;
                MomentPrize2 = false;
            }

            yield return null;
        }

        currentScore = score;
        Debug.Log("Score reached: " + currentScore);
        textScore.text = currentScore.ToString() + "x";
        textScore.color = Color.red;
        yield return new WaitForSeconds(3f);
        textScore.text = "0x";
        textScore.color = Color.green;
        changetimer = true;
        Playing1 = false;
        Playing2 = false;

        MomentPrize1 = false;
        MomentPrize2 = false;

        Bet1 = 0;
        Bet2 = 0;

        File.WriteAllText(filePath, BalanceText.text);

        timer = 10f;
    }

}
