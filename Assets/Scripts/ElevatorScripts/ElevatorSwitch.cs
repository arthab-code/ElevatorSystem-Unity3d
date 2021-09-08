using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSwitch : MonoBehaviour, IInteractable
{
    public ElevatorData mElevatorData;

    public void Interact()
    {
        if(mElevatorData.mElevatorMovementScript.IsStayed)
          mElevatorData.mDoorController.OpenDoor();

        mElevatorData.mDoorController.ResetTimeCounter();

    }


}
