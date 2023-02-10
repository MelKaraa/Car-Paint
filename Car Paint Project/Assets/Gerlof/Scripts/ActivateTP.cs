using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTP : MonoBehaviour
{
    public static bool wantTP;
    [SerializeField] GameObject rightTeleportObj;
    [SerializeField] InputActionProperty rightActivate;
    [SerializeField] GameObject tpRay;

    void Update()
    {
        if(wantTP)
        {
            tpRay.SetActive(true);
            GetComponent<TeleportationProvider>().enabled = true;
            rightTeleportObj.SetActive(rightActivate.action.ReadValue<float>() > 0.1f);
        }
        else
        {
            tpRay.SetActive(false);
            GetComponent<TeleportationProvider>().enabled = false;
        }
    }
}
 