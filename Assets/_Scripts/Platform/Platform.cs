using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEditor;
using static UnityEditorInternal.VersionControl.ListControl;
using System;

public class Platform : MonoBehaviour
{
    public static event Action OnScoreChanged;
    [SerializeField] private float jumpForce;
    [SerializeField] private float duration = 1;
    [SerializeField] private GameObject springPrefab;
    [SerializeField] private bool isSpring;
    private IMovable movement;

    private GameObject listState;
    private void Awake()
    {
        listState = GameObject.Find("ListState");
    }
    private void Start()
    {/*
        listState.GetComponent<ListStatePlatform>().listState[];*/
        movement = GetComponent<IMovable>();
        movement?.Move(transform, duration);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (collision.relativeVelocity.y <= 0)
            {
                OnScoreChanged?.Invoke();
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
