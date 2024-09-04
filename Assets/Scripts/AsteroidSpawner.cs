using UnityEngine;

public class AsteroidSpawner : MonoBehaviour{   

    [SerializeField] private Transform[] asteroidGameObjects;
    private float xDampPos = 8.2f;
    private float yDampPos = 4.2f;
    
    private float xMinDamPos = 5.0f;
    private float yMinDamPos = 2.5f;
    private float timeToSpawn = 2.0f;

    private void Update(){
        SpawnTheObject();
    }

    private void SpawnTheObject(){
        Vector3 areaToSpawn;
        timeToSpawn -= Time.deltaTime;
        if(timeToSpawn < 0){
            int number = Random.Range(0, asteroidGameObjects.Length);
            do{
                float xPos = Random.Range(-xDampPos, xDampPos);
                float yPos = Random.Range(-yDampPos, yDampPos);
                areaToSpawn = new Vector3(xPos, yPos, 0);
            }while(IsWithinHollowArea(areaToSpawn));
            
            Transform asteroid = Instantiate(asteroidGameObjects[number]);
            asteroid.transform.position = areaToSpawn;
            timeToSpawn = 2.0f;
        }
    }

    private bool IsWithinHollowArea(Vector3 position){
        return position.x > -xMinDamPos && position.x < xMinDamPos && position.y > -yMinDamPos && position.y < yMinDamPos;
    }
}
