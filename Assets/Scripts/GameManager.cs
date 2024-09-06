using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{   
    public static GameManager Instance{get; private set;}
    [SerializeField] private Transform[] asteroidGameObjects;
    [SerializeField] private Transform asteroidParent;
    [SerializeField] private Image image;
    private void Awake(){
        if(Instance != null){
            Debug.LogError("There is more than one Game Manager" + Instance.gameObject.name);
        }
        Instance = this;
    }
    private void Start(){
        Player.Instance.YouDiedEvent += Player_YouDiedEvent;
        Time.timeScale = 0;
    }

    private float xDampPos = 8.2f;
    private float yDampPos = 4.2f;
    private float xMinDamPos = 5.0f;
    private float yMinDamPos = 2.5f;
    private float timeToSpawnAsteroid = 4.0f;

    private void Update(){
        SpawnTheObject();
        if(Input.GetKeyDown(KeyCode.Escape)){
            image.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            image.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void SpawnTheObject(){
        Vector3 areaToSpawn;
        timeToSpawnAsteroid -= Time.deltaTime;
        if(timeToSpawnAsteroid < 0){
            int number = UnityEngine.Random.Range(0, asteroidGameObjects.Length);
            do{
                float xPos = UnityEngine.Random.Range(-xDampPos, xDampPos);
                float yPos = UnityEngine.Random.Range(-yDampPos, yDampPos);
                areaToSpawn = new Vector3(xPos, yPos, 0);
            }while(IsWithinHollowArea(areaToSpawn));
            
            Transform asteroid = Instantiate(asteroidGameObjects[number]);
            asteroid.transform.position = areaToSpawn;
            asteroid.transform.parent = asteroidParent;
            timeToSpawnAsteroid = 2.0f;
        }
    }

    private bool IsWithinHollowArea(Vector3 position){
        return position.x > -xMinDamPos && position.x < xMinDamPos && position.y > -yMinDamPos && position.y < yMinDamPos;
    }
    public Image GetImageComponent(){
        return image;
    }
    private void Player_YouDiedEvent(object sender, EventArgs e){
        SceneManager.LoadScene(0);
    }

    private void DestroyEverything(){
        foreach( Transform child in asteroidParent){
            Destroy(child.gameObject);
        }
    }
}
