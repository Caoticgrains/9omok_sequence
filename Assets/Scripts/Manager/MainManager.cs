using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public void OnClickMainMenuStartButton()
    {
        Debug.Log("OnClickMainMenuStartButton : Main -> Game");
        SceneManager.LoadScene("Game");
    }
}