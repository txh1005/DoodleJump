using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEditor;
using static UnityEditorInternal.VersionControl.ListControl;

public class Platform : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float duration = 1;
    [SerializeField] private GameObject springPrefab;
    [SerializeField] private bool isSpring;
    [SerializeField] private bool isBroke;
    private IMovable movement;

    private GameObject listState;
    private void Awake()
    {
        listState = GameObject.Find("ListState");
    }
    private void Start()
    {/*
        listState.GetComponent<ListStatePlatform>().listState[];*/
        Random.Range(0, 2);
        movement = GetComponent<IMovable>();
        movement?.Move(transform, duration);
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
