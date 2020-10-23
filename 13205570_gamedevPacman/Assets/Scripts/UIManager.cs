using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFirstLevel()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MainScene");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 0)
        {
            Button exitBtn = GameObject.FindWithTag("ExitButton").GetComponent<Button>();
            exitBtn.onClick.AddListener(ExitLevel);
        }
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("StartScene");
    }
}
