using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChange : MonoBehaviour
{
    public int overlapLayer = 1; 
    public int endLayer = 2;
    Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
#if LAYER_DEBUG
        Debug.Log("enter:" + overlapLayer);
#endif
        objectRenderer.sortingOrder = overlapLayer;
    }

    void OnTriggerExit2D(Collider2D other)
    {
#if LAYER_DEBUG
        Debug.Log("exit:" + endLayer);
#endif
        objectRenderer.sortingOrder = endLayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
