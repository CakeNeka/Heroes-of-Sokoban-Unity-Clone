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
    private ActiveDoor[] activeDoors;
    private Door[] levelDoors;
    private PlayerInput[] characters;
    private int activeCharacterIndex = 0;

    public Tilemap wallsTilemap;
    public static GameManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
            return;
        }
        Instance = this;
        buttons = FindObjectsOfType<Button>();
        activeDoors = FindObjectsOfType<ActiveDoor>();
        characters = FindObjectsOfType<PlayerInput>();
        levelDoors = FindObjectsOfType<Door>();
    }

    private void Start() {
        InitCharacters();
    }

    public void LoadNextLevel() {
        int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        // Debug.Log($"Next index: {nextBuildIndex}, scene count: {SceneManager.sceneCountInBuildSettings}, buttons down: {AllButtonsDown()}");

        if (levelDoors.All(d => d.taken) && SceneManager.sceneCountInBuildSettings > nextBuildIndex)
            SceneManager.LoadScene(nextBuildIndex);
    }


    private bool AllButtonsDown(int index) {
        return buttons.Where(b => b.blockingDoorIndex == index).All(b => b.isPressed());
    }

    public void UpdateActiveDoors() {

        int doorTypes = activeDoors.Length;
        for(int i = 0; i < activeDoors.Length; i++) {
            if (AllButtonsDown(i)) {
                activeDoors.Where(d => d.blockingDoorIndex == i).ToList().ForEach(d => d.OpenDoor());
            } else {
                activeDoors.Where(d => d.blockingDoorIndex == i).ToList().ForEach(d => d.CloseDoor());
            }
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            NextCharacter();
        }
    }


    public void InitCharacters() {
        characters.ToList().ForEach(c => c.Deactivate());
        characters[activeCharacterIndex].Activate();
    }

    public void NextCharacter() {
        characters[activeCharacterIndex].Deactivate();
        activeCharacterIndex = ++activeCharacterIndex == characters.Length ? 0 : activeCharacterIndex;
        characters[activeCharacterIndex].Activate();
    }
}
