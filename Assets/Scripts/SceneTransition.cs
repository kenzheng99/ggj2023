using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Debug.Log("start");
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("hit sceneBarrier");
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "FarmScene") {
            SceneManager.LoadScene("ForestScene");
        } else if (currentScene == "ForestScene") {
            SceneManager.LoadScene("FarmScene");
        } else {
            Debug.Log("SceneBarrier: unknown scene");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
