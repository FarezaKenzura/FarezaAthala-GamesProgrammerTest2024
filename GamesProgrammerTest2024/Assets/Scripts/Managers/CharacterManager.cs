using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;
    
    void Awake()
    {
        Instance = this;
    }
}
