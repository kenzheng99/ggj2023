using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
    private GameManager gameManager;

    void Awake() {
        gameManager = GameManager.Instance;
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("hit sceneBarrier");
        if (other.gameObject.CompareTag("Player"))
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "FarmScene") {
                gameManager.LoadForestScene(other.transform.position.x);
            } else if (currentScene == "ForestScene") {
                gameManager.LoadFarmScene(other.transform.position.x);
            } else {
                Debug.Log("SceneBarrier: unknown scene");
            }
        }
    }
}
