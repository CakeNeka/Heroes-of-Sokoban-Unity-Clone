using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    private IMovementHandler movementHandler;
    void Awake() {
        movementHandler = GetComponent<IMovementHandler>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            movementHandler.tryMove(new Vector3(-1, 0));
        } else if (Input.GetKeyDown(KeyCode.W)){
            movementHandler.tryMove(new Vector3(0, 1));
        } else if (Input.GetKeyDown(KeyCode.D)){
            movementHandler.tryMove(new Vector3(1, 0));
        } else if (Input.GetKeyDown(KeyCode.S)){
            movementHandler.tryMove(new Vector3(0, -1));
        } else if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
