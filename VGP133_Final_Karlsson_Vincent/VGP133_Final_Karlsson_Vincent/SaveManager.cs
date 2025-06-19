using System.Xml.Serialization;

namespace VGP133_Final_Karlsson_Vincent
{
    internal static class SaveManager
    {
        public static void Save(Player player, int saveSlot)
        {
            string xmlFile = GetSaveNameFormatPath(saveSlot);

            XmlSerializer serializer = new XmlSerializer(typeof(Player));
            using (StreamWriter writer = new StreamWriter(xmlFile))
            {
                serializer.Serialize(writer, player);
            }

            Console.WriteLine($"Saved to slot {saveSlot}!");
        }

        public static Player? Load(int saveSlot)
        {
            string xmlFile = GetSaveNameFormatPath(saveSlot);

            if (File.Exists(xmlFile) == true)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Player));
                using (StreamReader reader = new StreamReader(xmlFile))
                {
                    Player player = (Player)serializer.Deserialize(reader)!;
                    Console.WriteLine($"Loaded from slot {saveSlot}!");
                    return player;
                }
            }
            else
            {
                Console.WriteLine("Save file not found!");
                return null;
            }
        }

        public static void ShowSaveSlots()
        {
            for (int i = 1; i < 4; i++)
            {
                string path = GetSaveNameFormatPath(i);
                if (File.Exists(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Player));
                    using (StreamReader reader = new StreamReader(path))
                    {
                        Player temp = (Player)serializer.Deserialize(reader)!;
                        Console.WriteLine($"{i}: Player Name: {temp.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"{i}: [Empty Save Slot]");
                }
            }
        }

        public static string GetSaveNameFormatPath(int slot)
        {
            return $"Player{slot}.xml";
        }
    }
}
