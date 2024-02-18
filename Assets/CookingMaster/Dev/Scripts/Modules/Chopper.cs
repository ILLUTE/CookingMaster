using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chopper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_TimerTxt;
    public bool IsOccupied;

    public void Chop(Ingredients ingredient, PlayerController playerController)
    {
        if (ingredient == null) return;
        playerController.GetComponent<CharacterController>().enabled = false;
        Vector3 forward = transform.forward;
        forward.y = 0;
        playerController.transform.forward = forward;
        playerController.GetComponent<CharacterController>().enabled = true;
        StartCoroutine(StartChopping(ingredient, playerController));
    }

    private IEnumerator StartChopping(Ingredients ingredient, PlayerController playerController)
    {
        IsOccupied = true;
        playerController.IsChopping = true;

        float elapsedTime = 0;
        float choppingTime = ingredient.ChoppingTime;
        playerController.InvokeIngredientRemoved(ingredient);
        while (elapsedTime < choppingTime)
        {
            elapsedTime += Time.deltaTime;
            m_TimerTxt.text = (choppingTime - elapsedTime).ToString("0.00");
            yield return null;
        }
        playerController.playerInventory.AddChoppedVeggies(ingredient.IngredientName);
        playerController.InvokeChoppedIngredientPicked(ingredient);
        playerController.IsChopping = false;
        IsOccupied = false;
        m_TimerTxt.text = "Vacant";
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
