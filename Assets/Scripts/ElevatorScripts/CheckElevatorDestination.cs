using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckElevatorDestination : MonoBehaviour
{
    public ElevatorData mElevatorData;

    private void OnTriggerEnter(Collider other)
    {
            FloorSensor floorSensor = other.gameObject.GetComponent<FloorSensor>();

            if (floorSensor == null)
                return;

        if (floorSensor.isActiveFloor)
        {
            mElevatorData.mElevatorMovementScript.IsStayed = true;
            mElevatorData.mElevatorMovementScript.ActualFloor = mElevatorData.mElevatorMovementScript.FloorDestination;
            floorSensor.isActiveFloor = false;
            mElevatorData.mAudio.StopSFX();
            mElevatorData.mAudio.PlaySFX(mElevatorData.mAudio.mElevatorBell);
            mElevatorData.mDoorController.OpenDoor();
        }
    }

}
