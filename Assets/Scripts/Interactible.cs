using UnityEngine;

public abstract class Interactible : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("Interact called on base class");
    }
}
