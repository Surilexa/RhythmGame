using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnSize : MonoBehaviour
{
    [SerializeField] float sizeMin;
    [SerializeField] float sizeMax;
    void Start()
    {
        transform.localScale = new Vector3(Random.Range(sizeMin, sizeMax), Random.Range(sizeMin, sizeMax), 1);
    }

    
}
