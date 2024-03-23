using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WizardMovementHandler : MonoBehaviour, IMovementHandler {

    [SerializeField]
    public LayerMask layerMask;
    private float maxDistance = 100f;
    public bool tryMove(Vector3 direction) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, layerMask);
        // If an obstacle is found, switch positions
        if (hit.collider.CompareTag("Movable") || hit.collider.CompareTag("Player")) {
            Vector3 tempPlayerPosition = hit.collider.transform.position;

            hit.collider.transform.position = transform.position;
            transform.position = tempPlayerPosition;
            return true;
        }
        if (canMoveInDirection(direction)) {
            transform.position += direction;
            return true;
        }
        return false;
    }

    private bool canMoveInDirection(Vector3 direction) {
        Vector3 target = transform.position + direction;
        Collider2D[] colliders = Physics2D.OverlapPointAll(target);
        string[] overlappingTags = colliders.Select(c => c.tag).ToArray();
        return !overlappingTags.Contains("Wall");
    }
}
