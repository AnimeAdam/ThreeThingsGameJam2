using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandleAnimation : MonoBehaviour
{
    Animator anime;
    
    Vector2 posLastFrame;
    Vector2 posThisFrame;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetDirection(Vector3 dir)
    {
        if (dir.magnitude < 0.01f) return; // Ignore very small movements

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0)
                //WalkRight;
                anime.SetTrigger("walk_right");
            else
                anime.SetTrigger("walk_left");
        }
        else
        {
            if (dir.y > 0)
                anime.SetTrigger("walk_up");
            else
                anime.SetTrigger("walk_down");
        }
    }

}
