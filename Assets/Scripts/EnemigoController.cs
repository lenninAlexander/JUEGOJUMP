using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag=="Plataforma")
        {
            speed *= -1;
            this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
        }
    }
}
