using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class number_bombe : MonoBehaviour
{
    public int nbBombe = 3;
    private TextMeshProUGUI textmeshPro;
    private UnityAction<object> explosion;


    // Start is called before the first frame update
    void Start()
    {
         textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textmeshPro.SetText("" + nbBombe);
    }

    private void Awake()
    {
        explosion = new UnityAction<object>(subBombe);
    }

    private void OnEnable()
    {
        EventManager.StartListening("subtractBombe", explosion);
    }

    private void OnDisable()
    {
        EventManager.StopListening("subtractBombe", explosion);
    }

    private void subBombe(object data)
    {
        nbBombe = (int)data;
    }
}
