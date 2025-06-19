using System.ComponentModel;

namespace VGP133_Final_Karlsson_Vincent
{
    public enum GameStart
    {
        Null = 0,
        NewGame,
        NewGameAdmin,
        Continue,
        Exit,
    }

    public enum MainMenu
    {
        Null = 0,
        Town,
        Inventory,
        Equipment,
        Forest,
        Mountains,
        BossCastle,
        Save,
        Load,
        Delete,
        Exit,
    }

    public enum ExploreMenu
    {
        Null = 0,
        Forest,
        Mountains,
        BossCastle,
        Exit,
    }

    public enum TownMenu
    {
        Null = 0,
        Inn,
        Consumable,
        Equipment,
        Character,
        Exit,
    }

    public enum InventoryMenu
    {
        Null = 0,
        SortName,
        SortQuantity,
        SortType,
        Exit,
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
        Exit,
    }

    public enum PlayerAction
    {
        Null = 0,
        Attack,
        UseItem,
        Flee,
    }

    public enum CombatResult
    {
        Null = 0,
        PlayerVictory,
        PlayerFlee,
        PlayerDefeat,
    }

    public enum MonsterData
    { 
        Null = 0,
        GoblinLooterA, GoblinLooterB,
        ShaleGolemA, ShaleGolemB,
        LargeLeechA, LargeLeechB,
        RecklessOgreA, RecklessOgreB,
        ClumsyOgreA, ClumsyOgreB,
        PebbleBeastA, PebbleBeastB,
        Boss,
    }

    public enum ItemData
    {
        Null = 0,
        HealthPotion,
        AdvancedPotion,
        SuperPotion,
        Elixir,
        IronSword,
        SteelSword,
        DamascusSword,
        PiercingSword,
        LeatherArmor,
        ToughArmor,
        SpikedArmor,
        ChainMailArmor,
    }
}
