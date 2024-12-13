using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using static UnityEngine.GraphicsBuffer;

public abstract class RhythmNote : MonoBehaviour
{
    //this is the default for all rhythm notes and obstacles.
    [SerializeField] private AnimationCurve speedCurve;
    private int difficulty = 1;
    private float moveSpeed = 3f;
    private Transform startLocation;
    private SpawningManager spawningManager;
    public virtual void Start()
    {
        startLocation = this.transform;
        if(FindFirstObjectByType<SpawningManager>() != null)
        {
            spawningManager = FindFirstObjectByType<SpawningManager>();
            moveSpeed = spawningManager.noteSpeed;
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.position -= new Vector3 (0, Time.deltaTime * moveSpeed * difficulty, 0);
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
