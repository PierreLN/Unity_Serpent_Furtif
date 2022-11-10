using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Garde : MonoBehaviour
{
    private Rigidbody2D rig;
    public float forceImpulsion = 0.5f;
    private UnityAction<object> cible;
    private Vector2 direction;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
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
        direction = (Vector2)data;
        rig.AddForce(direction * forceImpulsion, ForceMode2D.Impulse);
    }
}
