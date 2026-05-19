using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private Dictionary<string, Sprite> iconDict;

    [SerializeField] private Sprite[] icons;
    [SerializeField] private GameObject questDialog;

    public int range = 3;
    public GameObject npcPosition;
    public GameObject StarszaPani;
    public GameObject myPosition;

    private string SampleQuest = "Assets/Resources/Quests/Quest_Tata.xml";
    private string SampleQuest2 = "Assets/Resources/Quests/Quest_Tata_End.xml";

    private string SampleQuest_Po = "Assets/Resources/Quests/Quest_Babcia.xml";
    private string SampleQuest2_Po = "Assets/Resources/Quests/Quest_Babcia_End.xml";

    private List<string> ukonczoneQuesty = new List<string>();

    void Start()
    {
        questDialog.SetActive(false);
        LoadIconsFromSprites();
    }

    private void LoadIconsFromSprites()
    {
        iconDict = new Dictionary<string, Sprite>();
        foreach (Sprite sprite in icons)
        {
            iconDict.Add(sprite.name, sprite);
        }
    }
}
