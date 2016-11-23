using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTo : MonoBehaviour {

	public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
