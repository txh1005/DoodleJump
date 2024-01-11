using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private TypePlat typePlat;
    private void Start()
    {
        switch (typePlat)
        {
            case TypePlat.Idle:
                break;
            case TypePlat.MoveUp:
                transform.DOMove(new Vector2(10, 0), 1).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
                break;
            case TypePlat.MoveDown:
                break;
            default:
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
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
        if (collision.gameObject.CompareTag("platform"))
        {
            Destroy(collision.gameObject);
        }
    }
}