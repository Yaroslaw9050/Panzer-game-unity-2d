using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float tankSpeed;
    private Rigidbody2D rb2d;
    private bool isMovement;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb2d.velocity = transform.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb2d.velocity = -transform.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.MoveRotation(rb2d.rotation + 1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.MoveRotation(rb2d.rotation - 1f);
        }
    }
}
