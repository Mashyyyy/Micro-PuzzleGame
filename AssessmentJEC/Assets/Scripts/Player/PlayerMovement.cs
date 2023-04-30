using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Animator p_anim;
    public Rigidbody2D rb2d;

    [SerializeField] private SpriteRenderer sp2d;
    Vector2 movement;

    [SerializeField] private AudioSource p_walk;
    [SerializeField] private AudioClip walk;

    public bool inDialog = false;
    public bool finished = false;

    // 0 = down , 1 = up, side = 2
    float facing = 0f;

    private void Update()
    {

        if(!inDialog && !finished)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }

        if(movement.x < 0)
        {
            sp2d.flipX = false;
        }
        else if(movement.x > 0)
        {
            sp2d.flipX = true;
            facing = 1;
        }

        if(movement.x != 0 || movement.y != 0)
        {
            if(!p_walk.isPlaying)
                p_walk.PlayOneShot(walk, 0.7f);
        }
        else
        {
            p_walk.Stop();
        }


        CheckFacing();

        p_anim.SetFloat("Horizontal", movement.x);
        p_anim.SetFloat("Vertical", movement.y);
        p_anim.SetFloat("Speed", movement.sqrMagnitude);
        p_anim.SetFloat("Facing", facing);
    }

    private void CheckFacing()
    {
        if(movement.x < 0) //facing left
        {
            facing = 1;
        }


        if(movement.y > 0) //facing up
        {
            facing = 2;
        }
        else if(movement.y < 0) //facing down
        {
            facing = 0;
        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement.normalized * _moveSpeed * Time.fixedDeltaTime);
    }
}