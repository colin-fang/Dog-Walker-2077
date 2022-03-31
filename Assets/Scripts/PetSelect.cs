using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PetSelect : MonoBehaviour
{
    public Button Cat;
    public Button Dog;

    // Start is called before the first frame update
    void Start()
    {
        Dog.onClick.AddListener(delegate { Home("LevelDog"); });
        Cat.onClick.AddListener(delegate { Home("LevelCat"); });
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
