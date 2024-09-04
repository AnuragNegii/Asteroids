using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletLifespan = 3.0f;
    [SerializeField] private float bulletSpeed = 5f;
    private Rigidbody2D rigidBody2D;

    private void Start(){
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void Update(){
        bulletLifespan -= Time.deltaTime;
        if(bulletLifespan <= 0){
            Destroy(gameObject);
        }
    }
    private void FixedUpdate(){
        rigidBody2D.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Asteroid"){
            other.gameObject.GetComponent<AsteroidScript>().Split();
            Destroy(gameObject);
        }
    }
}
