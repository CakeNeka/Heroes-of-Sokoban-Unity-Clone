using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    void Update() {
        if (Input.GetKeyDown(KeyCode.X))
            StartLevel();
    }

    private static void StartLevel() {
        int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextBuildIndex);
    }
}
