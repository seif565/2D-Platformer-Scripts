using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Parameters
    [SerializeField] float enemyMoveSpeed = 5.0f;
    [SerializeField] float waitTime = 2f;    
    [SerializeField] Transform castPoint;    
    float currentMoveSpeed;
    float movementDirection;
    

    // Cahced References
    [SerializeField] BoxCollider2D bodyCollider, terrainCollider;
    Rigidbody2D enemyRB;

    // Start is called before the first frame update
    void Start()
    {        
        currentMoveSpeed = enemyMoveSpeed;
        enemyRB = GetComponent<Rigidbody2D>();
        movementDirection = transform.localScale.x;
    }

    void Update()
    {
        //if (FindObjectsOfType<PlayerMovement>().Length != 0)
        //{
        //    float distance = Vector2.Distance(transform.position, FindObjectOfType<PlayerMovement>().transform.position);
        //    Debug.Log(canSeePlayer(distance));
            
        //}
    }

    void FixedUpdate()
    {        
        enemyRB.velocity = new Vector2(movementDirection * currentMoveSpeed, enemyRB.velocity.y);
    }
    
    /**bool canSeePlayer(float distance)
    {
        bool isVisible = false;
        float castDist = distance;
        Vector2 endPos = castPoint.position + Vector3.right * distance; // 
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Player"));
        if(hit.collider == null)
        {
            Debug.Log("err");
            isVisible = true;
        }
        return isVisible;
    }**/
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(WaitAndTurn());
    }
    private IEnumerator WaitAndTurn()
    {
        currentMoveSpeed = 0;
        yield return new WaitForSeconds(waitTime);
        currentMoveSpeed = enemyMoveSpeed;
        transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        movementDirection = transform.localScale.x;        
    }
}
