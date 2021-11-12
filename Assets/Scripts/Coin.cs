using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int addedScore = 50;    
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LevelHandler>().AddScore(addedScore);
        Destroy(gameObject);
    }
}
