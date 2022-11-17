using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Garde : MonoBehaviour
{
    private Rigidbody2D rig;
    public float forceImpulsion = 0.5f;
    private UnityAction<object> cible;
    private UnityAction<object> explosion;
    private Vector2 direction;
    public GameObject boom;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        cible = new UnityAction<object>(reactionFoncer);
        explosion = new UnityAction<object>(explosionBooom);
    }

    private void OnEnable()
    {
        EventManager.StartListening("Who", cible);
        EventManager.StartListening("Boom", explosion);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Who", cible);
        EventManager.StopListening("Boom", explosion);
    }


    void reactionFoncer(object data)
    {
        direction = (Vector2)data - (Vector2)transform.position;
        direction.Normalize();
        rig.AddForce(direction * forceImpulsion, ForceMode2D.Impulse);
    }

    void explosionBooom(object data)
    {
        Instantiate(boom, (Vector2)data, Quaternion.identity);
    }
}
