using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Components
    [SerializeField]
    private Animator ani;
    [SerializeField]
    private Rigidbody2D rb;

    // Movement Variables
    private Vector2 InputDirection;
    private int Direction;
    [SerializeField, Range(0, 10)]
    private float Speed;

    // Health data
    [SerializeField]
    private int Health = 100;
    private float HitTimer = 0.5f;
    private float TimeUntilNextHit = 0;

    private void Update()
    {
        // Get user inputs
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        InputDirection = new Vector2(inputX, inputY);
        InputDirection.Normalize();

        // Update animator
        ani.SetFloat("Horizontal", inputX);
        ani.SetFloat("Vertical", inputY);
        ani.SetFloat("Movement", InputDirection.magnitude);

        // Updating the player's direction
        if (InputDirection.x > 0)
        {
            Direction = 0; // right
        }
        else if (InputDirection.x < 0)
        {
            Direction = 2; // left
        }
        else if (InputDirection.y > 0)
        {
            Direction = 1;
        }
        else if (InputDirection.y < 0)
        {
            Direction = 3;
        }
        ani.SetInteger("Direction", Direction);

        // Sending direction to inventory to rotate weapon
        GetComponentInChildren<Inventory>().SetDirection(Direction);

        // i-frames for being hit
        if (TimeUntilNextHit > 0f)
        {
            TimeUntilNextHit -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + InputDirection * Speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        if (TimeUntilNextHit <= 0)
        {
            Health -= damage;
            Debug.LogWarning("Took damage!");
            TimeUntilNextHit = HitTimer;
        }
        if (Health <= 0)
        {
            Debug.LogError("Player is dead!");
            Destroy(gameObject);
        }
    }
}
