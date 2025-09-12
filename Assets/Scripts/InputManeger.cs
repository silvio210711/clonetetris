using UnityEngine;
using UnityEngine.InputSystem;


public class InputManeger : MonoBehaviour
{
    Vector2 moventInput;

    bool flipInput;
    float countFlip;
    float flipTime;
    public static InputManeger instance;

    void Awake()
    {
        instance = this;

        flipTime = 0.01f;
    }
    void Update()
    {
        if (countFlip <= 0)
        {
            flipInput = false;
        }
        if (countFlip > 0)
        {
            countFlip -= Time.deltaTime;
         }
    }

    public void OnMove(InputValue value)
    {
        moventInput = value.Get<Vector2>();
    }

    public static Vector2 GetMovementInput()
    {
        return instance.moventInput;
    }
    public void OnFlip(InputValue value)

    {
        countFlip = flipTime;
        flipInput = value.isPressed;
    }
    public static bool GetFlipInput()
    {
        return instance.flipInput;
    }
} 
