//Mitchell Sturbc 104750636
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clickable : MonoBehaviour
{
    //RPS Prefabs
    public GameObject Rock;
    public GameObject Paper;
    public GameObject Scissors;

    //Enemy Prefabs
    public GameObject ERock;
    public GameObject EPaper;
    public GameObject EScissors;

    //games played, playerscore, and compscore texts
    private Text GamesPlayed;
    private Text playerScore;
    private Text CompScore;
    private int GamesPlayedInt;

    //either shows or hides the endscreen/playerscreen.
    public GameObject regularScreen;
    public GameObject EndScreen;

    //keeps track of the scores
    private int score;
    private int Escore;

    //used to display either player wins, computer wins, or tie
    public GameObject PWINS;
    public GameObject CWINS;
    public GameObject TIE;

    private int choice;
    // Start is called before the first frame update
    void Start()
    {
        GameObject GPlayed = GameObject.Find("GamesPlayed");
        GamesPlayed = GPlayed.GetComponent<Text>();
        GamesPlayed.text = "0";

        //getting the componoents
        GameObject PScore = GameObject.Find("PlayerScore");
        playerScore = PScore.GetComponent<Text>();

        GameObject EScore = GameObject.Find("CompScore");
        CompScore = EScore.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        GamesPlayedInt = int.Parse(GamesPlayed.text);

        choice = 0;
        if (GamesPlayedInt < 10)
        {
            if (tag.Equals("ChooseRockL"))
            {
                //if player chose rock than instantiate a rock at the left of the screen.
                Instantiate(Rock, new Vector3(-20f, -1f, 7.2f), transform.rotation);
                choice = 1;
                CompMove();
            }
            if (tag.Equals("ChoosePaperL"))
            {
                //if player chose Paper than instantiate a Paper at the left of the screen.
                Instantiate(Paper, new Vector3(-20f, -1f, 7.2f), transform.rotation);
                choice = 2;
                CompMove();
            }
            if (tag.Equals("ChooseScissorsL"))
            {
                //if player chose Scissors than instantiate a scissors at the left of the screen.
                Instantiate(Scissors, new Vector3(-20f, -1f, 7.2f), transform.rotation);
                choice = 3;
                CompMove();
            }
            GamesPlayedInt++; //up the games played
            GamesPlayed.text = GamesPlayedInt.ToString();
        }
        if (GamesPlayedInt >= 10f)
        {
            StartCoroutine(waitfoursecs()); //wait five seconds for last fight to go down to diaply winner.
        }
    }

    void CompMove()
    {
        int r = Random.Range(1,4); //chooses a random number for the computer to pick

        //based on the random decision, instantiate a rock paper or scissors.
        if (r == 1) Instantiate(ERock, new Vector3(20f, -1f, 7.2f), transform.rotation);
        else if (r == 2) Instantiate(EPaper, new Vector3(20f, -1f, 7.2f), transform.rotation);
        else if (r == 3) Instantiate(EScissors, new Vector3(20f, -1f, 7.2f), transform.rotation);
        
    }
    IEnumerator waitfoursecs()
    {
        //just waits four seconds
        yield return new WaitForSeconds(4f);
        displayEndScreen();
    }

    void displayEndScreen()
    {
        //displays endscreen
        EndScreen.SetActive(true);
        regularScreen.SetActive(false);

        score = int.Parse(playerScore.text);
        Escore = int.Parse(CompScore.text);

        //displays the appropriate titlescreen for the winner
        if (score > Escore) PWINS.SetActive(true);
        else if (score < Escore) CWINS.SetActive(true);
        else if (score == Escore) TIE.SetActive(true);
    }

    public void resetScore()
    {
        //if player hits play again this will run and just reload the scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}