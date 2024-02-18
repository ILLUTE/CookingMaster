using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Input : IInputInterface
{
    public float GetAxisHorizontal()
    {
        return Input.GetAxis("Horizontal2");
    }

    public float GetAxisVertical()
    {
        return Input.GetAxis("Vertical2");
    }

    public bool GetInteractButton()
    {
        return Input.GetKeyDown(KeyCode.P);
    }
}
