using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandleAnimation : MonoBehaviour
{
    enum State
    {
        WalkLeft,
        WalkRight,
        WalkUp,
        WalkDown,
        AttackUp,
        AttackDown,
        AttackLeft,
        AttackRight,
        Die
    }
    private State currentState;
    Vector2 posLastFrame;
    Vector2 posThisFrame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posLastFrame = posThisFrame;

        posThisFrame = transform.position;

      currentState=  CheckMoveDirection();
    }

    private State CheckMoveDirection()
    {
        if (posThisFrame.x > posLastFrame.x)
            return State.WalkRight;
        if (posThisFrame.x < posLastFrame.x)
            return State.WalkRight;
        else
            return State.WalkRight;
    }

    public void ChangeMoveDirection(Vector2 direction)
    {

    }
}
