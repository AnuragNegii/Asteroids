using UnityEngine;

public class AsteroidScript : MonoBehaviour, IAllObjects{
    [SerializeField] private AsteroidSO asteroidSO;
    [SerializeField] private GameObject asteroidParent;
    float asteroidSpeed = 2.0f;
    private void Start(){
        asteroidParent = GameObject.Find("AllAsteroids");
        MoveRotation();
    }
    private void Update(){
        transform.position += transform.up * asteroidSpeed * Time.deltaTime;
    }

    private void MoveRotation(){
        float zRotation = Random.Range(0, 360);
        transform.localRotation = transform.rotation * Quaternion.Euler(0 , 0, zRotation);
    }

    public void Split(){
        if(asteroidSO == null){
            Destroy(this.gameObject);
        }else{
        foreach(GameObject gameObject in asteroidSO.GetAsteroidGameObjects()){
            GameObject smallAsteroidPrefab = Instantiate(gameObject);
            smallAsteroidPrefab.transform.parent = asteroidParent.transform;
            smallAsteroidPrefab.transform.position = new Vector3(Random.Range(transform.position.x -1, transform.position.x+1), 
                                                                    Random.Range(transform.position.y -1, transform.position.y+1), 0);

            Destroy(this.gameObject);
        }
        }
    }

    public void OutOfBoundsY(){
        if(transform.position.y > 0){
            transform.position = new Vector3(transform.position.x, (transform.position.y * -1 )+ 0.5f, 0);
        }else if(transform.position.y < 0){
            transform.position = new Vector3(transform.position.x, (transform.position.y * -1 )- 0.5f, 0);
        }
    }

    public void OutOfBoundsX(){
        if(transform.position.x > 0){
            transform.position = new Vector3((transform.position.x * -1 )+ 0.5f, transform.position.y,0);
        }else if(transform.position.x < 0){
            transform.position = new Vector3((transform.position.x * -1 )- 0.5f, transform.position.y,0);
        }
    }

}
