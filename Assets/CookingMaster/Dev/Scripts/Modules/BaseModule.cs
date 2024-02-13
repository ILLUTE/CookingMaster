using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseModule : MonoBehaviour
{
    public abstract void Enter();
    public abstract void Exit();
    public abstract void ModuleUpdate(float dt);
    public abstract void Interact();
}
