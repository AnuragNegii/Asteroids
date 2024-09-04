using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AsteroidSO")]
public class AsteroidSO : ScriptableObject{
    [SerializeField] private List<GameObject> asteroidGameObjects;

    public List<GameObject> GetAsteroidGameObjects(){ 
        List<GameObject> asteroidGameObject1 = new List<GameObject>();
        foreach(GameObject obj in asteroidGameObjects){
            asteroidGameObject1.Add(obj);
        }

        return asteroidGameObject1;
    }
}
