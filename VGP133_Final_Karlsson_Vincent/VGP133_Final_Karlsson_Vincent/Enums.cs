using System.ComponentModel;

namespace VGP133_Final_Karlsson_Vincent
{
    public enum MainMenu
    {
        Null = 0,
        Town,
        Forest,
        Mountains,
        Inventory,
        Equipment,
        BossCastle,
        Save,
        Load,
        Exit,
    }

    public enum TownMenu
    {
        Null = 0,
        Inn,
        Consumable,
        Equipment,
        Character,
    }

    public enum InventoryMenu
    {
        Null = 0,
        SortName,
        SortQuantity,
        SortType,
    }

    public enum EquipmentMenu
    {
        Null = 0,
        ChangeWeapon,
        ChangeArmor,
    }

    public enum CombatMenu
    {
        Null = 0,
        Attack,
        UseItem,
        Flee,
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

    public enum InventorySortOption
    {
        Null = 0,
        Default,
        Name,
        Quantity,
        Type
    }

    public enum SortType
    {
        Null = 0,
        Name,
        TypeName,
        Quantity,
    }

    public enum PlayerAction
    {
        Null = 0,
        [Description("Attack")] 
        Attack,
        [Description("Use Item")] 
        UseItem,
        [Description("Flee Combat")] 
        Flee,
    }

    public enum CombatResult
    {
        Null = 0,
        PlayerVictory,
        PlayerFlee,
        PlayerDefeat,
    }
}
