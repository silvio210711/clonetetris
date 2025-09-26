using UnityEngine;
using UnityEngine.UIElements;

public class PieceMove : MonoBehaviour
{
    float fall;

    [SerializeField] float timeCount;
    float count;
    [SerializeField] float timeCountFlip;
    float countFlip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
        PieceFall();

        if (count > 0)
        {
            count -= Time.deltaTime;
        }
        if (countFlip > 0)
        {
            countFlip -= Time.deltaTime;
        }
    }

    void Move()
    {
        float horizontal = InputManeger.GetMovementInput().x;

        if (horizontal != 0 && count <= 0)
        {
            count = timeCount;
            transform.position += new Vector3(horizontal, 0, 0);
        }
        if (horizontal == 0)
        {
            count = 0;
        }
    }
    void Flip()
    {
        if (InputManeger.GetFlipInput() && countFlip <= 0)
        {
            countFlip = timeCountFlip;
            transform.Rotate(0, 0, 90);
        }
    }
    void PieceFall()
    {
        if (Time.time - fall >= GameController.instance.Speed)
        {
            transform.position += new Vector3(0, -1, 0);
            fall = Time.time;
        }
    }
    
}

