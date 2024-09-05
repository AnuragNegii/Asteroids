using UnityEngine;

public class Player : MonoBehaviour, IAllObjects {

    private Rigidbody2D rigidBody2D;

    [SerializeField] private GameObject bulletGameObject;
    [SerializeField] private Transform bulletInstantiatePosition;
    private float force = 5f;
    private bool forcePressed;
    [SerializeField] private float rotationSpeed = 5f;
    private void Start(){
        rigidBody2D = GetComponent<Rigidbody2D>();
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
            GameObject bulletPrefab = Instantiate(bulletGameObject, bulletInstantiatePosition.position, Quaternion.identity);
            bulletPrefab.transform.rotation = transform.rotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Asteroid"){
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "WallX"){
            OutOfBoundsX();
        }
        if(other.gameObject.tag == "WallY"){
            OutOfBoundsY();
        }
    }
    private void FixedUpdate(){
        if(forcePressed){
            ForceForPlayer();
            forcePressed = false;
        }
    }

    private void ForceForPlayer(){
        rigidBody2D.AddForce(transform.up * force);
    }
    public void OutOfBoundsY(){
        if(transform.position.y > 0){
            transform.position = new Vector3(transform.position.x, (transform.position.y * -1 )+ 0.5f, 0);
        }else if(transform.position.y < 0){
            transform.position = new Vector3(transform.position.x, (transform.position.y * -1 )- 0.5f, 0);
        }
    }

    public void OutOfBoundsX(){

        Debug.Log("Triggered");
        if(transform.position.x > 0){
            transform.position = new Vector3((transform.position.x * -1 )+ 0.5f, transform.position.y,0);
        }else if(transform.position.x < 0){
            transform.position = new Vector3((transform.position.x * -1 )- 0.5f, transform.position.y,0);
        }
    }
}