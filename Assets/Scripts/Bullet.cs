using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletLifespan = 3.0f;
    [SerializeField] private float bulletSpeed = 5f;
    private Rigidbody2D rigidbody2D;

    private void Start(){
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update(){
        bulletLifespan -= Time.deltaTime;
        if(bulletLifespan < 0){
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate(){
        rigidbody2D.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
