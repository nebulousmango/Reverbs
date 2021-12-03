using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb_Player;
    [SerializeField] float f_moveSpeed = 5;
    [SerializeField] float f_jumpHeight = 10;
    [SerializeField] KeyCode key_Jump;
    [SerializeField] string inputAxis;

    float f_horizontal;

    private void Update()
    {
        MovePlayer();
        JumpPlayer();
    }

    void MovePlayer()
    {
        f_horizontal = Input.GetAxisRaw(inputAxis);
        rb_Player.velocity = new Vector2(f_horizontal * f_moveSpeed, rb_Player.velocity.y);
    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown(key_Jump))
        {
            rb_Player.AddForce(Vector2.up * f_jumpHeight, ForceMode2D.Impulse);
        }
    }
}
