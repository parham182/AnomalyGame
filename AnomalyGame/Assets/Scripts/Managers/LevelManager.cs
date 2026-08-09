using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Door bedroomDoor;
    public List<GameObject> AllLevels = new List<GameObject>();
    [SerializeField] private List<GameObject> ShowableLevels = new List<GameObject>();
    [SerializeField] private List<GameObject> ShowedLevels = new List<GameObject>();
    public GameObject currentHouse;
    public GameObject DefaultHouse;
    public GameObject EndHouse;
    public string selectedPill;
    public int dayNumber = 0;
    [SerializeField] GameObject pillsPrefab;
    [SerializeField] string[] DayNumberTextMessages;
    [SerializeField] Transform pillsSpawnPoint;
    [SerializeField] AudioClip impactCinematicClip;

    [SerializeField] UiFader uiFader;

    [Range(0f, 1f)]
    [SerializeField] private float defaultAnomalyChance;
    [SerializeField] private float anomalyChance;

    [Header("Jumpscare stuff")]
    [SerializeField] GameObject jumpscareImageObject;
    [SerializeField] Image jumpscareImage;
    [SerializeField] AudioClip jumpscareSound;
    [SerializeField] Sprite[] jumpscareImageList;

    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentHouse = AllLevels[0];
        ShowableLevels = new List<GameObject>(AllLevels);
        anomalyChance = defaultAnomalyChance;
    }

    private void OnEnable()
    {
        StartCoroutine(ShowDayMessageWithoutPillNoDelay());
    }

    public void ChangeLevel()
    {
        foreach (GameObject house in AllLevels)
        {
            house.SetActive(false);
        }

        GameObject selectedHouse;

        // print(dayNumber == DayNumberTextMessages.Length - 2);
        // print(CorrectPill(currentHouse == DefaultHouse ? "BLUE" : "RED"));

        if (dayNumber == DayNumberTextMessages.Length - 2 
            && CorrectPill(currentHouse == DefaultHouse ? "BLUE" : "RED")) // its end game
        {
            selectedHouse = EndHouse;

            selectedHouse.SetActive(true);
            dayNumber += 1;
            StartCoroutine(ShowDayMessageWithoutPill());
            currentHouse = selectedHouse;
            Player.instance.hasPills = false;
            bedroomDoor.isOpen = false;
            
            return;
        }

        if (Random.value <= anomalyChance)
        {
            do
            {
                int randIndex = Random.Range(1, ShowableLevels.Count);
                selectedHouse = ShowableLevels[randIndex];
            }
            while (selectedHouse == currentHouse && ShowableLevels.Count > 2);

            // remove anomaly from ShowableLevels
            ShowableLevels.Remove(selectedHouse);
            ShowedLevels.Add(selectedHouse);
            anomalyChance -= 0.1f;
        }
        else
        {
            selectedHouse = DefaultHouse;
            if (anomalyChance < defaultAnomalyChance)
                anomalyChance = defaultAnomalyChance;
            else 
                anomalyChance += 0.1f;
        }

        selectedHouse.SetActive(true);
        WinLoseCheck(currentHouse == DefaultHouse ? "BLUE" : "RED");

        currentHouse = selectedHouse;
        Player.instance.hasPills = false;
        bedroomDoor.isOpen = false;
    }

    public IEnumerator ShowDayMessage()
    {
        yield return new WaitForSeconds(2);

        NotifManager.instance.ShowNotif(DayNumberTextMessages[dayNumber], 3);
        SoundManager.instance.PlaySoundEffect(impactCinematicClip, 0);
        Instantiate(pillsPrefab, pillsSpawnPoint.position, pillsSpawnPoint.rotation);

        yield return new WaitForSeconds(3);
        uiFader.FadeOut(2);
    }

    public IEnumerator ShowDayMessageWithoutPill()
    {
        yield return new WaitForSeconds(2);

        NotifManager.instance.ShowNotif(DayNumberTextMessages[dayNumber], 3);
        SoundManager.instance.PlaySoundEffect(impactCinematicClip, 0);
        // Instantiate(pillsPrefab, pillsSpawnPoint.position, pillsSpawnPoint.rotation);

        yield return new WaitForSeconds(3);
        uiFader.FadeOut(2);
    }

    public IEnumerator ShowDayMessageWithoutPillNoDelay()
    {
        yield return new WaitForSeconds(2);

        NotifManager.instance.ShowNotif(DayNumberTextMessages[dayNumber], 3);
        SoundManager.instance.PlaySoundEffect(impactCinematicClip, 0);
        // Instantiate(pillsPrefab, pillsSpawnPoint.position, pillsSpawnPoint.rotation);

        yield return new WaitForSeconds(3);
        uiFader.FadeOut(2);
    }

    private void WinLoseCheck(string correctPill)
    {
        // print("selectedPill: " + selectedPill + "--correctPill: " + correctPill);
        if (selectedPill == correctPill)
        {
            dayNumber += 1;
            StartCoroutine(ShowDayMessage());
        } else
        {
            dayNumber = 0;
            // StartCoroutine(PlayJumpscare());
            StartCoroutine(ShowDayMessage());

            // add removed anomalys
            ShowableLevels = new List<GameObject>(AllLevels);
            ShowedLevels.Clear();
        }
    }

    private bool CorrectPill(string correctPill)
    {
        return selectedPill == correctPill;
    }

    private IEnumerator PlayJumpscare()
    {
        yield return new WaitForSeconds(2);

        // jumpscare stuff
        jumpscareImageObject.SetActive(true);
        jumpscareImage.sprite = jumpscareImageList[Random.Range(0, jumpscareImageList.Length)];
        SoundManager.instance.PlaySoundEffect(jumpscareSound, 0);

        Instantiate(pillsPrefab, pillsSpawnPoint.position, pillsSpawnPoint.rotation);

        yield return new WaitForSeconds(2);

        // after jumpscare stuff
        jumpscareImageObject.SetActive(false);

        uiFader.FadeOut(2);
    }
}
