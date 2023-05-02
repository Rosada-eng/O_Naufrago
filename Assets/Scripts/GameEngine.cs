using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public int currentLevel = 1;

    public int woodsToCollect = 0;
    public int ropesToCollect = 0;
    public int fabricsToCollect = 0;

    private Dictionary<int, Dictionary<string, int>> levels = new Dictionary<int, Dictionary<string, int>>()
    {
        {1, new Dictionary<string, int>() {
            {"Wood", 3},
            {"Rope", 0},
            {"Fabric", 0}
        }},
        {2, new Dictionary<string, int>() {
            {"Wood", 4},
            {"Rope", 2},
            {"Fabric", 0}
        }},
        {3, new Dictionary<string, int>() {
            {"Wood", 6},
            {"Rope", 3},
            {"Fabric", 2}
        }},

    };

    public void Start()
    {
        // TODO: TO DEBUG, CHOOSE YOUR LEVEL:
        // currentLevel = 2;
        woodsToCollect = levels[currentLevel]["Wood"];
        ropesToCollect = levels[currentLevel]["Rope"];
        fabricsToCollect = levels[currentLevel]["Fabric"];
    }

    public void LevelUp()
    {
        currentLevel += 1;
        woodsToCollect = levels[currentLevel]["Wood"];
        ropesToCollect = levels[currentLevel]["Rope"];
        fabricsToCollect = levels[currentLevel]["Fabric"];

        // Alterar para Próxima Scene (Cutscene + New Map)
        // SceneManager.LoadScene("Level" + currentLevel);
    }
}
