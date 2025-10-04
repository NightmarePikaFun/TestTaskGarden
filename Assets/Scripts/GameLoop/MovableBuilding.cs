using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBuilding : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    private int collisionCounter = 0;

    public void Place()
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

    private void OnDestroy()
    {
        Destroy(rb);
    }
}
