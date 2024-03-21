using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementSC : MonoBehaviour
{
    private float horizontal;
    public float playerSpeed = 5f;
    public float jumpForce = 16f;
    private bool isFacingRight = true,isCrouch=false;
    private bool doubleJump,isDoubleJumped;
    private CapsuleCollider2D colliderPlayer;
    public Vector2 crouchSizeCollider;
    private Vector2 startSizeCollider;
    public Vector2 crouchOffset;
    private Vector2 startOffset;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private VariablesSC change_global_variable;

    private void Awake()
    {
        colliderPlayer= GetComponent<CapsuleCollider2D>();
        startSizeCollider = colliderPlayer.size;
        startOffset = colliderPlayer.offset;
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        change_global_variable.player.isCrouch = isCrouch;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.C) && !isCrouch)
        {   // eðer karakter boyutu saçma bir hal alýyor ise 35. satýr silinebilir.
            
            colliderPlayer.size = crouchSizeCollider;
            colliderPlayer.offset = crouchOffset;
            isCrouch=true;
        }
        else if(Input.GetKeyDown(KeyCode.C)  && isCrouch) 
        {
            colliderPlayer.size = startSizeCollider;
            colliderPlayer.offset = startOffset;
            isCrouch=false;
        }

        if(isGrounded()&& !Input.GetButton("Jump"))
        {
            doubleJump = false;
            isDoubleJumped= false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if(isGrounded()|| doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = !doubleJump;
                if (!doubleJump)
                {
                    isDoubleJumped = true;
                }
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        change_global_variable.player.doubleJump = isDoubleJumped;
        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * playerSpeed, rb.velocity.y);

    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void OnDrawGizmos()// gismos çizgileri için kullanýlýr.
    {
        Gizmos.DrawWireCube(transform.position+(Vector3)crouchOffset, crouchSizeCollider);
        
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x = localScale.x * -1f;
            transform.localScale = localScale;
        }
    }
}
