using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int puntosGanados = 1;
    private PlayerController playerController;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        playerController.IncrementarPuntajeen100();
    }
}
