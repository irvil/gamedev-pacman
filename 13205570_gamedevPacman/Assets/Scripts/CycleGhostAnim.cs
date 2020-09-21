using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleGhostAnim : MonoBehaviour
{
    private int lastTime;
    private int lastScared;
    private int lastRecover;
    private int lastDead;
    private float timer;

    // Time increments
    float scaredWait = 3.0f;
    float recoverWait = 6.0f;
    float deadWait = 12.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (lastTime < timer) lastTime++;

        if (lastTime % (int) scaredWait == 0){
            //GhostAnimator_Red.SetTrigger("scared");
        }
    }
}
