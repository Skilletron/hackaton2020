using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    private GameObject player;
    public GameObject bul;

    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, lifetime);
    }
  
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null) {
            if(hitInfo.collider.CompareTag("Player")){
            hitInfo.collider.GetComponent<PlayerController>().TakeDamage(damage);
            }
        Destroy(gameObject);

        }
        
    }
}
