using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRing : MonoBehaviour
{
    private List<Key.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Key Added: " + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keytype)
    {
        return keyList.Contains(keytype);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Key key = collider.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        DoorKey doorKey = collider.GetComponent<DoorKey>();
        if ( doorKey != null)
        {
            if (ContainsKey(doorKey.GetKeyType()))
            {
                RemoveKey(doorKey.GetKeyType());
                doorKey.OpenDoor();
            }
        }
    }
}
