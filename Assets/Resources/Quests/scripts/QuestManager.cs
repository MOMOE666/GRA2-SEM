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
    public GameObject Dzieciok;
    public GameObject Jerzy;
    
    public GameObject śmieci1;
    public GameObject śmieci2;
    public GameObject śmieci3;
    public GameObject śmieci4;
    public GameObject śmieci5;
    //to be clear this is a TERRIBLE way of doing this but i need it to friccin work so i dont care -sam
    

    private string TataQuest = "Assets/Resources/Quests/Quest_Tata.xml";
    private string TataQuestPo = "Assets/Resources/Quests/Quest_Tata_End.xml";

    private string BabciaQuest = "Assets/Resources/Quests/Quest_Babcia.xml";
    private string BabciaQuestPo = "Assets/Resources/Quests/Quest_Babcia_End.xml";

    private string DzieciokQuest = "Assets/Resources/Quests/Quest_Dzieciok.xml";
    private string DzieciokQuestPo = "Assets/Resources/Quests/Quest_Dzieciok_End.xml";

    private string JerzyQuest = "Assets/Resources/Quests/Quest_Jerzy.xml";
    private string JerzyQuestPo = "Assets/Resources/Quests/Quest_Jerzy_End.xml";



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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (questDialog.activeSelf)
            {
                questDialog.GetComponent<QuestDisplayComponent>().ProgressNode();
            }
            else
            {
                if (Vector3.Distance(myPosition.transform.position, npcPosition.transform.position) < range)
                {//ojciec
                    if (ukonczoneQuesty.Contains(TataQuest))
                        StartQuest(TataQuestPo); // Je�li sko�czony, �aduj plik "Po"
                    else
                        StartQuest(TataQuest);
                }
                else if (Vector3.Distance(myPosition.transform.position, StarszaPani.transform.position) < range)
                {//babunia
                //po
                    if (śmieci1.activeSelf & śmieci2.activeSelf & śmieci3.activeSelf & śmieci4.activeSelf & śmieci5.activeSelf )
                        StartQuest(BabciaQuestPo);
                    else //przed
                        StartQuest(BabciaQuest);
                }
                else if (Vector3.Distance(myPosition.transform.position, Dzieciok.transform.position) < range)
                {//quest dziecioka
                //po
                    if (ukonczoneQuesty.Contains(DzieciokQuest))
                        StartQuest(DzieciokQuestPo);
                    else //przed
                        StartQuest(DzieciokQuest);
                }
                else if (Vector3.Distance(myPosition.transform.position, Jerzy.transform.position) < range)
                {//quest Jerzego
                //po
                    if (ukonczoneQuesty.Contains(JerzyQuest))
                        StartQuest(JerzyQuestPo);
                    else //przed
                        StartQuest(JerzyQuest);
                }
            }
        }
    }

    public void StartQuest(string questFilePath)
    {
        questDialog.SetActive(true);
        questDialog.GetComponent<QuestDisplayComponent>()
            .Initialize(Quest.LoadQuest(questFilePath));
    }

    public void KoniecDialogu(string sciezkaPliku)
    {
        if (!ukonczoneQuesty.Contains(sciezkaPliku))
        {
            ukonczoneQuesty.Add(sciezkaPliku);
        }
        questDialog.SetActive(false);
    }

    public Sprite GetIcon(string iconName)
    {
        if (iconDict.TryGetValue(iconName, out Sprite sprite))
            return sprite;
        return null;
    }
}
