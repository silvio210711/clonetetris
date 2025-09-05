using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManeger : MonoBehaviour
{

    Vector2 movmentInput;
    bool flipInput;
    float countFlip;
    float flipTime;
    public static InputManeger instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);

        }

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
        movmentInput = value.Get<Vector2>();
    }
}
