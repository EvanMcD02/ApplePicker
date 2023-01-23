using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Enables UI

public class ScoreCounter : MonoBehaviour
{
    [Header("Dyanmic")]
    public int score = 0;
    private Text uIText;

    // Start is called before the first frame update
    void Start()
    {
        uIText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        uIText.text = score.ToString("#,0"); //This 0 is zero
    }
}
