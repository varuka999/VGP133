using VGP133_Final_Karlsson_Vincent;

// Flow
// Character creation: name, info etc
// choose class (preset stats, enum?, fake SO)
// Choose where to go
// Town:
// - Refill HP
// - Item Shop
// - Equipment Shop
// Forest:
// - 50% battle monsters
// - 50% random reward, at cost of event!
// Mountain:
// - 50% battle monsters (harder)
// - 50% random reward, at cost of event (riskier)!
// Boss Castle:
// - 2 battles with random monsters
// - Final boss fight (losing applies penalties)

//Test
List<Item> inventoryTest = new List<Item>();
//Equipment equipment1 = new Equipment();
//inventoryTest.Add(equipment1);

GameManager gameManager = new GameManager();
gameManager.Game();
