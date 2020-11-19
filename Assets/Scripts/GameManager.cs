using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GroundPrefab[] allGroundPrefabs;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        SetupNewLevel();
    }

    private void SetupNewLevel()
    {
        allGroundPrefabs = FindObjectsOfType<GroundPrefab>();
    }
}
