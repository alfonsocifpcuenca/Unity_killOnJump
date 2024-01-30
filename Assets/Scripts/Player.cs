using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jumpForce;

    private void Start()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HorizontalMove();
        JumpMove();
    }

    private void HorizontalMove()
    {
        var horizontalMove = Input.GetAxisRaw("Horizontal") * this.moveSpeed;

        var newVelocity = new Vector2(horizontalMove, rb2D.velocity.y);
        this.rb2D.velocity = newVelocity;
    }

    private void JumpMove()
    {
        if (Input.GetButtonDown("Jump"))
        {
            this.rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
