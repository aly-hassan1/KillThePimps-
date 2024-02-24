using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool useEvents;
    [SerializeField]
    public string promptMessage; 

    // Start is called before the first frame update
    public void BaseInteract()
    {
        if(useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        
        Interact();
    }
    protected virtual void Interact()
    {

    }
}
