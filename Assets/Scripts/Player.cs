using System;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rigidbody2D;

    [SerializeField] private GameObject bulletGameObject;
    [SerializeField] private Transform bulletInstantiatePosition;
    private float force = 5f;
    private bool forcePressed;
    [SerializeField] private float rotationSpeed = 5f;
    private void Start(){
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if(Input.GetKey(KeyCode.W)){
            forcePressed = true;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.localRotation = transform.localRotation * Quaternion.Euler(0, 0, 1.0f * rotationSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.localRotation = transform.localRotation * Quaternion.Euler(0, 0, -1.0f * rotationSpeed * Time.deltaTime);            
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(bulletGameObject, bulletInstantiatePosition.position, Quaternion.identity);
        }
    }
    private void FixedUpdate(){
        if(forcePressed){
            ForceForPlayer();
            forcePressed = false;
        }
    }

    private void ForceForPlayer(){
        
        rigidbody2D.AddForce(transform.up * force);
    }
}