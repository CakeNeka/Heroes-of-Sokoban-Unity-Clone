using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OutroLevel : MonoBehaviour
{
    private PlayerInput[] characters;
    void Start()
    {
        characters = FindObjectsOfType<PlayerInput>();
        StartCoroutine(AutoMovement());
    }

    private IEnumerator AutoMovement() {
        for (int i = 0; i < 10; i++) {
            yield return new WaitForSeconds(.15f);
            characters.ToList().ForEach(ch => ch.transform.position += Vector3.right );
        }
    }
}
