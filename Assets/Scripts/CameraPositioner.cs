using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraPositioner : MonoBehaviour {
    private Tilemap wallsTilemap;
    private void Start() {
        wallsTilemap = GameManager.Instance.wallsTilemap;
        wallsTilemap.CompressBounds();

        BoundsInt bounds = wallsTilemap.cellBounds;// Represents an axis aligned bounding box with all values as integers.
        Vector3 center = bounds.center;
        Debug.DrawRay(center, Vector3.up * 2);
        center.z = Camera.main.transform.position.z;
        Camera.main.transform.position = center;
    }

    private void Update() {
        BoundsInt bounds = wallsTilemap.cellBounds;
        Debug.DrawRay(bounds.max, Vector3.up * 1, Color.red);
        Debug.DrawRay(bounds.min, Vector3.up * 1, Color.red);
    }

}
