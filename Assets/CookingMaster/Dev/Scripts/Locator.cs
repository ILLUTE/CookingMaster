using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour
{
    private static Locator instance;
    public static Locator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Locator>();

                if (instance == null)
                {
                    GameObject go = new();
                    instance = go.AddComponent<Locator>();
                }
            }

            return instance;
        }
    }

    private CustomerHandler _customerHandler;
    public CustomerHandler CustomerHandlerInstance
    {
        get
        {
            if (_customerHandler == null)
            {
                _customerHandler = FindObjectOfType<CustomerHandler>();
            }

            return _customerHandler;
        }
    }

    private ResourceManager _resourceManager;
    public ResourceManager ResourceManagerInstance
    {
        get
        {
            if (_resourceManager == null)
            {
                _resourceManager = FindObjectOfType<ResourceManager>();
            }

            return _resourceManager;
        }
    }
}
