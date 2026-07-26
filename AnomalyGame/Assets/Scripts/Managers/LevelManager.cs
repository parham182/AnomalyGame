using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [HideInInspector]
    public string[] sceneList = {"DefaultHouse", "Anomaly1"};
    public string currentLevel;

    public static LevelManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;
    }

    public void ChangeLevel()
    {
        string selectedScene;
        do
        {
            int randIndex = Random.Range(0, sceneList.Length);
            selectedScene = sceneList[randIndex];
        } while(selectedScene == currentLevel);

        SceneManager.LoadScene(selectedScene);
    }
}
