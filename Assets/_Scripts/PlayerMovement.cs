using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    // Start is called before the first frame update
    private void OnValidate()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(horizontal * speed, rigid.velocity.y);
    }
}
