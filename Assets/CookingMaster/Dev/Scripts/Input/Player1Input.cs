using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Input : IInputInterface
{
    public float GetAxisHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetAxisVertical()
    {
        return Input.GetAxis("Vertical");
    }

    public bool GetInteractButton()
    {
        return Input.GetKey(KeyCode.Space);
    }
}
