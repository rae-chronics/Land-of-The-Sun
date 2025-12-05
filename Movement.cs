using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public SpriteRenderer spriteRenderer;   // Only one!

    private Vector3 direction;

    private void Awake()
    {
        // Auto-assign SpriteRenderer if you forgot to drag it in the inspector
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, vertical);
        AnimateMovement(direction);

        // --- FLIP SPRITE LEFT/RIGHT ---
        if (horizontal < 0)
            spriteRenderer.flipX = true;
        else if (horizontal > 0)
            spriteRenderer.flipX = false;
    }

    private void FixedUpdate()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}