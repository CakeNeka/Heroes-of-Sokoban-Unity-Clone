using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour {
    private bool playerActive = true;
    [SerializeField]
    private Sprite activeSprite;
    [SerializeField]
    private Sprite inactiveSprite;

    private IMovementHandler movementHandler;
    private SpriteRenderer spriteRenderer;
    void Awake() {
        movementHandler = GetComponent<IMovementHandler>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (!playerActive) return;

        if (Input.GetKeyDown(KeyCode.A)) {
            movementHandler.tryMove(new Vector3(-1, 0));
        } else if (Input.GetKeyDown(KeyCode.W)) {
            movementHandler.tryMove(new Vector3(0, 1));
        } else if (Input.GetKeyDown(KeyCode.D)) {
            movementHandler.tryMove(new Vector3(1, 0));
        } else if (Input.GetKeyDown(KeyCode.S)) {
            movementHandler.tryMove(new Vector3(0, -1));
        } else if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Activate() {
        playerActive = true;
        spriteRenderer.sprite = activeSprite;
    }

    public void Deactivate() {
        playerActive = false;
        spriteRenderer.sprite = inactiveSprite;
    }
}
