using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderAnimation : MonoBehaviour
{
    // Used to animate the pellets around the title

    private float timer;
    private float duration = 0.5f;
    private List<Image> pelletsA = new List<Image>();
    private List<Image> pelletsB = new List<Image>();
    private List<Image> powerPellets = new List<Image>();
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject pellet in GameObject.FindGameObjectsWithTag("BorderPelletA"))
        {
            pelletsA.Add(pellet.GetComponent<Image>());
        }
        foreach(GameObject pellet in GameObject.FindGameObjectsWithTag("BorderPelletB"))
        {
            pelletsB.Add(pellet.GetComponent<Image>());
        }
        foreach(GameObject pellet in GameObject.FindGameObjectsWithTag("BorderPowerPellet"))
        {
            powerPellets.Add(pellet.GetComponent<Image>());
        }
        flashPelletsA();
    }

    // Update is called once per frame
    void Update()
    {
        if((timer += Time.deltaTime) >= duration)
        {
            timer = 0;
            flashPelletsA();
            flashPelletsB();
            flashPowerPellets();
        }
    }

    void flashPelletsA()
    {
        foreach(Image pellet in pelletsA)
        {
            pellet.enabled = !pellet.enabled;
        }
    }

    void flashPelletsB()
    {
        foreach(Image pellet in pelletsB)
        {
            pellet.enabled = !pellet.enabled;
        }
    }

    void flashPowerPellets()
    {
        foreach(Image pellet in powerPellets)
        {
            if(pellet.color == Color.white)
            {
                pellet.color = Color.green;
            } else {
                pellet.color = Color.white;
            }
        }
    }
}
