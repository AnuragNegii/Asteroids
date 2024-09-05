using UnityEngine;

public class WallX : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Asteroid" ){
            Debug.Log("Entered");
            other.gameObject.GetComponent<AsteroidScript>().OutOfBoundsX();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Player>().OutOfBoundsX();
        }
    }
}
