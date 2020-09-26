using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{
    public float speed = 2;
    public Joystick joystick;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
        {
            if (joystick.Vertical > .5f)
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

            }
            else if (joystick.Vertical < .5f)
            {

                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }
}