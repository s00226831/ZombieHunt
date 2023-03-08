using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    public int Damage = 10;
    public float MinMovementSpeed = 1;
    public float MaxMovementSpeed = 3;

    public float AttackRange = 3;
    GameObject Player;
    
    protected override void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        movementSpeed = Random.Range(MinMovementSpeed, MaxMovementSpeed);
        
        base.Start();
    }

   
    void Update()
    {
        if(Vector2.Distance(transform.position, Player.transform.position) < AttackRange)
        {
            SetState(CharacterState.Attack);

            transform.up = Player.transform.position - transform.position;
        }
        else
        {
            SetState(CharacterState.Idle);
        }
    }

    private void FixedUpdate()
    {
        if (State == CharacterState.Attack)
        {
            body.MovePosition(transform.position + transform.up.normalized * movementSpeed * Time.deltaTime);
        }
    }
}
