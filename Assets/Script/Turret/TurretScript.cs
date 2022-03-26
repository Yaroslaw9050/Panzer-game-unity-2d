using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private Transform target;
    [SerializeField] private Transform muzzle;
    [SerializeField] private GameObject bullestPrefab;
    private void Update()
    {
        if(target != null)
        {
            Rotate();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            target = other.transform;
            InvokeRepeating("Shoot",0.5f,1f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            target = null;
            CancelInvoke("Shoot");
        }
    }
    private void Rotate()
    {
        Quaternion rotation = new Quaternion();
        
        target.position = new Vector2(target.position.x, target.position.y);
        Vector2 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, transform.forward);
        transform.rotation = Quaternion.Lerp (transform.rotation, rotation, 0.1f);
    }
    private void Shoot()
    {
        GameObject temp = Instantiate(bullestPrefab, muzzle.transform.position, Quaternion.identity);
        Vector2 dir = target.position - transform.position;
        temp.GetComponent<BulletScript>().TakeForce(dir);
    }
    public void TakeDamaga(float value)
    {
        health -= value;
        if(health <= 0)
        {
            transform.parent.tag = "Untagged";
            Destroy(gameObject);
        }
    }
}
