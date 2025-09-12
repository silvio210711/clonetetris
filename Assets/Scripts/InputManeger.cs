using UnityEngine;
using UnityEngine.InputSystem;


public class InputManeger : MonoBehaviour
{
    Vector2 moventInput;
    public static InputManeger instance;

    void Awake()
    {
        instance = this;
    }

    public void OnMove(InputValue value)
    {
        moventInput = value.Get<Vector2>();
    }

    public static Vector2 GetMovementInput()
    {
        return instance.moventInput;
    }
} 
