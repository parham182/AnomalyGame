using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Door bedroomDoor;
    public GameObject[] houseList;
    public GameObject currentHouse;
    public GameObject DefaultHouse;
    public string selectedPill;
    public int dayNumber = 0;
    [SerializeField] GameObject pillsPrefab;
    [SerializeField] string[] DayNumberTextMessages;
    [SerializeField] Transform pillsSpawnPoint;
    [SerializeField] AudioClip impactCinematicClip;

    [SerializeField] UiFader uiFader;

    [Range(0f, 1f)]
    [SerializeField] private float anomalyChance = 0.7f;

    [Header("Jumpscare stuff")]
    [SerializeField] GameObject jumpscareImageObject;
    [SerializeField] Image jumpscareImage;
    [SerializeField] AudioClip jumpscareSound;
    [SerializeField] Sprite[] jumpscareImageList;

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
            selectedHouse = DefaultHouse;
        }

        selectedHouse.SetActive(true);
        WinLoseCheck(currentHouse == DefaultHouse ? "BLUE" : "RED");

        currentHouse = selectedHouse;
        Player.instance.hasPills = false;
        bedroomDoor.isOpen = false;
    }

    private IEnumerator ShowDayMessage()
    {
        yield return new WaitForSeconds(2);

        NotifManager.instance.ShowNotif(DayNumberTextMessages[dayNumber], 3);
        SoundManager.instance.PlaySoundEffect(impactCinematicClip, 0);
        Instantiate(pillsPrefab, pillsSpawnPoint.position, pillsSpawnPoint.rotation);

        yield return new WaitForSeconds(3);
        uiFader.FadeOut(2);
    }

    private void WinLoseCheck(string correctPill)
    {
        print("selectedPill: " + selectedPill + "--correctPill: " + correctPill);
        if (selectedPill == correctPill)
        {
            dayNumber += 1;
            StartCoroutine(ShowDayMessage());
        } else
        {
            dayNumber = 0;
            StartCoroutine(PlayJumpscare());
        }
    }

    private IEnumerator PlayJumpscare()
    {
        yield return new WaitForSeconds(2);

        // jumpscare stuff
        jumpscareImageObject.SetActive(true);
        jumpscareImage.sprite = jumpscareImageList[Random.Range(0, jumpscareImageList.Length)];
        SoundManager.instance.PlaySoundEffect(jumpscareSound, 0);

        Instantiate(pillsPrefab, pillsSpawnPoint.position, pillsSpawnPoint.rotation);

        yield return new WaitForSeconds(3);

        // after jumpscare stuff
        jumpscareImageObject.SetActive(false);

        uiFader.FadeOut(2);
    }
}
