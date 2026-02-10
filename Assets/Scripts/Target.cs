using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //örnektir lütfen sorgulamayýnýz
    float can;

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized; // diyagonal hýz fix
    }

    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }
    public void buBirHasrFoksiyonu(int damage)
    {
        can -= damage;
    }
}
