using Unity.VisualScripting;
using UnityEditor;

[CustomEditor(typeof(Interactable), true)] /*specifies that this editor script should be used for the (Interactable class)
                                             and any of its subclasses(true indicates it applies to derived classes as well).*/

public class InteractableEditor : Editor
{
    public override void OnInspectorGUI() // provides a custom GUI for the inspector of Interactable objects
    {
        Interactable interactable = (Interactable)target; // Cast the target object to the Interactable type for easier access to its properties.
        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteract can ONLY use Unity events.", MessageType.Info);
            if (interactable.GetComponent<InteractionEvent>() == null)
            {
                interactable.useEvents = true;
                interactable.gameObject.AddComponent<InteractionEvent>();
            }
        }
        else
        {
            base.OnInspectorGUI();
            if (interactable.useEvents) // If the 'useEvents' property is true...
            {
                if (interactable.GetComponent<InteractionEvent>() == null) // ..and the GameObject does not have an InteractionEvent component..
                    interactable.gameObject.AddComponent<InteractionEvent>(); // ..Add it
            }
            else // If 'useEvents' is false...
            {
                if (interactable.GetComponent<InteractionEvent>() != null) // ..but an InteractionEvent component exists..(we do have interaction component)
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>()); // ..Remove it.
            }
        }
    }
}