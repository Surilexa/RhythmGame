using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using static UnityEngine.GraphicsBuffer;

public abstract class RhythmNote : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AnimationCurve speedCurve;

    private float moveSpeed =.1f;
    private float sinTime = 1;

    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Perfect")
        {
            Destroy(this.gameObject);
        }
    }
    
}
