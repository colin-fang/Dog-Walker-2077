using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
 
    public Button Play;
    public Button Quit;
    public Button Pet;
    // Start is called before the first frame update
    void Start()
    {
        
        Play.onClick.AddListener(delegate { P("LevelDog"); });
        Pet.onClick.AddListener(delegate { P("PetSelection"); });
        Quit.onClick.AddListener(doExitGame);

    }

    // Update is called once per frame
    
    public void P(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }
    public void doExitGame()
    {
        Application.Quit();
    }
}
