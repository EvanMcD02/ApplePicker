using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _SCORE = 1000;
    private Text txtCom;
    // Start is called before the first frame update
    private void Awake()
    {
        _UI_TEXT = GetComponent<Text>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", SCORE);
    }
    static public int SCORE
    {
        get { return _SCORE; }
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }
    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }
    [Tooltip("Check this box to reset the highscore!")]
    public bool ResetHighScoreNow = false;

    void OnDrawGizmos()
    {
        if (ResetHighScoreNow)
        {
            ResetHighScoreNow = false;
            PlayerPrefs.SetInt("High Score", 1000);
            Debug.LogWarning("Player Prefs High Score Set to 1000");
        }
    }
}
