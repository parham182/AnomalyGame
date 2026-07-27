using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] houseList;
    public GameObject currentHouse;
    [SerializeField] GameObject pillsPrefab;
    [SerializeField] Transform pillsSpawnPoint;

    [SerializeField] UiFader uiFader;

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
        currentHouse = houseList[0];
    }

    public void ChangeLevel()
    {
        GameObject selectedHouse;
        do
        {
            int randIndex = Random.Range(0, houseList.Length);
            selectedHouse = houseList[randIndex];
        } while(selectedHouse == currentHouse);

        foreach(GameObject house in houseList)
        {
            house.SetActive(false);
        }

        selectedHouse.SetActive(true);
        Instantiate(pillsPrefab, pillsSpawnPoint.position, pillsSpawnPoint.rotation);
        Player.instance.hasPills = false;

        uiFader.duration = 3f;
        uiFader.FadeOut();
    }
}
