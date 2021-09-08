using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public ElevatorData mElevatorData;
    public int FloorDestination
    {
        get => mFloorDestination;
        set
        {
            mFloorDestination = value;
        }
    }
    public bool IsStayed
    {
        get => isStayed;
        set
        {
            isStayed = value;
        }
    }

    public int ActualFloor
    {
        get => mActualFloor;
        set
        {
            mActualFloor = value;
        }
    }
    private int mFloorDestination  = 0;
    private int mActualFloor = 0;
    private bool isStayed = true;

    public enum MoveStatus
    {
        Stay,
        Up,
        Down
    }

    public MoveStatus mMoveStatus = MoveStatus.Stay;

    // Update is called once per frame
    void Update()
    {
        CheckDestinyFloor();
        ElevatorMovementLogic();
    }

    private void ElevatorMovementLogic()
    {
        switch (mMoveStatus)
        {
            case MoveStatus.Stay:

                break;

            case MoveStatus.Up:
                MoveElevator(1);

                break;

            case MoveStatus.Down:
                MoveElevator(-1);

                break;
        }
    }

    private void MoveElevator(float direction)
    {
        mElevatorData.mAudio.PlaySFX(mElevatorData.mAudio.mElevatorRide);
        transform.position += new Vector3(0f, direction, 0f) * Time.deltaTime * mElevatorData.mElevatorSpeed;
    }

    private void CheckDestinyFloor()
    {
        if (isStayed == true)
            mMoveStatus = MoveStatus.Stay;
    }


}
