using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class XRGrabInteractibleTwoAttach : XRGrabInteractable
{
    public Transform leftHandAttach;
    public Transform rightHandAttach;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject.transform.CompareTag("Left Hand"))
        {
            attachTransform = leftHandAttach;
        }
        else if (args.interactorObject.transform.CompareTag("Right Hand"))
        {
            attachTransform = rightHandAttach;
        }

        base.OnSelectEntered(args);
    }

}
