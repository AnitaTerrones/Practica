using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManControler : MonoBehaviour
{
    //public properties
    public float velocityX = 15;
    public float JumpForce = 40;
    
    //private components
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    //Const
    private const int ANIMATION_IDLE = 0;
    private const int ANIMATION_RUN = 1;
    private const int ANIMATION_JUMP = 2;
    private const int ANIMATION_DESLIZAR = 3;
    private const int ANIMATION_DEAD = 4;


    private const int LAYER_GROUND = 6;//suelo

    void Start()
    {
        Debug.Log("Iniciando Game Objet");//mensaje en consola
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = new Vector2(5, rb.velocity.y);
        changeAnimation(ANIMATION_RUN);

        //deslizar
        if(Input.GetKey(KeyCode.S))
        {
            changeAnimation(ANIMATION_DESLIZAR);
        }
        
        //saltar
        if(Input.GetKeyUp(KeyCode.Space) )
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            changeAnimation(ANIMATION_JUMP);
        }
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        //si choca mientras desliza el enemy muere
        if (collision.gameObject.tag == "Enemy" && Input.GetKey(KeyCode.S))
        {
            Destroy(collision.gameObject);
        }
    }

    //Detecta si traspasa algo 
    private void OnTriggerEnter2D(Collider2D collider)
    {
       Debug.Log("Trigger:" + this.name);
       //saltar
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
