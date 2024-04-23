using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct InputData 
{
    //Basic Movement
    public float hMovement;
    public float vMovement;
    
    //Mouse Rotation
    public float verticalMouse;
    public float horizontalMouse;
    
    //Extra Movement
    public bool dash;
    public bool jump;
    public bool roll;

    public void getInput()
    {
        //Basic Movement
        hMovement = Input.GetAxis("Horizontal");
        vMovement = Input.GetAxis("Vertical");
    
    //Mouse Rotation
    verticalMouse = Input.GetAxis("Mouse Y");
    horizontalMouse = Input.GetAxis("Mouse X");
    
    //Extra Movement
    dash = Input.GetButton("Dash");
    jump = Input.GetButtonDown("Jump");
    roll = Input.GetButtonDown("Roll");
    }

    public void resetInput()
    {
        hMovement = vMovement = verticalMouse = horizontalMouse = 0;

        dash = jump = roll = false;
    }
}

