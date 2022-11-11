using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Pierre : MonoBehaviour
{
    private Vector2 sourceExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Mur") ||
            collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemie"))
        {
            sourceExplosion = transform.position;
            EventManager.TriggerEvent("Boom", sourceExplosion);
            Destroy(this.gameObject);
        }


    }
}
