using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ActionType{
    Left,
    Right,
    Jump
}

public abstract class CharactorBase : MonoBehaviour
{
    public Animator animator;  
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2d;
    public float jumpForce;
    public float speed;
    public bool groundCheck;
    
    public abstract void Init();
    public abstract void Hit();

    public virtual void Die()
    {

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(ActionType.Left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(ActionType.Right);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Move(ActionType.Jump);
        }
        if(!Input.anyKey)
        {
            rigidbody2d.velocity = new Vector2(0,rigidbody2d.velocity.y);
            animator.Play("Idle");

        }
    }
    public virtual void Move(ActionType actionTypeParam)
    {
        if (!groundCheck)
        {
            return;
        }
        switch(actionTypeParam)
        {
            case ActionType.Left:
                rigidbody2d.velocity = new Vector2(-speed, rigidbody2d.velocity.y);
                spriteRenderer.transform.localScale = new Vector3(-1, 1, 1);
                animator.Play("Move");
                break;
            case ActionType.Right:
                rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
                spriteRenderer.transform.localScale = new Vector3(1, 1, 1);
                animator.Play("Move");
                break;
            case ActionType.Jump:
                animator.Play("Jump");
                rigidbody2d.AddForce(new Vector2(rigidbody2d.velocity.x, 2 * jumpForce));
                    
               
                break;
        }
    }
}
