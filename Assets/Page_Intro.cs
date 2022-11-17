using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Page_Intro : MonoBehaviour
{
    public string scene_next;
    public void lorsCommencer()
    {
        SceneManager.LoadScene(scene_next);
    }

    public void lorsQuitter()
    {
        Debug.Log("quitting");
    }
}
