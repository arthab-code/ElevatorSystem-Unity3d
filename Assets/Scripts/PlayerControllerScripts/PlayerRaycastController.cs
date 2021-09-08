using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastController : MonoBehaviour
{

    public Camera mPlayerCamera;
    public float mRange = 250f;

    // Update is called once per frame
    void Update()
    {
        RaycastHit();
    }

   private void RaycastHit()
    {
     
        if (Input.GetButtonDown("Fire1"))
        {
            InteractRaycast();
        }

    }

    private void InteractRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(mPlayerCamera.transform.position, mPlayerCamera.transform.forward, out hit, mRange))
        {
            if (hit.collider.GetComponent<IInteractable>() == null)
                return;

            IInteractable interactObject = hit.collider.GetComponent<IInteractable>();
            CallInteractObject(interactObject);         
        }
    }

    private void CallInteractObject(IInteractable interactObj)
    {
        interactObj.Interact();
    }
}
