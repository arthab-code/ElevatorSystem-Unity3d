using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSwitch : MonoBehaviour, IInteractable
{
    public int mFloorNumber = default(int);
    public ElevatorData mElevatorData;

    private WaitForSeconds mWaitValue = new WaitForSeconds(1.5f);
    public void Interact()
    {
        StartCoroutine("ElevatorMechanism");
    }

    private IEnumerator ElevatorMechanism()
    {
        if (mElevatorData.mElevatorMovementScript.FloorDestination == mFloorNumber)
        {
            mElevatorData.mAudio.StopSFX();
            mElevatorData.mAudio.PlaySFX(mElevatorData.mAudio.mElevatorBell);
        }

        ResetFloors();
        mElevatorData.mFloorSensors[mFloorNumber].SetActiveFloor(true);
        if (mElevatorData.mElevatorMovementScript.FloorDestination != mFloorNumber)
        {
            mElevatorData.mAudio.StopSFX();
            mElevatorData.mDoorController.CloseDoor();
            mElevatorData.mAudio.PlaySFX(mElevatorData.mAudio.mDoorAction);

            yield return mWaitValue;

            if (mElevatorData.mElevatorMovementScript.FloorDestination < mFloorNumber)
                mElevatorData.mElevatorMovementScript.mMoveStatus = ElevatorMovement.MoveStatus.Up;

            if (mElevatorData.mElevatorMovementScript.FloorDestination > mFloorNumber)
                mElevatorData.mElevatorMovementScript.mMoveStatus = ElevatorMovement.MoveStatus.Down;

            mElevatorData.mElevatorMovementScript.FloorDestination = mFloorNumber;
            mElevatorData.mElevatorMovementScript.IsStayed = false;

        }

        if (mElevatorData.mElevatorMovementScript.FloorDestination == mFloorNumber && mElevatorData.mElevatorMovementScript.IsStayed == true)
        {
            mElevatorData.mDoorController.OpenDoor();
        }
    }

    private void ResetFloors()
    {
        foreach (var script in mElevatorData.mFloorSensors)
            script.SetActiveFloor(false);

    }
}
