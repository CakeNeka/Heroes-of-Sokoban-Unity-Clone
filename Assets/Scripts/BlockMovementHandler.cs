using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BlockMovementHandler : MonoBehaviour, IMovementHandler {
    public bool tryMove(Vector3 direction) {
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
        // Debug.Log(string.Join(",",overlappingTags));

        if (overlappingTags.Contains("Wall")) {
            return false;
        }
        if (overlappingTags.Contains("Movable")) {
            foreach (Collider2D collider in colliders) {
                if (collider.TryGetComponent<BlockMovementHandler>(out BlockMovementHandler handler)) {
                    return handler.tryMove(direction);
                }
            }
        }
        if (overlappingTags.Contains("Player")) {
            Collider2D characterCollider = colliders.Where(c => c.tag == "Player").First();
            if (characterCollider.TryGetComponent<BlockMovementHandler>(out BlockMovementHandler handler)) {
                return handler.tryMove(direction);
            } else {
                BlockMovementHandler newHandler = characterCollider.AddComponent<BlockMovementHandler>();
                return newHandler.tryMove(direction);
            }
        }

        return true;
    }
}
