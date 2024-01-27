using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Meme", menuName = "Meme/Nouveau_Meme", order = 1)]
public class MemeTemplate : ScriptableObject
{
    public Sprite sprite;
    public string meme_name;
    public bool usedInCraft;
}
