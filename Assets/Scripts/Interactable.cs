using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    [SerializeField]
    //pesan ketika player mendekati objek interactable
    public string promptMessage;

    //fungsi ini akan dipanggil oleh player
    public void BaseInteract() {
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact() {
    
    //dibuat untuk dioverride oleh subclasses
    }
}
