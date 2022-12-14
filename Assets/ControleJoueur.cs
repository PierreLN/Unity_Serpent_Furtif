using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ControleJoueur : MonoBehaviour
{
    public float vitesse = 5.0f;
    public float vitesseLancer = 30.0f;
    public Vector2 direction = Vector2.zero;
    public Vector2 derniereDirection = Vector2.right;
    public Transform trPierre;
    private Rigidbody2D rig;

    private SpriteRenderer rendu;
    private bool once = false;
    private Vector2 sourceBruit;

    public int nbBombe = 3;
    public GameObject menu;
    private bool pauseGame = false;

    private UnityAction<object> bruit;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rendu = GetComponent<SpriteRenderer>();
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if (!pauseGame)
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
                if (nbBombe > 0)
                {
                    Transform pi = Instantiate(trPierre,transform.position,Quaternion.identity);
                    pi.GetComponent<Rigidbody2D>().AddForce(derniereDirection * vitesseLancer, ForceMode2D.Impulse);
                    nbBombe--;
                    EventManager.TriggerEvent("subtractBombe", nbBombe);
                }
            }
            Time.timeScale = 1.0f;

            if (Input.GetButtonDown("Fire1"))
            {
                pauseGame = true;
                menu.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {

        }
    }

    public void continuerJeux()
    {
        Time.timeScale = 1.0f;
        pauseGame = false;
        menu.SetActive(false);
    }

    public void ajouter()
    {
        nbBombe++;
    }

    public void soustraire()
    {
        nbBombe--;
    }

    private void FixedUpdate()
    {
        rig.velocity = direction * vitesse;
    }


    private void Awake()
    {
        bruit = new UnityAction<object>(reactionBruit);
    }

    private void OnEnable()
    {
        EventManager.StartListening("Ecoute", bruit);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Ecoute", bruit);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Mur"))
        {   
            EventManager.TriggerEvent("Ecoute", Color.red);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemie") ||
            collision.collider.gameObject.layer == LayerMask.NameToLayer("bouletteEnemie"))
        {
            SceneManager.LoadScene("Intro");
        }
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ami"))
        {
            EventManager.TriggerEvent("Fini", "fin");
        }
    }

    void reactionBruit(object data)
    {
        sourceBruit = transform.position;
        EventManager.TriggerEvent("Who", sourceBruit);

        StartCoroutine(COuch(data));
    }

    IEnumerator COuch(object data)
    {
        once = false;
        while (!once)
        {
            Color col = (Color)data;
            rendu.color = col;
            yield return new WaitForSeconds(0.3f);
            rendu.color = Color.white;
            once = true;
        }

    }
}
