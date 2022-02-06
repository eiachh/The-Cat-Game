using Assets.Scripts.Providers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Visuals;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    public GameObject skinnableTarget;
    public GameObject skinnableTarget2;

    void Start()
    {
        var skin = Factory.Instance.SkinProvider.GetSkin("SpottySus");
        skin.ApplySkin(skinnableTarget);
        skin.ApplySkin(skinnableTarget2);


        skin.SetRenderLayer(skinnableTarget, RenderLayerCollection.Effect);
        skin.SetRenderLayer(skinnableTarget2, RenderLayerCollection.Important);
    }


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;


        if (Input.GetKey(KeyCode.T))
        {
            var animator = skinnableTarget.GetComponent<Animator>();
            animator.SetInteger("Horizontal", -1);
            animator.SetInteger("Vertical", 0);
        }

        if (Input.GetKey(KeyCode.R))
        {
            var animator = skinnableTarget2.GetComponent<Animator>();
            animator.SetInteger("Horizontal", 0);
            animator.SetInteger("Vertical", 1);
        }

    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * MovementSpeed, moveDirection.y * MovementSpeed);
    }
}
