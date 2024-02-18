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
                    GameObject go = new("Locator");
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

    private ScoreManager _scoreManager;
    public ScoreManager ScoreManagerInstance
    {
        get
        {
            if (_scoreManager == null)
            {
                _scoreManager = FindObjectOfType<ScoreManager>();

                if (_scoreManager == null)
                {
                    GameObject go = new("ScoreManager");
                    _scoreManager = go.AddComponent<ScoreManager>();
                }
            }

            return _scoreManager;
        }
    }

    private GameManager _gameManager;
    public GameManager GameManagerInstance
    {
        get
        {
            if (_gameManager == null)
            {
                _gameManager = FindObjectOfType<GameManager>();
            }

            return _gameManager;
        }
    }
}
