using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour
{
    public float speed = 50;
    public float upSpeed = 100;
    
    
    private bool puedoSaltar = false;
    
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;
    public Text scoreTexto;
    private int Score = 0;
    private bool morir = false;
    //public GameObject rightBullet;
    //public GameObject leftBullet;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // obtengo el objeto spriterenderer de Player
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {

        scoreTexto.text = "Puntaje" + Score;
        setIdleAnimation();
       
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            setRunAnimation();
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            sr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            setRunAnimation();
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            sr.flipX = true;
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            setJumpAnimation();
            rb2d.velocity = Vector2.up * upSpeed;
            puedoSaltar = false;
        }
        if (morir)
        {
            SceneManager.LoadScene("Perdiste");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 8)
            puedoSaltar = true;
        
        if(other.gameObject.layer == 9)
            SceneManager.LoadScene("Perdiste");
        if (other.gameObject.layer == 7)
        {
            morir = true;
        }
    }

   

    private void setRunAnimation()
    {
        animator.SetInteger("Estado", 1);
    }
    
    private void setJumpAnimation()
    {
        animator.SetInteger("Estado", 2);
    }
    
    private void setIdleAnimation()
    {
        animator.SetInteger("Estado", 0);
    }
    public void IncrementarPuntajeen100()
    {
       Score += 100;
    }
}
