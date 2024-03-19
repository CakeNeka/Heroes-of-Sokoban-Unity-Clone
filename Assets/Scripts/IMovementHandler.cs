using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementHandler {

    bool tryMove(Vector3 direction);

}
