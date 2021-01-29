using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private int playerScore;
    public Text scoreText;
    public int defaultLineValue = 100;
    public int scoreDif;
    public int scoreDifMultiplier = 5; // If score has increased 5 times

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        scoreDif = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerScore.ToString();
    }

    public int PlayerScore {
        get => playerScore;
        set { playerScore = value; }
    }

    public void IncreaseScore() {
       
        playerScore += defaultLineValue * FindObjectOfType<Level>().PlayerLevel;
    }

}
