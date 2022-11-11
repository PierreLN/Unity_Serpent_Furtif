using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ami : MonoBehaviour
{
    private UnityAction<object> fini;

    void Start()
    {
        
    }

    private void Awake()
    {
        fini = new UnityAction<object>(finiPouf);
    }

    private void OnEnable()
    {
        EventManager.StartListening("Fini", fini);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Fini", fini);
    }

    void finiPouf(object data)
    {
        Time.timeScale = 0;
        Debug.Log(data);

    }
}
