using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float damage;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void TakeForce(Vector2 dir)
    {
        Quaternion rotation = new Quaternion();
        
                
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, transform.forward);
        transform.rotation = Quaternion.Lerp (transform.rotation, rotation, 0.1f);

        transform.rotation = rotation;
        rb2d.velocity = dir;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerTankSetting>().TakeDamaga(damage);
            Destroy(gameObject);
        }
    }
}
