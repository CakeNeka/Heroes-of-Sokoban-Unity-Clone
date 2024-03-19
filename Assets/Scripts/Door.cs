using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour {

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      GameManager.Instance.LoadNextLevel();
    }
  }
}
