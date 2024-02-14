using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public List<Dish> m_Dishes = new();
    public CustomerController customer; // Yes, we can do multiple as well.
}
