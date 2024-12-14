using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlpha : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] private float alpha;

    // Callback for slider value change
    void Start()
    {
        // Get current color including transparency
        Color currentColor = image.color;

        // Apply slider value as transparency (slider range: 0 - 1 fits perfectly)
        image.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
    }
}
