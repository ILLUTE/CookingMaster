using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IInputInterface currentInput;

    private Vector3 movement;

    [SerializeField] private CharacterController m_CharacterController;
    [SerializeField] private float m_MoveSpeed = 5;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private GroundCheck m_GroundCheck;
    public int Id;
    public PlayerInventoryHandler playerInventory;

    private float smoothTime = 0.05f;
    private float _currentVelocity;
    public bool IsChopping;

    public event Action<Ingredients> OnIngredientPicked;
    public event Action<Ingredients> OnIngredientDropped;

    public event Action<Ingredients> OnChoppedPicked;
    public event Action OnChoppedFlush;
    private float m_Gravity = -10.0f;
    private float Vertical;

    private Vector3 lastPosition;
    private void Awake()
    {
        m_GroundCheck = GetComponent<GroundCheck>(); 
        currentInput = Id == 0 ? new Player1Input() : new Player2Input();
    }

    private void Start()
    {
        Locator.Instance.ScoreManagerInstance.ConnectPlayer(this);
    }

    private void Update()
    {
        lastPosition.y = 0;
        Vector3 temp = transform.position;
        temp.y = 0;
        float distanceWalked = Vector3.Distance(temp, lastPosition);
        m_Animator.SetFloat("Speed_f", distanceWalked == 0 ? 0 : 0.5f);

        lastPosition = transform.position;
        if(m_GroundCheck.IsGrounded())
        {
            Vertical = -0.2f;
        }
        else
        {
            Vertical = m_Gravity * Time.deltaTime;
        }
        if (IsChopping) return;
        float Horizontal = currentInput.GetAxisHorizontal();
        float Forward = currentInput.GetAxisVertical();

        movement = new Vector3(Horizontal, 0, Forward);
        movement.Normalize();
        if (movement.magnitude > 0)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        var targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0.0f);
    }

    private void FixedUpdate()
    {
        if (IsChopping) return;
        movement.y = Vertical;
        m_CharacterController.Move(m_MoveSpeed * Time.fixedDeltaTime * movement);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!currentInput.GetInteractButton()) return;
        if (other.TryGetComponent(out Chopper chopper))
        {
            if (!chopper.IsOccupied)
            {
                chopper.Chop(playerInventory.AddIngredientToBowl(), this.GetComponent<PlayerController>());
            }
        }

        if (other.TryGetComponent(out IngredientPicker picker))
        {
            if (playerInventory.CanPickIngredients())
            {
                playerInventory.AddIngredientsInInventory(picker.ingredientAvailable);
            }
        }

        if(other.TryGetComponent(out TrashCan trashCan))
        {
            playerInventory.createdDish = new();
            InvokeChoppedIngredientRemoved();
        }

        if(other.TryGetComponent(out OrderReadyTrigger order))
        {
            CustomerController controller = order.GetCustomer();
            if(controller == null)
            {
                Debug.Log("Customer is null");
                return;
            }
            controller.ServeDish(playerInventory.createdDish, this);
            playerInventory.createdDish = new();
            InvokeChoppedIngredientRemoved();
        }
    }

    public void InvokeIngredientPicked(Ingredients ingredients)
    {
        OnIngredientPicked?.Invoke(ingredients);
    }

    public void InvokeIngredientRemoved(Ingredients ingredients)
    {
        OnIngredientDropped?.Invoke(ingredients);
    }

    public void InvokeChoppedIngredientPicked(Ingredients ingredient)
    {
        OnChoppedPicked?.Invoke(ingredient);
    }

    public void InvokeChoppedIngredientRemoved()
    {
        OnChoppedFlush?.Invoke();
    }
}

public enum PlayerState
{ 
    Walking,
    Chopping,
}

