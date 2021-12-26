using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    public bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int numExtraJumps;

    private Rigidbody2D rb;

    void Start() {
        extraJumps = numExtraJumps;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        moveInput = Input.GetAxis("Horizontal");
        //Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); //

        if(facingRight == false && this.transform.position.x < mousePos.x){
          Flip();
        } else if(facingRight == true && this.transform.position.x > mousePos.x){
          Flip();
        }
    }

    void Update(){

      if(isGrounded == true){
        extraJumps = numExtraJumps;
      }
      if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0){
        rb.velocity = Vector2.up * jumpForce;
        extraJumps--;
      } else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true){
        rb.velocity = Vector2.up * jumpForce;
      }
    }

    void Flip(){

      facingRight = !facingRight;
      Vector3 Scaler = transform.localScale;
      Scaler.x *= -1;
      transform.localScale = Scaler;
    }
}
