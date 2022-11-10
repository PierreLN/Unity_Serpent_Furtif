using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJoueur : MonoBehaviour
{
    public float vitesse = 5.0f;
    public float vitesseLancer = 30.0f;
    public Vector2 direction = Vector2.zero;
    public Vector2 derniereDirection = Vector2.right;
    public Transform trPierre;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        if(direction.sqrMagnitude > 0.0001f)
        {
            derniereDirection = direction;
            direction.Normalize();
        }

        if (Input.GetButtonDown("Jump"))
        {
            Transform pi = Instantiate(trPierre,transform.position,Quaternion.identity);
            pi.GetComponent<Rigidbody2D>().AddForce(derniereDirection * vitesseLancer, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rig.velocity = direction * vitesse;
    }
}
