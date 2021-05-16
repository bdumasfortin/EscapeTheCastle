using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }
}
