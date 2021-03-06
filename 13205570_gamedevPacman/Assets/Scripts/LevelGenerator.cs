﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // 0 - empty
    // 1 - outside corner, 2 - outside wall
    // 3 - inside corner, 4 - inside wall
    // 5 - normal pellet, 6 - power pellet
    // 7 - T junction

    // Note that the levelMap is 14x13
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
    [SerializeField]
    private GameObject regPellet;
    [SerializeField]
    private GameObject powPellet;

    [SerializeField]
    private Transform mapPieces;

    // Start is called before the first frame update
    void Start()
    {
        buildFirstQuad();
        buildSecondQuad();
        buildThirdQuad();
        buildFourthQuad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buildFirstQuad()
    {
        // Note: any time we use i == levelMap...UpperBound(0) + 1, we are referring to 'x = 14', the extra line
        for (int i = 0; i < levelMap.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < levelMap.GetUpperBound(1) + 1; j++)
            {
                switch (levelMap[i,j])
                {
                    case 1:
                        if (i == 9 && j == 0) 
                        {
                            Instantiate(outerCorner, new Vector2(j, -i), Quaternion.Euler(new Vector3(0, 0, 90)), mapPieces);
                        } else if (i == 9 && j == 5)
                        {
                            Instantiate(outerCorner, new Vector2(j, -i), Quaternion.Euler(new Vector3(0, 0, 270)), mapPieces);
                        } else if (i == 13 && j == 5)
                        {
                            Instantiate(outerCorner, new Vector2(j, -i), Quaternion.Euler(new Vector3(0, 0, 180)), mapPieces);
                        } else 
                        {
                            Instantiate(outerCorner, new Vector2(j, -i), Quaternion.identity, mapPieces);
                        }
                        break;
                    case 2:
                        if (i > 0 && i < 9 || (i >= 9 && i <= 13 && j == 5)) 
                        {
                            Instantiate(outerWall, new Vector2(j, -i), Quaternion.Euler(new Vector3(0, 0, -90)), mapPieces);
                        } else {
                            Instantiate(outerWall, new Vector2(j, -i), Quaternion.identity, mapPieces);
                        }
                        break;
                    case 3:
                        if ((i == 4 && (j == 2 || j == 7)) || (i != 7 && j  == levelMap.GetUpperBound(1)) || (i == 7 && (j == 2 || j == 10)) || (i == 9 && j == 8) || (i == levelMap.GetUpperBound(0) - 1 && j == 7)) 
                        {
                            Instantiate(innerCorner, new Vector2(j, -i), Quaternion.Euler(new Vector3(0, 0, 90)), mapPieces);
                        } else if (i == 4 && (j == 5 || j == 11) || (i == 7 && j == 5) || (i == 10 && j == 11) || (i == levelMap.GetUpperBound(0) - 1 && j == 8))
                        {
                            Instantiate(innerCorner, new Vector2(j, -i), Quaternion.Euler(new Vector3(0, 0, 180)), mapPieces);
                        } else if ((i == 2 && (j == 5 || j == 11)) || (i == 6 && (j == 5 || j == 8)) || (i == 9 && j == 11) || (i == 7 && j == levelMap.GetUpperBound(1)))
                        {
                            Instantiate(innerCorner, new Vector2(j, -i), Quaternion.Euler(new Vector3(0, 0, 270)), mapPieces);
                        } else
                        {
                            Instantiate(innerCorner, new Vector2(j, -i), Quaternion.identity, mapPieces);
                        }
                        break;
                    case 4:
                        if ((i <= 9 && i != 6 && j == levelMap.GetUpperBound(1)) || (i == 3) || (i >= 7 && i <= 12 && (j == 7 || j == 8)) || (j == 10 && i >= levelMap.GetUpperBound(0) - 1))
                        {
                            Instantiate(innerWall, new Vector2(j, -i), Quaternion.Euler(new Vector3(0, 0, -90)), mapPieces);
                        } else 
                        {
                            Instantiate(innerWall, new Vector2(j, -i), Quaternion.identity, mapPieces);
                        }
                        break;
                    case 5:
                        Instantiate(regPellet, new Vector2(j, -i), Quaternion.identity, mapPieces);
                        break;
                    case 6:
                        Instantiate(powPellet, new Vector2(j, -i), Quaternion.identity, mapPieces);
                        break;
                    case 7:
                        Instantiate(tJunction, new Vector2(j, -i), Quaternion.identity, mapPieces);
                        break;
                    default:
                        // For creating reference points
                        //GameObject g = new GameObject("x: " + i + ", y: " + j);
                        //g.transform.position = new Vector2(j, -i);
                        break;
                }
            }
        }
    }

    void buildSecondQuad()
    {
        int k; // Used for adjusting to mirror j positions horizontally

        for (int i = 0; i < levelMap.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < levelMap.GetUpperBound(1) + 1; j++)
            {
                k = 2 * levelMap.GetUpperBound(1) + 1 - j;
                
                switch (levelMap[i,j])
                {
                    case 1:
                        if (i == 9 && j == 0) 
                        {
                            Instantiate(outerCorner, new Vector2(k, -i), Quaternion.Euler(new Vector3(0, 0, 180)), mapPieces);
                        } else if (i == 9 && j == 5)
                        {
                            Instantiate(outerCorner, new Vector2(k, -i), Quaternion.identity, mapPieces);
                        } else if (i == 13 && j == 5)
                        {
                            Instantiate(outerCorner, new Vector2(k, -i), Quaternion.Euler(new Vector3(0, 0, 90)), mapPieces);
                        } else 
                        {
                            Instantiate(outerCorner, new Vector2(k, -i), Quaternion.Euler(new Vector3(0, 0, 270)), mapPieces);
                        }
                        break;
                    case 2:
                        if (i > 0 && i < 9 || (i >= 9 && i <= 13 && j == 5)) 
                        {
                            Instantiate(outerWall, new Vector2(k, -i), Quaternion.Euler(new Vector3(0, 0, -90)), mapPieces);
                        } else {
                            Instantiate(outerWall, new Vector2(k, -i), Quaternion.identity, mapPieces);
                        }
                        break;
                    case 3:
                        if ((i == 4 && (j == 2 || j == 7)) || (i != 7 && j  == levelMap.GetUpperBound(1)) || (i == 7 && (j == 2 || j == 10)) || (i == 9 && j == 8) || (i == levelMap.GetUpperBound(0) - 1 && j == 7)) 
                        {
                            Instantiate(innerCorner, new Vector2(k, -i), Quaternion.Euler(new Vector3(0, 0, 180)), mapPieces);
                        } else if (i == 4 && (j == 5 || j == 11) || (i == 7 && j == 5) || (i == 10 && j == 11) || (i == levelMap.GetUpperBound(0) - 1 && j == 8))
                        {
                            Instantiate(innerCorner, new Vector2(k, -i), Quaternion.Euler(new Vector3(0, 0, 90)), mapPieces);
                        } else if ((i == 2 && (j == 5 || j == 11)) || (i == 6 && (j == 5 || j == 8)) || (i == 9 && j == 11) || (i == 7 && j == levelMap.GetUpperBound(1)))
                        {
                            Instantiate(innerCorner, new Vector2(k, -i), Quaternion.identity, mapPieces);
                        } else
                        {
                            Instantiate(innerCorner, new Vector2(k, -i), Quaternion.Euler(new Vector3(0, 0, 270)), mapPieces);
                        }
                        break;
                    case 4:
                        if ((i <= 9 && i != 6 && j == levelMap.GetUpperBound(1)) || (i == 3) || (i >= 7 && i <= 12 && (j == 7 || j == 8)) || (j == 10 && i >= levelMap.GetUpperBound(0) - 1))
                        {
                            Instantiate(innerWall, new Vector2(k, -i), Quaternion.Euler(new Vector3(0, 0, -90)), mapPieces);
                        } else 
                        {
                            Instantiate(innerWall, new Vector2(k, -i), Quaternion.identity, mapPieces);
                        }
                        break;
                    case 5:
                        Instantiate(regPellet, new Vector2(k, -i), Quaternion.identity, mapPieces);
                        break;
                    case 6:
                        Instantiate(powPellet, new Vector2(k, -i), Quaternion.identity, mapPieces);
                        break;
                    case 7:
                        GameObject secondJunction = Instantiate(tJunction, new Vector2(k, -i), Quaternion.identity, mapPieces);
                        secondJunction.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); // Flip horizontally
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void buildThirdQuad() 
    {
        // Unlike 1st and 2nd quads, we work with a 13x13 space rather than a 14x13

        int k; // Used for adjusting to mirror i vertically

        for (int i = 0; i < levelMap.GetUpperBound(0); i++)
        {
            k = 2 * levelMap.GetUpperBound(0) - i; 

            for (int j = 0; j < levelMap.GetUpperBound(1) + 1; j++)
            {
                switch (levelMap[i,j])
                {
                    case 1:
                        if (i == 9 && j == 0) 
                        {
                            Instantiate(outerCorner, new Vector2(j, -k), Quaternion.identity, mapPieces);
                        } else if (i == 9 && j == 5)
                        {
                            Instantiate(outerCorner, new Vector2(j, -k), Quaternion.Euler(new Vector3(0, 0, 180)), mapPieces);
                        } else if (i == 13 && j == 5)
                        {
                            Instantiate(outerCorner, new Vector2(j, -k), Quaternion.Euler(new Vector3(0, 0, 270)), mapPieces);
                        } else 
                        {
                            Instantiate(outerCorner, new Vector2(j, -k), Quaternion.Euler(new Vector3(0, 0, 90)), mapPieces);
                        }
                        break;
                    case 2:
                        if (i > 0 && i < 9 || (i >= 9 && i <= 13 && j == 5)) 
                        {
                            Instantiate(outerWall, new Vector2(j, -k), Quaternion.Euler(new Vector3(0, 0, -90)), mapPieces);
                        } else {
                            Instantiate(outerWall, new Vector2(j, -k), Quaternion.identity, mapPieces);
                        }
                        break;
                    case 3:
                        if ((i == 4 && (j == 2 || j == 7)) || (i != 7 && j  == levelMap.GetUpperBound(1)) || (i == 7 && (j == 2 || j == 10)) || (i == 9 && j == 8) || (i == levelMap.GetUpperBound(0) - 1 && j == 7)) 
                        {
                            Instantiate(innerCorner, new Vector2(j, -k), Quaternion.identity, mapPieces);
                        } else if (i == 4 && (j == 5 || j == 11) || (i == 7 && j == 5) || (i == 10 && j == 11) || (i == levelMap.GetUpperBound(0) - 1 && j == 8))
                        {
                            Instantiate(innerCorner, new Vector2(j, -k), Quaternion.Euler(new Vector3(0, 0, 270)), mapPieces);
                        } else if ((i == 2 && (j == 5 || j == 11)) || (i == 6 && (j == 5 || j == 8)) || (i == 9 && j == 11) || (i == 7 && j == levelMap.GetUpperBound(1)))
                        {
                            Instantiate(innerCorner, new Vector2(j, -k), Quaternion.Euler(new Vector3(0, 0, 180)), mapPieces);
                        } else
                        {
                            Instantiate(innerCorner, new Vector2(j, -k), Quaternion.Euler(new Vector3(0, 0, 90)), mapPieces);
                        }
                        break;
                    case 4:
                        if ((i <= 9 && i != 6 && j == levelMap.GetUpperBound(1)) || (i == 3) || (i >= 7 && i <= 12 && (j == 7 || j == 8)) || (j == 10 && i >= levelMap.GetUpperBound(0) - 1))
                        {
                            Instantiate(innerWall, new Vector2(j, -k), Quaternion.Euler(new Vector3(0, 0, -90)), mapPieces);
                        } else 
                        {
                            Instantiate(innerWall, new Vector2(j, -k), Quaternion.identity, mapPieces);
                        }
                        break;
                    case 5:
                        Instantiate(regPellet, new Vector2(j, -k), Quaternion.identity, mapPieces);
                        break;
                    case 6:
                        Instantiate(powPellet, new Vector2(j, -k), Quaternion.identity, mapPieces);
                        break;
                    case 7:
                        GameObject thirdJunction = Instantiate(tJunction, new Vector2(j, -k), Quaternion.identity, mapPieces);
                        thirdJunction.transform.localScale = new Vector3(1.0f, -1.0f, 1.0f); // Flip vertically
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void buildFourthQuad()
    {
        int k, l; // Used for adjusting to mirror i vertically and j horizontally, respectively

        for (int i = 0; i < levelMap.GetUpperBound(0); i++)
        {
            k = 2 * levelMap.GetUpperBound(0) - i; 

            for (int j = 0; j < levelMap.GetUpperBound(1) + 1; j++)
            {
                l = 2 * levelMap.GetUpperBound(1) + 1 - j;
                
                switch (levelMap[i,j])
                {
                    case 1:
                        if (i == 9 && j == 0) 
                        {
                            Instantiate(outerCorner, new Vector2(l, -k), Quaternion.Euler(new Vector3(0, 0, 270)), mapPieces);
                        } else if (i == 9 && j == 5)
                        {
                            Instantiate(outerCorner, new Vector2(l, -k), Quaternion.Euler(new Vector3(0, 0, 90)), mapPieces);
                        } else if (i == 13 && j == 5)
                        {
                            Instantiate(outerCorner, new Vector2(l, -k), Quaternion.identity, mapPieces);
                        } else 
                        {
                            Instantiate(outerCorner, new Vector2(l, -k), Quaternion.Euler(new Vector3(0, 0, 180)), mapPieces);
                        }
                        break;
                    case 2:
                        if (i > 0 && i < 9 || (i >= 9 && i <= 13 && j == 5)) 
                        {
                            Instantiate(outerWall, new Vector2(l, -k), Quaternion.Euler(new Vector3(0, 0, -90)), mapPieces);
                        } else {
                            Instantiate(outerWall, new Vector2(l, -k), Quaternion.identity, mapPieces);
                        }
                        break;
                    case 3:
                        if ((i == 4 && (j == 2 || j == 7)) || (i != 7 && j  == levelMap.GetUpperBound(1)) || (i == 7 && (j == 2 || j == 10)) || (i == 9 && j == 8) || (i == levelMap.GetUpperBound(0) - 1 && j == 7)) 
                        {
                            Instantiate(innerCorner, new Vector2(l, -k), Quaternion.Euler(new Vector3(0, 0, 270)), mapPieces);
                        } else if (i == 4 && (j == 5 || j == 11) || (i == 7 && j == 5) || (i == 10 && j == 11) || (i == levelMap.GetUpperBound(0) - 1 && j == 8))
                        {
                            Instantiate(innerCorner, new Vector2(l, -k), Quaternion.identity, mapPieces);
                        } else if ((i == 2 && (j == 5 || j == 11)) || (i == 6 && (j == 5 || j == 8)) || (i == 9 && j == 11) || (i == 7 && j == levelMap.GetUpperBound(1)))
                        {
                            Instantiate(innerCorner, new Vector2(l, -k), Quaternion.Euler(new Vector3(0, 0, 90)), mapPieces);
                        } else
                        {
                            Instantiate(innerCorner, new Vector2(l, -k), Quaternion.Euler(new Vector3(0, 0, 180)), mapPieces);
                        }
                        break;
                    case 4:
                        if ((i <= 9 && i != 6 && j == levelMap.GetUpperBound(1)) || (i == 3) || (i >= 7 && i <= 12 && (j == 7 || j == 8)) || (j == 10 && i >= levelMap.GetUpperBound(0) - 1))
                        {
                            Instantiate(innerWall, new Vector2(l, -k), Quaternion.Euler(new Vector3(0, 0, -90)), mapPieces);
                        } else 
                        {
                            Instantiate(innerWall, new Vector2(l, -k), Quaternion.identity, mapPieces);
                        }
                        break;
                    case 5:
                        Instantiate(regPellet, new Vector2(l, -k), Quaternion.identity, mapPieces);
                        break;
                    case 6:
                        Instantiate(powPellet, new Vector2(l, -k), Quaternion.identity, mapPieces);
                        break;
                    case 7:
                        GameObject thirdJunction = Instantiate(tJunction, new Vector2(l, -k), Quaternion.identity, mapPieces);
                        thirdJunction.transform.localScale = new Vector3(-1.0f, -1.0f, 1.0f); // Flip x and y
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
