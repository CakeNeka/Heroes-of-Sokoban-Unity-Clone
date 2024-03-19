using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour {
    public int blockingDoorIndex = 0;
    [SerializeField]
    private bool active = false;
    public bool isPressed() {
        return active;
        /*
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
        Debug.Log(string.Join(",", colliders.Select(c => c.ToString()).ToArray()));
        return colliders.Length > 0;
        */
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("Enter " + other.tag);
        active = true;
        GameManager.Instance.UpdateActiveDoors();
    }

    private void OnTriggerExit2D(Collider2D other) {
        // Debug.Log("Exit " + other.tag);
        active = false;
        GameManager.Instance.UpdateActiveDoors();
    }
}
