namespace VGP133_Final_Karlsson_Vincent
{
    public enum MainMenu
    {
        Null = 0,
        Town,
        Forest,
        Mountains,
        BossCastle,
        Inventory,
        Equipment,
        Save,
        Load,
        Exit,
        Count,
    }

    public enum TownMenu
    {
        Null = 0,
        Inn,
        ConsumableShop,
        EquipmentShop,
        Character,
        Count,
    }

    public enum InventoryMenu
    {
        Null = 0,
        SortName,
        SortQuantity,
        SortType,
        Count,
    }

    public enum EquipmentMenu
    {
        Null = 0,
        ChangeWeapon,
        ChangeArmor,
        Count,
    }

    public enum CombatMenu
    {
        Null = 0,
        Attack,
        UseItem,
        Flee,
        Count,
    }

    public enum UnitType
    {
        Null = 0,
        Player,
        Monster,
        Boss,
    }

    public enum EquipmentType
    {
        Null = 0,
        Weapon,
        Armor,
    }
}
