using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private static ViewManager instance;

    [SerializeField]
    private View[] views; // Assign views in the Inspector

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject); // Ensure only one instance exists
    }

    public static void ShowView(View viewToShow)
    {
        foreach (var view in instance.views)
        {
            view.Hide(); // Hide all views
        }
        viewToShow.Show(); // Show the selected view
    }
}
