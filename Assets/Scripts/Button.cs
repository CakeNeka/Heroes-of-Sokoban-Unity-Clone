using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour {
    public int blockingDoorIndex = 0;
    private bool active = false;
    public bool isPressed() {
        return Physics2D.OverlapPointAll(transform.position).Length > 1;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameManager.Instance.UpdateActiveDoors();
    }

    private void OnTriggerExit2D(Collider2D other) {
        GameManager.Instance.UpdateActiveDoors();
    }
}
