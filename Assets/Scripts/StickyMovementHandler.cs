using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StickyMovementHandler : MonoBehaviour, IMovementHandler {

    public bool tryMove(Vector3 direction) {
        Vector3 target = transform.position + direction;
        if (canMoveToPosition(target)) {
            Vector3 blockPosition = transform.position - direction;
            transform.position = target;
            moveBlockAt(blockPosition, direction);
            return true;
        }
        
        return false;
    }

    private void moveBlockAt(Vector3 blockPosition, Vector3 direction) {
        Collider2D[] colliders = Physics2D.OverlapPointAll(blockPosition);
        Collider2D blockCollider = colliders.Where(c => c.CompareTag("Movable") || c.CompareTag("Player")).FirstOrDefault();
        if (blockCollider != null) {
            blockCollider.transform.position += direction;
        }
    }

    private bool canMoveToPosition(Vector3 position) {
        Vector2 target = new Vector2(position.x, position.y);

        Collider2D[] colliders = Physics2D.OverlapPointAll(target);
        string[] overlappingTags = colliders.Select(c => c.tag).ToArray();
        // Debug.Log(string.Join(",",overlappingTags));

        return !(overlappingTags.Contains("Wall") || overlappingTags.Contains("Movable") || overlappingTags.Contains("Player"));
    }
}
