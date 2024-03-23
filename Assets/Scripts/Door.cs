using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour {

  public bool taken = false;
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      taken = true;
      GameManager.Instance.LoadNextLevel();
    }
  }
  private void OnTriggerExit2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      taken = false;
    }
  }
}
