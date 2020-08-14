using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ItemUsed
{
    public int value;
    public int quantity;
    public bool craftingIngredient;

    public bool equippable;     // can it be equipped?
    public bool consumable;     // can it be consumed
    public string itemName;     // Name of item
    public string path;         // path to image file
    public string loreShort;    // flavor text
    public string loreLong;     // detailed Lore
    public int valueBase;		// base value of the object. Value in market is derived from this

}

public class ItemUsed
{
    public int ID;              // item ID
    public int numberOfUses;	// how often the item was used
}
