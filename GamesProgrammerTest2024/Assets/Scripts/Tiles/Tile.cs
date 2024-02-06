using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour 
{
    [SerializeField] private Color baseColor;
    [SerializeField] protected SpriteRenderer render;
    [SerializeField] private GameObject highlight;

    public virtual void Init(int x, int y) 
    {
        render.color = baseColor;
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}