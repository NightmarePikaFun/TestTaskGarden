using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBuilding : MonoBehaviour
{
    private int collisionCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Move(Vector3 moveVector)
    {
        transform.position += moveVector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        collisionCounter++;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCounter--;
        if (collisionCounter == 0)
            GetComponent<SpriteRenderer>().color = Color.white;
    }
}
