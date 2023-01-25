using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }
    void OnCollisionEnter(Collision coll)
    {
        //Find out what hit the basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Poison")) //if its poison
        {
            Destroy(collidedWith); //destroy the apple, run the apple missed function.
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleMissed();
            //increase score
        }
        if (collidedWith.CompareTag("Apple")) //if its normal apple
        {
            Destroy(collidedWith); //increase score by 100
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            //increase score
        }
        if (collidedWith.CompareTag("Special")) //if its a special apple
        {
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.SpecialApple();
            Destroy(collidedWith);
            scoreCounter.score += 500;
        }
    }
}
