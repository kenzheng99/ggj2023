using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
    private GameManager gameManager;
    private UiManager UM;
    //private bool showDialogue = true;

    void Awake() {
        gameManager = GameManager.Instance;
        UM = GameObject.Find("UiManager").GetComponent<UiManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("hit sceneBarrier");
        if (other.gameObject.CompareTag("Player"))
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "FarmScene") {
                gameManager.LoadForestScene(other.transform.position.x);
                // if (showDialogue) {
                //     UM.CreateDialogue(
                //     "Great! You made it to the forest.\nLooks like there's some people over there\nGo say hi!");
                //     showDialogue = false;
                // }
            } else if (currentScene == "ForestScene") {
                gameManager.LoadFarmScene(other.transform.position.x);
            } else {
                Debug.Log("SceneBarrier: unknown scene");
            }
        }
    }
}
