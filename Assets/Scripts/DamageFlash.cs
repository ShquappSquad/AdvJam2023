using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    private SpriteRenderer render;
    private Color ogColor;
    private float flashTime = 0.5f;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        ogColor = render.material.color;
    }
    
    public void FlashStart()
    {
        render.material.color = Color.white;
        Invoke("FlashStop", flashTime);
    }

    public void FlashStop()
    {
        render.material.color = ogColor;
    }
}
