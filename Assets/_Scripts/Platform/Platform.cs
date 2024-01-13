using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private TypePlat typePlat;
    [SerializeField] private float duration = 1;
    private BaseState selectState;
    private Dictionary<TypePlat, BaseState> stateDictionary;
    private void Start()
    {
        selectState = new MovePlatform();
        switch (typePlat)
        {
            case TypePlat.Idle:
                break;
            case TypePlat.MoveUp:
                selectState.MovePlatformUp(this.transform, duration);
                break;
            case TypePlat.MoveRight:
                selectState.MovePlatformRight(this.transform, duration);
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
    }
}