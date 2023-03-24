using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour
{
    [SerializeField] GameObject leftGrabRay;
    [SerializeField] GameObject rightGrabRay;

    [SerializeField] XRDirectInteractorHandCheck leftDirectGrab;
    [SerializeField] XRDirectInteractorHandCheck rightDirectGrab;

    void Update()
    {
        leftGrabRay.SetActive(leftDirectGrab.interactablesSelected.Count == 0);
        rightGrabRay.SetActive(rightDirectGrab.interactablesSelected.Count == 0);
    }
}
