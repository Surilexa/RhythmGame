using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAlpha : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float alpha;
    void Start()
    {
        Color tmp = sr.color;
        tmp.a = alpha;
        sr.color = tmp;
    }
}
