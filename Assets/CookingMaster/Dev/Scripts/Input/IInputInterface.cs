using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputInterface 
{
    float GetAxisHorizontal();
    float GetAxisVertical();
    bool GetInteractButton();
}
