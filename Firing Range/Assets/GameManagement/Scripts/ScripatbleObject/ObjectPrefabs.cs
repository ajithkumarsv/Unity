using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectPrefabs", menuName = "Scriptable/Object Prefab")]
public class ObjectPrefabs : ScriptableObject
{
    [SerializeField]
    public List<Instantiable> objects = new List<Instantiable>();
}

