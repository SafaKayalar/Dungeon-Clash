using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isDashing)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = movement.normalized;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && movement != Vector2.zero && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = movement * moveSpeed;
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        rb.velocity = movement * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
    }
}

