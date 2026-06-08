using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using System;

public class Quest
{
    [XmlArray("Nodes")]
    [XmlArrayItem("Node")]
    public List<QuestNode> Nodes;

    [XmlAttribute("QuestTitle")]
    public string QuestTitle;

    public string FilePath;

    [System.NonSerialized]
    private int position;

    public QuestNode ProgressQuest()
    {
        if (HasNextQuestNode())
        {
            return Nodes[position++];
        }
        return null;
    }

    private bool HasNextQuestNode()
    {
        return Nodes != null && position < Nodes.Count;
    }

    public static Quest LoadQuest(string resourcePath)
    {
        TextAsset xmlFile = Resources.Load<TextAsset>(resourcePath);

        if (xmlFile == null)
        {
            Debug.Log("Quest XML nie znaleziony zjebie: " + resourcePath);
            return null;
        }

        var serializer = new XmlSerializer(typeof(Quest));

        using (StringReader reader = new StringReader(xmlFile.text))
        {
            Quest quest = serializer.Deserialize(reader) as Quest;
            quest.FilePath = resourcePath;
            return quest;
        }
    }
} 