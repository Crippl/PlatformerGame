using System.Collections.Generic;
using UnityEngine;

public class PortalDictionary : MonoBehaviour
{
    [SerializeField] private List<GameObject> portalsList;
    [SerializeField] private List<Transform> exitPortalsTransformList;
    private Dictionary<GameObject, Transform> portalsDictionary;
    private Dictionary<GameObject, Transform> createdDictionary;

    private void Start()
    {
        portalsDictionary = SerializeDictionary(portalsList, exitPortalsTransformList);
    }
    
    private Dictionary<GameObject, Transform> SerializeDictionary(List<GameObject> enters,List<Transform> exits)
    {
        createdDictionary = new Dictionary<GameObject, Transform>();
        for (int i = 0; i < enters.Count; i++)
        {
            createdDictionary[enters[i]] = exits[i];
        }
        return createdDictionary;
    }

    public bool ContainsKeyInDictionary(GameObject key)
    {
        return portalsDictionary.ContainsKey(key);
    }

    public Transform GetValue (GameObject key)
    {
        return portalsDictionary[key];
    }
}
