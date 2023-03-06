using UnityEngine.XR.Interaction.Toolkit;

public class XRDirectInteractorHandCheck : XRDirectInteractor
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if(args.interactableObject.transform.tag == "Car Part Left" || args.interactableObject.transform.tag == "Car Part Right" || args.interactableObject.transform.tag == "Car Part Front" || args.interactableObject.transform.tag == "Car Part Rear")
        {
            CarAssemble.canSnap = false;
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        if (args.interactableObject.transform.tag == "Car Part Left" || args.interactableObject.transform.tag == "Car Part Right" || args.interactableObject.transform.tag == "Car Part Front" || args.interactableObject.transform.tag == "Car Part Rear")
        {
            CarAssemble.canSnap = true;
        }          
    }
}
