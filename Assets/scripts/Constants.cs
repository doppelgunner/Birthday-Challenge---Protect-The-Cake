using UnityEngine.SceneManagement;
using UnityEngine;

public class Constants : MonoBehaviour {

    public const string WAVE_START = "START OF WAVE ",
                        WAVE_END = "END OF WAVE: ",
                        LOSE = "YOU LOSE ON WAVE: ";

    private static int _currentWave;

    public static void StoreCurrentWave(int wave) {
        _currentWave = wave;
    }

    public static int GetCurrentWave() {
        return _currentWave;
    }

    public static void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
