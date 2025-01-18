using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    public abstract void Initialize(); // Setup logic for each view
    public virtual void Show() => gameObject.SetActive(true); // Makes the view visible
    public virtual void Hide() => gameObject.SetActive(false); // Hides the view
}
