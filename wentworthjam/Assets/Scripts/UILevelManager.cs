using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelManager : MonoBehaviour
{
    [SerializeField] private string nextScene;

    [SerializeField] private string menuScene;
    
    [SerializeField] private string creditsScene;
    
    [SerializeField] private string helpScene;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(creditsScene);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void LoadHelp()
    {
        SceneManager.LoadScene(helpScene);
    }
}
