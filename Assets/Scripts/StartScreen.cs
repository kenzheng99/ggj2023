using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
    [SerializeField] private GameObject creditsObject;
    public void StartGame() {
        SceneManager.LoadScene("FarmScene");
    }

    public void ShowCredits() {
        creditsObject.SetActive(true);
    }

    public void HideCredits() {
        creditsObject.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }
    
}
