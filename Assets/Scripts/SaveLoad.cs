using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private string saveFileName = "savefile.json";

    void Update()
    {
        // Press S to Save
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Saving game...");
            SavingService.SaveGame(saveFileName);
        }

        // Press L to Load
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Loading game...");
            SavingService.LoadGame(saveFileName);
        }
    }
}
