using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0)
        {
            Rigidbody2D rigid = collision.collider.GetComponent<Rigidbody2D>();
            if (rigid != null)
            {
                Vector2 velocity = rigid.velocity;
                velocity.y = jumpForce;
                rigid.velocity = velocity;
            }
        }
    }
}