using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] DoubleDoor _openOnPressE;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _openOnPressE != null)
            _openOnPressE.Toggle();
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }
}
