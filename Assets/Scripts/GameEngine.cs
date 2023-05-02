using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    public static int currentLevel = 1;

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
        // currentLevel = 3;
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

        if (currentLevel > 3)
        {
            Victory();
        }
        else
        {
            // Alterar para Próxima Scene (Cutscene + New Map)
            SceneManager.LoadScene("level" + currentLevel);

            SelectNextBoat();
        }
    }

    public void SelectNextBoat()
    {
        gameObject.GetComponent<PlayerController>().findReferenceToBoat();
    }

    public void GameOver()
    {
        // Alterar para Scene de Game Over
        // SceneManager.LoadScene("GameOver");

    }

    public void Victory()
    {
        // Alterar para Scene de Vitória
        // SceneManager.LoadScene("Victory");
    }


}
