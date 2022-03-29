using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
 
    public Button Play;
    public Button Quit;
    // Start is called before the first frame update
    void Start()
    {
        
        Play.onClick.AddListener(delegate { P(1); });
        Quit.onClick.AddListener(doExitGame);

    }

    // Update is called once per frame
    
    public void P(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
    public void doExitGame()
    {
        Application.Quit();
    }
}
