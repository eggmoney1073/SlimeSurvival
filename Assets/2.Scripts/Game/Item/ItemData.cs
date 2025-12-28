using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    /// <summary>
    /// Bullet 1xxx , Gun 2xxx, Equipable 3xxx, Jewelry 4xxx, Junk 9xxx
    /// </summary>
    public int _id;
    public Sprite _icon;
    public int _xSize;
    public int _ySize;
    public int _maxStack;
}
