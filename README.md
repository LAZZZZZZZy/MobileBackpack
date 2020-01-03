# Mobile BackPack
mobile BackPack in Unity3d. 
This program create a mobile BackPack by using Unity3D, and it is cross-platform in both IOS and Android since Unity3D provides the function to switch the platform.

## Implementation
* User can drag the item to any slots in the BackPack if the slot is empty.
* If the slot already had the item, it will swap the item with the picked up item.
* It will automatically put new item to the empty slot.
* When user touch down one of item in the slot, it will show the tooltip of this item including the name, attribute and prefix.

## Design
* Read data from .csv file including equipment attribute and name, prefix.
* Create a singleton Inventory Management class to operate and manage other related components.
* Swap and get the data and status in the Inventory Management class.
* Using the hierarchy structure to inherit the attribute and class. For example, the slot can be equipment slot, inventory slot, backpack slot and vendor slot.
