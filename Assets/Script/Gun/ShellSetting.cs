using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShellSetting : MonoBehaviour
{
    [SerializeField] private float shellSpeed;
    [SerializeField] private int shellDamage;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb2d.AddForce(transform.up * shellSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Fuil"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Turret"))
        {
            collision.GetComponentInChildren<TurretScript>().TakeDamaga(shellDamage);
            Destroy(gameObject);
        }
    }

}
