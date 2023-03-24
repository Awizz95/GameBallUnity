using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OneBallBehaviour : MonoBehaviour
{

    public float XSpeed;
    public float YSpeed;
    public float ZSpeed;
    public float TooFar = 5;
    public float Multiplier = 0.75F;

    static int BallCount = 0;
    public int BallNumber;

    void OnMouseDown()
    {
        GameController controller = Camera.main.GetComponent<GameController>();

        if (!controller.GameOver)
        {
            controller.ClickedOnBall();
            Destroy(gameObject);
        }
    }


    void Start()
    {
        BallCount++;
        BallNumber = BallCount;

        ResetBall();
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * XSpeed,Time.deltaTime * YSpeed, Time.deltaTime * ZSpeed);

        XSpeed += Multiplier - Random.value * Multiplier * 2;
        YSpeed += Multiplier - Random.value * Multiplier * 2;
        ZSpeed += Multiplier - Random.value * Multiplier * 2;

        if ((Mathf.Abs(transform.position.x) > TooFar) || (Mathf.Abs(transform.position.y) > TooFar) || (Mathf.Abs(transform.position.z) > TooFar))
        {
            ResetBall();
        }
    }


    void ResetBall()
    {
        XSpeed = Random.value * Multiplier;
        YSpeed = Random.value * Multiplier;
        ZSpeed = Random.value * Multiplier;

        transform.position = new Vector3(3 - Random.value * 6, 3 - Random.value * 6, 3 - Random.value * 6);
    }
}
