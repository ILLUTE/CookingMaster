using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryBtn : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("CookingMaster");
    }
}
