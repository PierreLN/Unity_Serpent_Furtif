using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Page_menu : MonoBehaviour
{
    private int nbBombe = 3;
    public void continuerJeux()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Furtif");
    }

    public void pauseJeux()
    {
        Time.timeScale = 0.0f;
    }

    public void ajouter()
    {
        nbBombe++;
    }

    public void soustraire()
    {
        nbBombe--;
    }
}
