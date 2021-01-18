using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCombat : MonoBehaviour
{
    public GameObject explosion, playerExplosion;
    public int scoreValue;
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("GameController");
        if (g != null)
        {
            gc = g.GetComponent < GameController>();
        }
        if(gc==null)
        {
            Debug.Log("Cannot Find Game Controller");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
        Instantiate(explosion, transform.position, transform.rotation);
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gc.gameOverFun();
        }
        gc.addScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
