using UnityEngine;

public interface IInteractable
{
    public void Highlight();
    public void Unhighlight();
    public void Interact();
    public Transform Transform { get;}
}
