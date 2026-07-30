using System.Collections;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Door bedroomDoor;
    public GameObject[] houseList;
    public GameObject currentHouse;
    public string selectedPill;
    public int dayNumber = 0;
    [SerializeField] GameObject pillsPrefab;
    [SerializeField] string[] DayNumberTextMessages;
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

        Player.instance.hasPills = false;

        uiFader.duration = 2f;
        StartCoroutine(ShowDayMessage());
        bedroomDoor.isOpen = false;
    }

    private IEnumerator ShowDayMessage()
    {
        WinLoseCheck(currentHouse == houseList[0] ? "BLUE" : "RED");
        yield return new WaitForSeconds(2);
        NotifManager.instance.ShowNotif(DayNumberTextMessages[dayNumber], 3);
        Instantiate(pillsPrefab, pillsSpawnPoint.position, pillsSpawnPoint.rotation);
        yield return new WaitForSeconds(3);
        uiFader.FadeOut();
    }

    private void WinLoseCheck(string correctPill)
    {
        if (selectedPill == correctPill)
        {
            dayNumber += 1;
        } else
        {
            dayNumber = 0;
            // TODO: show jump scare
        }

        print(dayNumber);
    }
}
