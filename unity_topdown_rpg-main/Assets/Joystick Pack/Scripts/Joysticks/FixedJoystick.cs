using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJoystick : Joystick
{
    public float GetH()
    {
        return Horizontal;
    }

    public float GetV()
    {
        return Vertical;
    }
}