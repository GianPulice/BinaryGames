using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public void DecimalGames()
    {
        SceneManager.LoadScene("lvl1"); 
    }

    public void OpreationGames()
    {
        SceneManager.LoadScene("lvl2");
    }
    public void StoryNeuman()
    {
        SceneManager.LoadScene("lvl3");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }
}
