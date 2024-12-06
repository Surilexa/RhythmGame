using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocations : MonoBehaviour
{
    [SerializeField] List<Transform> spawnLoc;

    public List<Transform> SpawnLoc { get => spawnLoc; set => spawnLoc = value; }
}
