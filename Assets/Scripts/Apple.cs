using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            if (gameObject.CompareTag("Poison")) //If a poison apple goes off the screen
            {
                //Do nothing            
            }
            else
            {
                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                apScript.AppleMissed();
            }
        }
    }
}
