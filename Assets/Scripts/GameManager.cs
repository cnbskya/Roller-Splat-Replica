using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] prefabs;
    private GroundPrefab[] allGroundPieces;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Instantiate(prefabs[2]);
        allGroundPieces = FindObjectsOfType<GroundPrefab>();
    }
    
    public void CheckComplete()
    {
        bool isFinished = true;

        for (int i = 0; i < allGroundPieces.Length; i++)
        {
            if (allGroundPieces[i].isColored == false)
            {
                isFinished = false;
                break;
            }
        }
    }
}