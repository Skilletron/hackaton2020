using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
            if(hitInfo.collider.CompareTag("Enemy")){
            hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            else if(hitInfo.collider.CompareTag("Boss")){
                hitInfo.collider.GetComponent<BossControl>().TakeDamage(damage);
            }
        Destroy(gameObject);

        }
        
    }
}
