using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Parameters
    [SerializeField] float enemyMoveSpeed = 5.0f;
    [SerializeField] float waitTime = 2f;    
    [SerializeField] Transform castPoint;
    [SerializeField] float horizontalDeathForce;
    [SerializeField] float verticalDeathForce;
    float currentMoveSpeed;
    float movementDirection;

    bool isDead = false;
        
    // Cahced References
    [SerializeField] BoxCollider2D bodyCollider, terrainCollider;
    Rigidbody2D enemyRB;
    Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {                
        enemyAnimator = GetComponent<Animator>();
        enemyAnimator.SetBool("isWalking", true);
        currentMoveSpeed = enemyMoveSpeed;
        enemyRB = GetComponent<Rigidbody2D>();
        movementDirection = transform.localScale.x;
    }

    void Update()
    {
        /**if (FindObjectsOfType<PlayerMovement>().Length != 0)
        {
            float distance = Vector2.Distance(transform.position, FindObjectOfType<PlayerMovement>().transform.position);
            Debug.Log(canSeePlayer(distance));
        }
        **/

    }

    void FixedUpdate()
    {                
        if(!isDead)
        enemyRB.velocity = new Vector2(movementDirection * currentMoveSpeed, enemyRB.velocity.y);
    }
    
    // Function That Detects the player (Being Tested)
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

    // Walk and wait cycle when touching 
    private IEnumerator WaitAndTurn()
    {
        currentMoveSpeed = 0;
        enemyAnimator.SetBool("isWalking", false);
        yield return new WaitForSeconds(waitTime);
        enemyAnimator.SetBool("isWalking", true);
        currentMoveSpeed = enemyMoveSpeed;
        transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        movementDirection = transform.localScale.x;        
    }

    // Changes enemy sprite, adds bouncy movement when dead and 
    public void HandleDeath(float playerHitDirection)
    {
        if (isDead) return;
            enemyAnimator.SetTrigger("Die");
            enemyRB.velocity = Vector2.zero;
            enemyRB.AddForce(new Vector2(horizontalDeathForce * playerHitDirection, 
                verticalDeathForce));
            Physics2D.IgnoreCollision(bodyCollider, FindObjectOfType<PlayerMovement>().playerCollider);        
            enemyRB.velocity = Vector2.zero;        
            isDead = true;
    }
}
