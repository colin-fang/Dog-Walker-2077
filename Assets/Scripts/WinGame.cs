using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WinGame : MonoBehaviour
{
    public Button Menu;
    public Button Exit;
   
    // Start is called before the first frame update
    void Start()
    {
        Menu.onClick.AddListener(delegate { Home("MainMenu"); });
        Exit.onClick.AddListener(doExitGame);
    }

    public void Home(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }
    public void doExitGame()
    {
        Application.Quit();
    }
}
