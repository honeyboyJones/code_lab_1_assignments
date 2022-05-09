using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public List<GameObject> npcObjs = new List<GameObject>();

    Dictionary<string, float> npcInfo = new Dictionary<string, float>();

    public GameObject NPCPrefab;
    
    //called before the first frame update
    void Start()
    {
        npcInfo.Add("bob", 0.6f);
        npcInfo.Add("lorg", 0.9f);
        npcInfo.Add("akshay", 0.56f);
        npcInfo.Add("sophie", 1f);
        npcInfo.Add("zach", 0.8f);
        npcInfo.Add("hao", 0.2f);

        // float testValue;
        // npcInfo.TryGetValue("akshay", out testValue);
        // print(testValue);

        foreach(KeyValuePair<string, float> pair in npcInfo)
        {
            print(pair.Key);
            print(pair.Value);

            GameObject NPC = Instantiate(NPCPrefab);

            NPC.GetComponentInChildren<TextMeshProUGUI>().SetText(pair.Key);
            NPC.GetComponent<NPCController>().sight = pair.Value;

            //loop through the dict
            //for each entry, instantiate an NPC
            //set name to the key
            //set sight to the value
        }

        // foreach(GameObject NPC in npcObjs)
        // {
        //     NPC.GetComponent<NPCController>().nameCanvas.transform.GetChild(0);
        // }

        // for(int i = 0; i < npcObjs.Count; i++)
        // {
        //     npcObjs[i].GetComponentInChildren<TextMeshProUGUI>().SetText("COOL PLAYER");
        // }
    }

    //called once per frame
    void Update()
    {
        
    }
}
