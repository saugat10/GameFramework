using GameFramework.Models;

// Create a world
World world = new World();
world.MaxX = 100;
world.MaxY = 100;

// Create some creatures
Creature player1 = new Creature();
player1.Name = "Player 1";
player1.HitPoints = 100;
player1.Position = new Position() { X = 10, Y = 10 };

Creature player2 = new Creature();
player2.Name = "Player 2";
player2.HitPoints = 100;
player2.Position = new Position() { X = 20, Y = 20 };

// Create some objects
WorldObject object1 = new WorldObject();
object1.Name = "Object 1";
object1.Lootable = true;
object1.Removeable = true;
object1.Position = new Position() { X = 30, Y = 30 };

WorldObject object2 = new WorldObject();
object2.Name = "Object 2";
object2.Lootable = false;
object2.Removeable = true;
object2.Position = new Position() { X = 40, Y = 40 };

// Create some weapons
AttackItem sword = new AttackItem();
sword.Name = "Sword";
sword.HitPoints = 10;
sword.Range = 15;

AttackItem bow = new AttackItem();
bow.Name = "Bow";
bow.HitPoints = 8;
bow.Range = 15;

// Create some armor
DefenceItem shield = new DefenceItem();
shield.Name = "Shield";
shield.ReducedHitPoints = 5;

DefenceItem helmet = new DefenceItem();
helmet.Name = "Helmet";
helmet.ReducedHitPoints = 3;

// Game loop
while (player1.HitPoints > 0 && player2.HitPoints > 0)
{
    // Player 1's turn
    Console.WriteLine("Player 1's turn:");
    player1.Hit(player2, sword);
    player1.Loot(object1);
    Console.WriteLine();

    // Player 2's turn
    Console.WriteLine("Player 2's turn:");
    player2.Hit(player1, bow);
    Console.WriteLine();

    // Print status
    Console.WriteLine("Status:");
    Console.WriteLine($"{player1.Name}: {player1.HitPoints} HP");
    Console.WriteLine($"{player2.Name}: {player2.HitPoints} HP");
    Console.WriteLine();
}

// Game over
if (player1.HitPoints <= 0)
{
    Console.WriteLine($"{player2.Name} wins!");
}
else
{
    Console.WriteLine($"{player1.Name} wins!");
}

