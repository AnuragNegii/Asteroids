using UnityEngine;

public class WallY : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Asteroid" ){
            other.gameObject.GetComponent<AsteroidScript>().OutOfBoundsY();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Player>().OutOfBoundsX();
        }
    }
}
