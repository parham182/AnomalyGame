using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Door bedroomDoor;
    public GameObject[] houseList;
    public GameObject currentHouse;
    public string selectedPill;
    [SerializeField] GameObject pillsPrefab;
    [SerializeField] Transform pillsSpawnPoint;

    [SerializeField] UiFader uiFader;

    [Range(0f, 1f)]
    [SerializeField] private float anomalyChance = 0.7f;

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

        foreach (GameObject house in houseList)
        {
            house.SetActive(false);
        }

        GameObject selectedHouse;

        if (Random.value <= anomalyChance)
        {
            do
            {
                int randIndex = Random.Range(1, houseList.Length);
                selectedHouse = houseList[randIndex];
            }
            while (selectedHouse == currentHouse && houseList.Length > 2);
        }
        else
        {
            selectedHouse = houseList[0];
        }

        selectedHouse.SetActive(true);
        currentHouse = selectedHouse;

        Instantiate(pillsPrefab, pillsSpawnPoint.position, pillsSpawnPoint.rotation);
        Player.instance.hasPills = false;

        uiFader.duration = 3f;
        uiFader.FadeOut();
        bedroomDoor.isOpen = false;
    }

    private void WinLoseCheck(string correctPill)
    {
        print(correctPill + " " + selectedPill);
        if (selectedPill == correctPill)
        {
            print("win");
        } else
        {
            print("lose");
        }
    }
}
