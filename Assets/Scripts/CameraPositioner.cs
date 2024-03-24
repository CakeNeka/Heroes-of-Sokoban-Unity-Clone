using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraPositioner : MonoBehaviour {
    private Tilemap wallsTilemap;
    private Camera cam;
    private float margin = .5f;
    private void Start() {
        wallsTilemap = GameManager.Instance.wallsTilemap;
        cam = Camera.main;
        CenterCamera();
        FitLevel();
    }

    private void CenterCamera() {
        wallsTilemap.CompressBounds();

        BoundsInt bounds = wallsTilemap.cellBounds;// Represents an axis aligned bounding box with all values as integers.
        Vector3 center = bounds.center;
        center.z = cam.transform.position.z;
        cam.transform.position = center;
    }

    private void FitLevel() {
        BoundsInt bounds = wallsTilemap.cellBounds;
        Vector3 levelTopRight = bounds.max;
        Vector3 levelTopLeft = bounds.min;
        Vector3 camTopRight = cam.ViewportToWorldPoint(new Vector3(1,1));

        // Vertical overflow
        if (levelTopRight.y + margin > camTopRight.y) {
            float levelSize = levelTopRight.y - levelTopLeft.y;
            cam.orthographicSize = levelSize / 2 + margin;
        }

        // Horizontal overflow (ugly workaround)
        int i = 0;
        while (levelTopRight.x > camTopRight.x && ++i < 100) {
            cam.orthographicSize += margin;
            camTopRight = cam.ViewportToWorldPoint(new Vector3(1,1));
        }
    }
}
