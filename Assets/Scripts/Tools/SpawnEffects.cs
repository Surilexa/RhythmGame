using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffects : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    private void Start()
    {
        StartCoroutine(DestroyDelay());
    }
    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
