using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour {
    private Button[] buttons;
    private ActiveDoor[] doors;

    public Tilemap wallsTilemap;
    public static GameManager Instance { get; private set; }

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
            return;
        }
        Instance = this;
        buttons = FindObjectsOfType<Button>();
        doors = FindObjectsOfType<ActiveDoor>();
    }

    public void LoadNextLevel() {
        int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log($"Next index: {nextBuildIndex}, scene count: {SceneManager.sceneCountInBuildSettings}, buttons down: {AllButtonsDown()}");
        if (SceneManager.sceneCountInBuildSettings > nextBuildIndex)
            SceneManager.LoadScene(nextBuildIndex);
    }

    private bool AllButtonsDown() {
        return buttons.All(b => b.isPressed());
    }

    public void UpdateActiveDoors() {
        if (AllButtonsDown()) {
            doors.ToList().ForEach(d => d.OpenDoor());
            // TODO: Filter by index
        } else {
            doors.ToList().ForEach(d => d.CloseDoor());
        }
    }
}
