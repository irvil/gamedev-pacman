using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleGhostAnim : MonoBehaviour
{
    public Animator redAnimController;
    public Animator pinkAnimController;
    public Animator cyanAnimController;
    public Animator orangeAnimController;
    
    private int lastTime;
    private float timer;

    // Time increments
    float scaredWait = 3.0f;

    Coroutine cycleCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (lastTime < timer) lastTime++;

        if (lastTime % (int) scaredWait == 0 && cycleCoroutine == null){
            cycleCoroutine = StartCoroutine(cycleAnim());
        }
    }

    //void ResetTimer() => timer = 0;

    IEnumerator cycleAnim(){ // Enables for each state to be played for 3 seconds each
        
        redAnimController.SetTrigger("scared");
        pinkAnimController.SetTrigger("scared");
        cyanAnimController.SetTrigger("scared");
        orangeAnimController.SetTrigger("scared");
        yield return new WaitForSeconds(3.0f);
        
        redAnimController.SetTrigger("recovering");
        pinkAnimController.SetTrigger("recovering");
        cyanAnimController.SetTrigger("recovering");
        orangeAnimController.SetTrigger("recovering");
        yield return new WaitForSeconds(3.0f);
        
        redAnimController.SetTrigger("dead");
        pinkAnimController.SetTrigger("dead");
        cyanAnimController.SetTrigger("dead");
        orangeAnimController.SetTrigger("dead");
        yield return new WaitForSeconds(6.0f);
        
        timer = 0;
        cycleCoroutine = null;
    }
}
