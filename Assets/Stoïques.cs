using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stoïques : MonoBehaviour
{
    public GameObject stoïquesBoulette;
    private UnityAction<object> cible;
    private Vector3 pop;

    void Start()
    {
        pop = new Vector3(-0.5f, 1.0f,0.0f);
    }

    void Update()
    {
        
    }

    private void Awake()
    {
        cible = new UnityAction<object>(reactionFoncer);
    }

    private void OnEnable()
    {
        EventManager.StartListening("Who", cible);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Who", cible);
    }


    void reactionFoncer(object data)
    {
        Instantiate(stoïquesBoulette, transform.position+pop, Quaternion.identity);
    }
}
