using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public float health;
    public float checkRadius;
    public float dashForce;
    public float startDashTimer;
    private float currentDashTimer;
    private float dashDirection;
    public float dashSpeed;
    public float flashDistance;

    private int extraJumps;
    public int extraJumpValue;
    private int dashCount;
    public int dashCountValue;
    private int flashCount;
    public int flashCountValue;

    private bool isGrounded;
    private bool isAirbourne;
    private bool isDashing;
    private bool isLeft;

    public LayerMask floor;

    public Transform floorCheck;

    private Rigidbody2D rb;

    private Enemy enemy;

    void Start()
    {
        flashCount = flashCountValue;
        dashCount = dashCountValue;
        extraJumps = extraJumpValue;
        isLeft = false;
        isGrounded = true;
        isDashing = false;
        isAirbourne = false;
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }
        

    void Update()
    {
        if (transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }
        isGrounded = Physics2D.OverlapCircle(floorCheck.position, checkRadius, floor);

        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * movementSpeed * Time.deltaTime;

        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }

        if (isGrounded == true)
        {
            dashCount = dashCountValue;
            extraJumps = extraJumpValue;
            flashCount = flashCountValue;
        }
        //Jumping Movement
        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {   
            isAirbourne = true;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            extraJumps--;
            IsInAir();
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {
            isAirbourne = true;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            IsInAir();
        }
        //Dashing Movement
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isGrounded && dashCount > 0 && movement != 0)
        {
            isDashing = true;
            currentDashTimer = startDashTimer;
            rb.velocity = new Vector2(dashSpeed, 0);
            dashDirection = transform.rotation.eulerAngles.y;
            dashCount--;
        }
        if (isDashing && transform.rotation == Quaternion.Euler(0, 180,0))
        {
            rb.velocity = -transform.right * dashForce;
            currentDashTimer -= Time.deltaTime;

            if (currentDashTimer <= 0 )
            {
                isDashing = false;
            }
        }
        else if (isDashing)
        {
            rb.velocity = -transform.right * dashForce;
            currentDashTimer -= Time.deltaTime;

            if (currentDashTimer <= 0 )
            {
                isDashing = false;
            }
        }
        //Flashing Movement
        if (Input.GetKeyDown(KeyCode.LeftControl) && isLeft == true && flashCount > 0)
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(transform.position.x - flashDistance, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && isLeft == false && flashCount > 0)
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(transform.position.x + flashDistance, transform.position.y, transform.position.z);
        }
    }

    IEnumerator IsInAir() 
    {
        isAirbourne = false;
        yield return new WaitForSeconds(2);
    }

    /*public void DoubleJump() 
    {
        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            isAirbourne = true;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            extraJumps--;
            IsInAir();
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {
            isAirbourne = true;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            IsInAir();
        }
    }*/

    
}
