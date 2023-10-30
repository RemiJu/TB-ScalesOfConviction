using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshProColorChange : MonoBehaviour
{
    public Color hoverColor = Color.red; // Color to change to on hover
    private Color originalColor; // Store the original color
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        originalColor = textMeshPro.color;
    }

    private void OnMouseEnter()
    {
        // Change the vertex color to the hover color on mouse enter
        textMeshPro.color = hoverColor;
    }

    private void OnMouseExit()
    {
        // Restore the original vertex color on mouse exit
        textMeshPro.color = originalColor;
    }
}
