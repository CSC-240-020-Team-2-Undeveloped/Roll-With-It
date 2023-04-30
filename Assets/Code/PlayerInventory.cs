using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfKeys { get; private set; }
    
    public UnityEvent<PlayerInventory> OnKeysCollected;

    public void KeysCollected()
    {
	NumberOfKeys++;
	OnKeysCollected.Invoke(this);
    }
}
