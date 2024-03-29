using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SprayTriggerAnim : MonoBehaviour
{
    [SerializeField] InputActionProperty trigger;
    Animator triggerAnimator;
    bool isHeld;
    // Start is called before the first frame update
    void Start()
    {
        triggerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHeld)
        {
            float triggerValue = trigger.action.ReadValue<float>();
            triggerAnimator.SetFloat("Trigger", triggerValue);
        }
        
    }
    public void DoAnim()
    {
        isHeld = !isHeld;
    }
}
