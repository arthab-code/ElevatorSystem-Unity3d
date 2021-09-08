using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSensor : MonoBehaviour
{
    public bool isActiveFloor = false;

    public void SetActiveFloor(bool value)
    {
        isActiveFloor = value;

    }

}
