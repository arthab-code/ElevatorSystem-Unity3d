using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public ElevatorData mElevatorData;

    public float TimeToOpenDoor
    {
        get => mTimeToOpenDoor;
        set
        {
            mTimeToOpenDoor = value;
        }
    }
    private float mTimeToOpenDoor = 0f;

    // Update is called once per frame
    void Update()
    {
        TimeCounter();

        if (mTimeToOpenDoor > mElevatorData.mOpenDoorTime && !mElevatorData.mDoorAnimator.GetBool("isSensorStayed"))
        {
            CloseDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        mElevatorData.mDoorAnimator.SetBool("isSensorStayed", true);
    }

    private void OnTriggerExit(Collider other)
    {
        mElevatorData.mDoorAnimator.SetBool("isSensorStayed", false);
        ResetTimeCounter();
    }

    private void TimeCounter()
    {
        mTimeToOpenDoor += Time.deltaTime;
    }

    public void ResetTimeCounter()
    {
        mTimeToOpenDoor = 0f;
    }

    public void CloseDoor()
    {
        mElevatorData.mDoorAnimator.SetBool("isOpen", false);
        mElevatorData.mDoorAnimator.SetBool("isClosed", true);
    }

    public void OpenDoor()
    {
        mTimeToOpenDoor = 0f;
        mElevatorData.mDoorAnimator.SetBool("isOpen", true);
        mElevatorData.mDoorAnimator.SetBool("isClosed", false);
    }

    public bool IsOpened()
    {
        return mElevatorData.mDoorAnimator.GetBool("isOpen");
    }
}
