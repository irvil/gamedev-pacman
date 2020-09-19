using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // 0 - empty
    // 1 - outside corner, 2 - outside wall
    // 3 - inside corner, 4 - inside wall
    // 5 - normal pellet, 6 - power pellet
    // 7 - T junction
    int[,] levelMap = 
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0}
    };
    
    [SerializeField]
    private GameObject innerCorner;
    [SerializeField]
    private GameObject innerWall;
    [SerializeField]
    private GameObject outerCorner;
    [SerializeField]
    private GameObject outerWall;
    [SerializeField]
    private GameObject tJunction;

    // Start is called before the first frame update
    void Start()
    {
        buildFirstQuad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buildFirstQuad()
    {
        for (int i = 0; i < levelMap.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < levelMap.GetUpperBound(1) + 1; j++)
            {
                switch (levelMap[i,j])
                {
                    case 1:
                        //Instantiate(outerCorner, new Vector2(j, -i), Quaternion.identity);
                        if (i == 9 && j == 0) 
                        {
                            Instantiate(outerCorner, new Vector2(j, -i), Quaternion.Euler(new Vector3(0, 0, 90)));
                        } else if (i == 9 && j == 5)
                        {
                            Instantiate(outerCorner, new Vector2(j, -i), Quaternion.Euler(new Vector3(0, 0, 270)));
                        } else if (i == 13 && j == 5)
                        {
                            Instantiate(outerCorner, new Vector2(j, -i), Quaternion.Euler(new Vector3(0, 0, 180)));
                        } else 
                        {
                            Instantiate(outerCorner, new Vector2(j, -i), Quaternion.identity);
                        }
                        break;
                    case 2:
                        if (i > 0 && i < 9 || (i >= 9 && i <= 13 && j == 5)) 
                        {
                            Instantiate(outerWall, new Vector2(j, -i), Quaternion.Euler(new Vector3(0, 0, -90)));
                        } else {
                            Instantiate(outerWall, new Vector2(j, -i), Quaternion.identity);
                        }
                        break;
                    case 3:
                        Instantiate(innerCorner, new Vector2(j, -i), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(innerWall, new Vector2(j, -i), Quaternion.identity);
                        break;
                    case 7:
                        Instantiate(tJunction, new Vector2(j, -i), Quaternion.identity);
                        break;
                    default:
                        GameObject g = new GameObject("x: " + i + ", y: " + j);
                        g.transform.position = new Vector2(j, -i);
                        break;
                }
                //Instantiate(tJunction, new Vector2(i, j), Quaternion.identity);
            }
        }
    }
}
