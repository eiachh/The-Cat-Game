using Assets.Scripts.Providers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Visuals;
using Assets.Scripts.Characters;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;


    ICrewMember crewMember1;
    void Start()
    {
        crewMember1 = Factory.Instance.CreateCrewMember(new CharacterConfiguration { Name = "TestCrewMember" }, "SpottySus");
        
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


        if (Input.GetKey(KeyCode.I))
        {
            crewMember1.MoveUp();
        }

        else if (Input.GetKey(KeyCode.J))
        {
            crewMember1.MoveLeft();
        }
        else if (Input.GetKey(KeyCode.K))
        {
            crewMember1.MoveDown();
        }
        else if (Input.GetKey(KeyCode.L))
        {
            crewMember1.MoveRight();
        }

    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * MovementSpeed, moveDirection.y * MovementSpeed);
    }
}
