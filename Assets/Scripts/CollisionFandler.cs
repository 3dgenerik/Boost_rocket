using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionFandler : MonoBehaviour
{
    int sceneIndex;
    int allScenes;

    public void Start(){
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        allScenes = SceneManager.sceneCountInBuildSettings;
    }

    void OnCollisionEnter(Collision other) {
        switch(other.collider.tag){
            case "Starting":
                Debug.Log("Starting");
                break;
            case "Landing":
                Debug.Log("Landing");
                NewScene();
                break;
            case "Obstacle":
                Debug.Log("Obstacle");
                ReloadScene();
                break;
            default:
                Debug.Log("What's that?");
                break;
        }   
    }

    private void ReloadScene(){
        SceneManager.LoadScene(sceneIndex);

    }

    private void NewScene(){
        if(sceneIndex == (allScenes - 1)){
            SceneManager.LoadScene(0);
            return;
        }
        SceneManager.LoadScene(sceneIndex+1);
    }


}
