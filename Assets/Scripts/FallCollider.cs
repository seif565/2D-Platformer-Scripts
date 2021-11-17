using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCollider : MonoBehaviour
{

    BoxCollider2D fallCollider;
    // Start is called before the first frame update
    void Start()
    {
        fallCollider = GetComponent<BoxCollider2D>();
    }

    // Destroys all objects and ends game if player collides
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            FindObjectOfType<LevelHandler>().HandleDeath();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
