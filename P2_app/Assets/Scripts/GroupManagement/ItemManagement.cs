using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemSystem/ItemTemplate")]
public class ItemManagement : ScriptableObject
{
    public Sprite groupPhoto;
    public string groupName;
    public Color groupColor;
    public string groupDescription;
    public string[] groupChallengers;
    public string[] groupStats;

    public ItemManagement()
    {
        groupStats = new string[10];
        for (int i = 0; i < groupStats.Length; i++)
        {
            groupStats[i] = "0";
        }
    }
}
    