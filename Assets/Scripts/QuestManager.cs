using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    //public QuestClass[] quests;
    public List<QuestClass> quests;

    private void Start()
    {
        quests = new List<QuestClass>();
        createQuests();
        Random.seed = Random.Range(0, 1000);
    }

    public void reset()
    {
        quests = new List<QuestClass>();
        createQuests();
        Random.seed = Random.Range(0, 1000);
    }

    private void createQuests()
    {
        var quest1 = new QuestClass("The Beginning", 1000, 'E', "Anonymous", 1, "JobBoxQuest1", 1);
        add(quest1);
        var quest2 = new QuestClass("Save my Husband!", 1000, 'D', "Mrs Bets", 1, "JobBoxQuest2", 2);
        add(quest2);
        var quest3 = new QuestClass("My Cravings...", 1000, 'D', "Mr Smokey", 1, "JobBoxQuest3", 3);
        add(quest3);
        var quest4 = new QuestClass("A Mobile Mistake", 1200, 'D', "Mrs Sugars", 1, "JobBoxQuest4", 4);
        add(quest4);
        var quest5 = new QuestClass("Masked Bullies", 1500, 'C', "Victir", 1, "JobBoxQuest5", 5);
        add(quest5);
        var quest6 = new QuestClass("Bring me Home", 1800, 'B', "Mr Scaredy", 1, "JobBoxQuest6", 6);
        add(quest6);
        var quest7 = new QuestClass("You! Challenge me... Now!", 3000, 'A', "Boss Ah Drago", 0, "JobBoxQuest7", 7);
        add(quest7);
        var quest8 = new QuestClass("Fact or Fiction?", 1000, 'D', "Mr Host", 3, "JobBoxQuest8", 8);
        add(quest8);
        var quest9 = new QuestClass("Lost on a Venture", 1000, 'D', "Mr Shade", 2, "JobBoxQuest9", 9);
        add(quest9);
        var quest10 = new QuestClass("Exclusion Persuasion", 1500, 'B', "Mr CIP", 4, "JobBoxQuest0", 0);
        add(quest10);
    }

    public QuestClass getObj(int index)
    {
        if (index >= quests.Count || quests[index] != null)
            return quests[index];
        Debug.Log("Null Pointer Exception. getObj()");
        return null;
    }

    public List<QuestClass> getList()
    {
        return quests;
    }

    public bool deleteIndex(int index)
    {
        for (var i = 0; i < quests.Count; i++)
        {
            if (quests[i] != null && quests[i].index == index)
                quests[i] = null;
        }
        return false;
    }

    public bool delete(int index)
    {
        if (index < 0 || index >= quests.Count)
            return false;
        quests.RemoveAt(index);
        return true;
    }

    public void shuffle()
    {
        var shuffles = 20;
        for (var i = 0; i < quests.Count; i++)
        {
            if (quests[i] == null)
                delete(i--);
        }
        for (var i = 0; i < shuffles; i++)
        {
            var a = Random.Range(0, quests.Count);
            var b = Random.Range(0, quests.Count);
            var temp = quests[b];
            quests[b] = quests[a];
            quests[a] = temp;
        }
    }

    public void add(QuestClass q)
    {
        quests.Add(q);
    }

    public class QuestClass
    {
        public char difficulty;
        public int index;
        public int location;
        public string questName;
        public string requester;
        public int reward;
        public Sprite sprite;
        public bool taken;

        public QuestClass(string name, int reward, char diff, string req, int location, string path, int index)
        {
            questName = name;
            this.reward = reward;
            difficulty = diff;
            taken = false;
            requester = req;
            this.location = location;
            sprite = Resources.Load(path, typeof (Sprite)) as Sprite;
            this.index = index;
        }

        public QuestClass(string name, int reward, char diff, string req, int location, Sprite spr, int index)
        {
            questName = name;
            this.reward = reward;
            difficulty = diff;
            taken = false;
            requester = req;
            this.location = location;
            sprite = spr;
            this.index = index;
        }

        public QuestClass copyof()
        {
            var q = new QuestClass(questName, reward, difficulty,
                requester, location, sprite, index);
            return q;
        }
    }
}