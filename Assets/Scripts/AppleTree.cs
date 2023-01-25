using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    //Prefab for apples
    public List<GameObject> applePrefabs;
    public float speed = 5f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.02f;
    public float appleDropDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject prefab = applePrefabs[Random.Range(0, applePrefabs.Count)];
        GameObject apple = Instantiate(prefab);
        apple.transform.position = transform.position;
        if (appleDropDelay > 0.18) //If the appledrop delay is greater than 0.28
        {
            appleDropDelay -= 0.01f; //Then Every time an apple falls, decrease the delay.
        }
        Invoke("DropApple", appleDropDelay);

        //If the tree speed positive increase by 0.25, otherwise decrease it by 0.25.
        if (speed > 0) 
        {
            speed += 0.25f; 
        } else {
            speed -= 0.25f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move Right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move Left
        } else if (Random.value < changeDirChance)
        {
            speed *= -1; //Change Direction
        }
    }
    private void FixedUpdate()
    {
      if (Random.value < changeDirChance)
        {
            speed *= -1; //Change Direction
        }
    }
}