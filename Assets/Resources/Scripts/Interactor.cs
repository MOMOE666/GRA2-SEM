using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public LayerMask interactableLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckInteracte();
        }
    }

    private void CheckInteracte()
    {
        Collider[] colliders = Physics.OverlapSphere(InteractorSource.position, InteractRange, interactableLayer);

        IInteractable closestInteractable = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<IInteractable>(out var interactObj))
            {
                float distance = Vector3.Distance(InteractorSource.position, collider.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestInteractable = interactObj;
                }
            }
        }

        //to bedzie najblizsze do zbierania
        if (closestInteractable != null)
        {
            closestInteractable.Interact();
        }
    }
}