using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    public Text levelText;
    private int levelLimit = 8;

    public int PlayerLevel {
        get; set;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level: " + PlayerLevel;

        UpdateLevelByScore();

    }

    void IncreaseLevel() { // Increases Level and increase the Tetrominoe's falling speed;
        if(PlayerLevel < levelLimit) {
            PlayerLevel++;
            FindObjectOfType<TetrisBlock>().fallTime -= 0.1f;

        }
    }

    void UpdateLevelByScore() {
        Score score = FindObjectOfType<Score>();

        if (score.scoreDif >= score.defaultLineValue * score.scoreDifMultiplier) {
            IncreaseLevel();
            score.scoreDif = 0;
        }

    }

}
