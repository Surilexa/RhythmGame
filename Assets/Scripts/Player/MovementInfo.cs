using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInfo : MonoBehaviour
{
    [SerializeField] List<Transform> movementLocations;

    public List<Transform> MovementLocations { get => movementLocations; set => movementLocations = value; }
}
