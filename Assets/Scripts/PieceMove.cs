using UnityEngine;
using UnityEngine.UIElements;

public class PieceMove : MonoBehaviour
{
    #region variaveis
    float fall;

    [SerializeField] float timeCount;
    float count;
    //[SerializeField] float timeCountFlip;
    float countFlip;

    //[SerializeField] float timeCountDown;
    float countDown;

    [SerializeField] bool canRotate;
    [SerializeField] bool Rotate360;

    [SerializeField] SpawnTetro spawnTetro;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTetro = GameObject.FindFirstObjectByType<SpawnTetro>();
        spawnTetro.setNextPieceStatus(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
        PieceFall();
        count = UpdateTimer(count);
        countDown = UpdateTimer(countDown);
        countFlip = UpdateTimer(countFlip);

        // if (count > 0)
        // {
        //     count -= Time.deltaTime;
        // }
        // if (countFlip > 0)
        // {
        //     countFlip -= Time.deltaTime;
        // }

        // if (countDown > 0)
        // {
        //     countDown -= Time.deltaTime;
        // }

    }

    void Move()
    {
        float horizontal = InputManeger.GetMovementInput().x;
        float vertical = InputManeger.GetMovementInput().y;

        // if (horizontal != 0 && count <= 0)
        // {
        //     count = timeCount;
        //     transform.position += new Vector3(horizontal, 0, 0);

        //     if (validatePosition())
        //     {

        //     }
        //     else
        //         {
        //             if (horizontal == 1)
        //             {
        //                 transform.position += new Vector3(-1, 0, 0);

        //             }

        //             if (horizontal == -1)
        //             {
        //                 transform.position += new Vector3(1, 0, 0);

        //             }
        //         }
        // }

        if (horizontal == 1 && count <= 0)
        {
            transform.position += new Vector3(1, 0, 0);
            count = timeCount;

            if (validatePosition())
            {
                GameController.instance.UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }


        if (horizontal == -1 && count <= 0)
        {
            transform.position += new Vector3(-1, 0, 0);
            count = timeCount;

            if (validatePosition())
            {
                GameController.instance.UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }

        if (horizontal == 0)
        {
            count = 0;
        }

        if (vertical == -1 && countDown <= 0)
        {
            transform.position += new Vector3(0, -1, 0);
            countDown = timeCount;

            if (validatePosition())
            {
                GameController.instance.UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                enabled = false;
                spawnTetro.setNextPieceStatus(true);
                GameController.instance.DeleteLine();
            }
        }
    }
    void Flip()
    {
        if (InputManeger.GetFlipInput() && countFlip <= 0)
        {
            countFlip = timeCount;
            // transform.Rotate(0, 0, 90);

            // if (validatePosition())
            // {
            //     GameController.instance.UpdateGrid(this);
            // }
            // else
            // {
            //     transform.Rotate(0, 0, -90);
            // }
            checkRotate(); 
            
        }
    }
    void PieceFall()
    {
        if (Time.time - fall >= GameController.instance.Speed)
        {
            transform.position += new Vector3(0, -1, 0);            
            fall = Time.time;


            if (validatePosition())
            {
                GameController.instance.UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(0, 1,0);
                enabled = false;
                spawnTetro.setNextPieceStatus(true);
                GameController.instance.DeleteLine();   
            }
        }
    }
    float UpdateTimer(float timer)
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        return timer;
    }

    bool validatePosition()

    {
        foreach (Transform child in transform)
        {
            Vector2 blockPos =
            GameController.instance.Round(child.position);
            if (!GameController.instance.InsideGrid(blockPos))
            {
                return false;

            }

            if (GameController.instance.TransformGridPosition(blockPos) != null &&
                GameController.instance.TransformGridPosition(blockPos).parent !=
            transform)
            {
                return false;
            }
        }
        return true;
    }
    
    void checkRotate()
    {
        if(canRotate)
        {
            if (!Rotate360)
            {
                if (transform.rotation.z < 0)
                {
                    transform.Rotate(0, 0, 90);
                    if (validatePosition())
                    {
                        GameController.instance.UpdateGrid(this);
                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                }
                else
                {
                    transform.Rotate(0, 0, -90);
                    if (validatePosition())
                    {
                        GameController.instance.UpdateGrid(this);
                    }
                    else
                    {
                        transform.Rotate(0, 0, 90);
                    }
                }
            }
            else
            {
                transform.Rotate(0, 0, -90);
                if (validatePosition())
                {
                    GameController.instance.UpdateGrid(this);
                }
                else
                {
                    transform.Rotate(0, 0, 90);
                }
            }
        }   
    }
    
}

