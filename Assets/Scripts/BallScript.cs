using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector2 ballInitialForce;
    Rigidbody2D rb;
    GameObject playerObj;
    float deltaX;
    
    AudioSource audioSrc;
    public AudioClip hitSound;
    public AudioClip loseSound;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        deltaX = transform.position.x;
        audioSrc = Camera.main.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (rb.isKinematic)
            if (Input.GetButtonDown("Fire1"))
            {
                rb.isKinematic = false;
                rb.AddForce(ballInitialForce);
            }
            else
            {
                var pos = transform.position;
                pos.x = playerObj.transform.position.x + deltaX;
                transform.position = pos;
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        audioSrc.PlayOneShot(loseSound);
        Destroy(gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSrc.PlayOneShot(hitSound);
    }

}