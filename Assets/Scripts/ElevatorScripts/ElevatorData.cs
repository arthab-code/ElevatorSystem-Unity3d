using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorData : MonoBehaviour
{
    [Header("Floor switches")]
    public List<FloorSwitch> mFloorSwitches;
    [Header("Inside switches")]
    public List<FloorSwitch> mInsideSwitches;
    [Header("Floor sensors - checking when elevator have to stay")]
    public List<FloorSensor> mFloorSensors;
    [Header("Elevator Movement Script")]
    public ElevatorMovement mElevatorMovementScript;
    [Header("Door Controller Script")]
    public DoorController mDoorController;
    [Header("Door Animator")]
    public Animator mDoorAnimator;
    [Header("Sounds")]
    public ElevatorAudioController mAudio;
    [Header("Door Open Time")]
    public float mOpenDoorTime = 10f;
    [Header("Elevator Speed")]
    public float mElevatorSpeed = 30f;


    // Start is called before the first frame update
    void Start()
    {
        SetUpFloorSwitches();
        SetUpInsideFloorSwitches();
    }

    private void SetUpFloorSwitches()
    {
       for (int i = 0; i < mFloorSwitches.Count; i++)
        {
            mFloorSwitches[i].mFloorNumber = i;
        }
    }

    private void SetUpInsideFloorSwitches()
    {
        for (int i = 0; i < mInsideSwitches.Count; i++)
        {
            mInsideSwitches[i].mFloorNumber = i;
        }
    }


}
