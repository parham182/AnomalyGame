using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] houseList;
    public GameObject currentHouse;
    public string selectePill;
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
        WinLoseCheck(currentHouse == houseList[0] ? "BLUE" : "RED");
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
        currentHouse = selectedHouse;
        Instantiate(pillsPrefab, pillsSpawnPoint.position, pillsSpawnPoint.rotation);
        Player.instance.hasPills = false;

        uiFader.duration = 3f;
        uiFader.FadeOut();
    }

    private void WinLoseCheck(string correctPill)
    {
        print(correctPill + " " + selectePill);
        if (selectePill == correctPill)
        {
            print("win");
        } else
        {
            print("lose");
        }
    }
}
