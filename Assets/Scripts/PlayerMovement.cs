using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement :  MonoBehaviour
{

    // Properties
    [Header("Movement Attributes")]    
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float attackCD = 2f;    
    [SerializeField] float dodgeForce = 500f;
    [SerializeField] float pushForce = 23;

    [Header("Timers")]
    [SerializeField] float dodgeCD = 0.3f;
    [SerializeField] float invincibilityTime = 0.3f;

    [Header("Serialized Components")]
    [SerializeField] BoxCollider2D swordHitBox;
    
    float movementDirection;
    float timeToAttack;
    float timeToDodge;
    bool isGrounded = true;

    // References
    Rigidbody2D playerRB;
    CapsuleCollider2D playerCollider;
    Animator playerAnimator;        

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        playerAnimator = GetComponent<Animator>();
        timeToAttack = 1f;        
    }

    // Update is called once per frame
    void Update()
    {        
        if (timeToAttack > 0) { timeToAttack -= Time.deltaTime; }

        if (timeToDodge > 0) { timeToDodge -= Time.deltaTime; }

        // Movement direction and grounded check
        movementDirection = Input.GetAxisRaw("Horizontal");
        isGrounded = playerCollider.IsTouchingLayers(LayerMask.GetMask(LayerMask.LayerToName(6)));
        
        // Animation state check
        playerAnimator.SetBool("isGrounded", isGrounded);
        playerAnimator.SetBool("isRunning", movementDirection!= 0 && isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRB.AddForce(new Vector2(0, jumpForce));
        }

        if (movementDirection != 0) { transform.localScale = new Vector3(movementDirection, 1, 1); }

        if (Input.GetButtonDown("Attack") && timeToAttack <= 0)
        {
            StartCoroutine(Attack());
        }

        //if (Input.GetKeyDown(KeyCode.F)){
        //    Time.timeScale = 0;
        //}


        if (Input.GetButtonDown("Evade") && timeToDodge <= 0)
        {
            StartCoroutine(Dodge());
        }        
    }

    public IEnumerator Dodge()
    {
        gameObject.layer = 8;
        playerRB.AddForce(new Vector2(dodgeForce * transform.localScale.x, 0));
        playerAnimator.SetTrigger("Dodge");        
        timeToDodge = dodgeCD;
        yield return new WaitForSeconds(invincibilityTime);
        gameObject.layer = 3;
    }
   
 

    public IEnumerator Attack()
    {
        playerAnimator.SetTrigger("Attack");
        timeToAttack = attackCD;
        swordHitBox.enabled = true;
        Debug.Log("enabled");
        yield return new WaitForSeconds(0.15f);
        Debug.Log("disabled");
        swordHitBox.enabled= false;
    }

    private void FixedUpdate()
    {

        playerRB.velocity = new Vector2(moveSpeed * movementDirection, playerRB.velocity.y);        
        //Debug.Log(playerRB.velocity.x);
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Player Collision Detection

        // Sword Hit Detection
        if (swordHitBox.IsTouching(collision))
        {            
            if(collision.gameObject.layer == 7)
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("Player Hit Something");
        if (collision.gameObject.layer == 7)
        {
            playerRB.AddForce(new Vector2(- transform.localScale.x * pushForce, 0));
            FindObjectOfType<LevelHandler>().HandleHit();
        }
    }
}
