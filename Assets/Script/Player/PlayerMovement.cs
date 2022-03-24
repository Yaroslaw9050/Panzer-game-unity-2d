using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float tankFuil;
    [SerializeField] private float tankSpeed;
    private Rigidbody2D rb2d;
    private bool isMovement;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        tankFuil = 100;
        InvokeRepeating("EngineWorking", 0.5f, 1f);
    }
    private void Update()
    {
        Movement();
    }
    public void AddFuil(float value)
    {
        tankFuil += value;
        if (tankFuil > 100) tankFuil = 100;
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
    private void EngineWorking()
    {
        if(tankFuil >= 0)
        {
            if (rb2d.velocity != Vector2.zero)
            {
                tankFuil -= 2f;
            }
            else
            {
                tankFuil -= 0.5f;
            }
        }

    }
}
