using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float timer;
    private int nextPoint = 4;
    private Vector3 targetPosition;
    private float moveSpeed = 0.05f;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(1, -5, 0); // initial player position
        checkPoint();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (gameObject.transform.position != targetPosition)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition, timer * moveSpeed);
        } else 
        {
            if (nextPoint < 4)
            {
                nextPoint++;
            } else 
            {
                nextPoint = 1;
            }
            checkPoint();
        }
    }

    void checkPoint()
    {
        timer = 0;
        switch (nextPoint)
        {
            case 1:
                gameObject.transform.localRotation = Quaternion.Euler(0, 0, 180);
                targetPosition = new Vector3(1, -1, 0);
                break;
            case 2:
                gameObject.transform.localRotation = Quaternion.Euler(0, 0, 90);
                targetPosition = new Vector3(6, -1, 0);
                break;
            case 3:
                gameObject.transform.localRotation = Quaternion.identity;
                targetPosition = new Vector3(6, -5, 0);
                break;
            case 4:
                gameObject.transform.localRotation = Quaternion.Euler(0, 0, 270);
                targetPosition = new Vector3(1, -5, 0);
                break;
            default:
                break;
        }
    }
}
