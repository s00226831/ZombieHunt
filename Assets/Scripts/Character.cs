using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CharacterState
{
    Idle,
    Attack
}
public class Character : MonoBehaviour
{
    public CharacterState State;
    public Sprite IdleSprite;
    public Sprite AttackSprite;
    public float movementSpeed = 5;
    protected Rigidbody2D body;

    SpriteRenderer spriteRenderer;
    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        SetState(CharacterState.Idle);
    }
    public void SetState(CharacterState newState)
    {
        if (newState == CharacterState.Idle)
        {
            spriteRenderer.sprite = IdleSprite;
        }
        else if (newState == CharacterState.Attack)
        {
            spriteRenderer.sprite = AttackSprite;
        }

        State = newState;
    }
}
