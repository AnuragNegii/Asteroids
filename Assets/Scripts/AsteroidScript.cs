using UnityEditor.Rendering;
using UnityEngine;

public class AsteroidScript : MonoBehaviour{
    [SerializeField] private AsteroidSO asteroidSO;
    float asteroidSpeed = 3.0f;

    private void Start(){
        MoveRotation();
    }

    private void Update(){
        transform.position += transform.up * asteroidSpeed * Time.deltaTime;
    }

    private void MoveRotation(){
        float zRotation = Random.Range(0, 360);
        transform.localRotation = transform.rotation * Quaternion.Euler(0 , 0, zRotation);
        Debug.Log(zRotation);
    }

    public void Split(){
        if(asteroidSO == null){
            Destroy(this.gameObject);
        }else{
        foreach(GameObject gameObject in asteroidSO.GetAsteroidGameObjects()){
            GameObject smallAsteroidPrefab = Instantiate(gameObject);
            smallAsteroidPrefab.transform.position = new Vector3(Random.Range(transform.position.x -1, transform.position.x+1), 
                                                                    Random.Range(transform.position.y -1, transform.position.y+1), 0);

            Destroy(this.gameObject);
        }
        }
    }
}
