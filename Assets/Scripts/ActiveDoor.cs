using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDoor : MonoBehaviour {
  [SerializeField]
  private Sprite openSprite;
  [SerializeField]
  private Sprite closedSprite;
  private SpriteRenderer spriteRenderer;
  private BoxCollider2D boxCollider;

  private void Awake() {
    spriteRenderer = GetComponent<SpriteRenderer>();
    boxCollider = GetComponent<BoxCollider2D>();
  }

  public void OpenDoor() {
    if (spriteRenderer == null) return;
    spriteRenderer.sprite = openSprite;
    boxCollider.enabled = false;
  }

  public void CloseDoor() {
    if (spriteRenderer == null) return;
    spriteRenderer.sprite = closedSprite;
    boxCollider.enabled = true;
  }
}
