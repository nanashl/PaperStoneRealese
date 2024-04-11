//Mitchell Sturbc 104750636
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRight : MonoBehaviour
{
    //used to move the characters
    private Vector3 pos;
    //used to transition from the running animation to the attack animation
    public Animator anim;

    //variables used to increment the computer and player scores.
    private Text playerScore;
    private Text CompScore;
    private int score;
    private int Escore;

    // Start is called before the first frame update
    void Start()
    {
        //getting the componoents
        GameObject PScore = GameObject.Find("PlayerScore");
        playerScore = PScore.GetComponent<Text>();

        GameObject EScore = GameObject.Find("CompScore");
        CompScore = EScore.GetComponent<Text>();

        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //move the character to the right
        pos = transform.position;
        pos.x += Time.deltaTime * 5.5f;
        transform.position = pos;

        //this is the point at which the player character and the computer character meet in the middle.
        if (pos.x > 0) Destroy(this.gameObject);
        if (pos.x > -2.2f)
        {
            anim.SetTrigger("AttackDistanceReached");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //assign the variables to the scors
        score = int.Parse(playerScore.text);
        Escore = int.Parse(CompScore.text);

        // I used colliders to handled the score increment the score and the logic follows usual rock paper scissors rules
        if (transform.name.Equals("Rock(Clone)") && collision.transform.name.Equals("EScissors(Clone)")) score++;
        if (transform.name.Equals("Paper(Clone)") && collision.transform.name.Equals("ComputerRock(Clone)")) score++;
        if (transform.name.Equals("Scissors(Clone)") && collision.transform.name.Equals("EPaper(Clone)")) score++;

        //This increments the computer score if it wins
        if (transform.name.Equals("Rock(Clone)") && collision.transform.name.Equals("EPaper(Clone)")) Escore++;
        if (transform.name.Equals("Paper(Clone)") && collision.transform.name.Equals("EScissors(Clone)")) Escore++;
        if (transform.name.Equals("Scissors(Clone)") && collision.transform.name.Equals("ComputerRock(Clone)")) Escore++;
       
        //destroy the characters in the middle when they collide
        Destroy(this.gameObject);
        Destroy(collision.gameObject);

        //reassign the text to the scores.
        playerScore.text = score.ToString();
        CompScore.text = Escore.ToString();
    }
}
