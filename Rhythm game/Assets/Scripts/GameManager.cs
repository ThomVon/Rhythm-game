using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This Script controlls when the music starts playing

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    //ints for the scoreboard and gaining points
    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    public int scoreTracker;

    //ints for the multiplier funktion for score
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierTresholds;

    //UI scoreboard elements
    public Text scoreText;
    public Text multiText;

    //Floats for the scoreboard
    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    //For the scoreboard
    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    //Score effects objects
    public GameObject firstEffect;
    public GameObject secondEffect;
    public GameObject thirdEffect;
    private bool scoreReached1 = true;
    private bool scoreReached2 = true;
    private bool scoreReached3 = true;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
         else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy && Time.timeScale != 0f)
            {
                resultsScreen.SetActive(true);

                normalsText.text = "" + normalHits;
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = "" + missedHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                //Scoreboard rating values
                string rankVal = "F";

                if(percentHit > 40)
                {
                    rankVal = "D";
                    if(percentHit > 55)
                    {
                        rankVal = "C";
                        if(percentHit > 70)
                        {
                            rankVal = "B";
                            if(percentHit > 85)
                            {
                                rankVal = "A";
                                if(percentHit > 95)
                                {
                                    rankVal = "S";
                                }
                            }
                        }
                    }
                }
                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();
            }
        }
        // Scoreboard effects code work
        if (currentScore > 10000 && scoreReached1 ==true)
            
        {
            effectScore1();
            scoreReached1 = false;
        }
        //
        if (currentScore > 20000 && scoreReached2 == true)

        {
            effectScore2();
            scoreReached2 = false;
        }
        //
        if (currentScore > 30000 && scoreReached3 == true)

        {
            effectScore3();
            scoreReached3 = false;
        }


    }
    //void for hitting the correct note
    public void NoteHit()
    {
        Debug.Log("Hit on time");

        //multiplier funktions
        if (currentMultiplier - 1 < multiplierTresholds.Length)
        {
            multiplierTracker++;

            if (multiplierTresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        //multiplier canvas
        multiText.text = "Multiplier: x" + currentMultiplier;
        //Score canvas
        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }
    //
    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        //scoreboard update
        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        //scoreboard update
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        //scoreboard update
        perfectHits++;
    }
    //void for missing notes
    public void NoteMiss()
    {
        Debug.Log("Missed Note");

        //reset your multiplier on a missed note
        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;

        //scoreboard update
        missedHits++;
    }
    //spawns first effect
    public void effectScore1()
    {
        Instantiate(firstEffect, transform.position = new Vector3(6, 6, 0), firstEffect.transform.rotation);
    }
    //spawns second effect
    public void effectScore2()
    {
        Instantiate(secondEffect, transform.position = new Vector3(-6, 6, 0), firstEffect.transform.rotation);
    }
    //spawns third effect
    public void effectScore3()
    {
        Instantiate(thirdEffect, transform.position = new Vector3(6, 6, 0), firstEffect.transform.rotation);
    }
}
