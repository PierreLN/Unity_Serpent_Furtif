using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lanceur : MonoBehaviour
{
    private Rigidbody2D rig;
    private UnityAction<object> cible;
    private Vector2 direction;
    public float forceImpulsion = 1.5f;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

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
        direction = (Vector2)data - (Vector2)transform.position;
        rig.AddForce(direction * forceImpulsion, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Mur"))
        {
            Destroy(this.gameObject);
        }


    }
}
