using GameFramework.Interface;
using GameFramework.Models;
using System.Threading.Tasks;

World world = new World(6, 6);

Player player = new Player("Player", 100, 2, 30);

Enemy enemy = new Enemy("Enemy", 100, 10);
var counter = 0;


world.AddCreature(player);
world.AddCreature(enemy);

AttackItem knife = new AttackItem("knife", 13);
AttackItem sword = new AttackItem("sword", 18);
AttackItem mace = new AttackItem("mace", 8);
world.AddWorldObject(knife);
world.AddWorldObject(sword);
world.AddWorldObject(mace);

AttackItem knife1 = new AttackItem("knife", 13);
AttackItem sword1 = new AttackItem("sword", 18);
AttackItem mace1 = new AttackItem("mace", 8);
world.AddWorldObject(knife1);
world.AddWorldObject(sword1);
world.AddWorldObject(mace1);

DefenceItem shield1 = new DefenceItem("wooden shield", 3);
DefenceItem shield2 = new DefenceItem("stone shield", 4);
DefenceItem shield3 = new DefenceItem("iron shield", 5);
world.AddWorldObject(shield1);
world.AddWorldObject(shield2);
world.AddWorldObject(shield3);

DefenceItem shield4 = new DefenceItem("wooden shield", 2);
DefenceItem shield5 = new DefenceItem("stone shield", 3);
DefenceItem shield6 = new DefenceItem("iron shield", 6);
world.AddWorldObject(shield4);
world.AddWorldObject(shield5);
world.AddWorldObject(shield6);
bool playerTurn = true;



while (player.Health > 0 && enemy.Health > 0)
{
    counter++;
    Thread.Sleep(2000);
    Console.Clear();
    player.DisplayPlayerInfo(player);
    enemy.DisplayEnemyInfo(enemy);

    if (playerTurn)
    {
        PlayerTurn(counter);
    }
    else
    {
        EnemyTurn();
    }

    playerTurn = !playerTurn;
}

Console.Clear();
if (player.Health <= 0)
{
    Logger.Log("Game over. You died.");
}
else
{
    Logger.Log("Congratulations. You won.");
}

Console.ReadLine();

void PlayerTurn(int getCounter)
{
    Logger.Log("Player's turn.");
    if (Position.IsObjectWithInOneCell(player.position, enemy.position))
    {
        player.Attack(enemy);

        Logger.Log($"You attacked {player.Damage}");
    }
    else if (getCounter % 5 == 0 && Position.IsObjectWithInGivenNumberOfCells(player.position, enemy.position, 5)) //decorator design pattern used here
    {
        
        IPowerAttack powerAttack = new AttackDecoratorPattern(player);
        powerAttack = new SuperAttack(powerAttack, 3);
        if (player.Energy >= 10)
        {
            powerAttack.PowerAttack(enemy);
            Logger.Log($"You attacked with Fire attack {player.Damage}");
        }
        else
        {
            Logger.Log("Not enough energy");
        }
    }
    else
    {
        PickUpItems();
        player.PlayerRandomMovement(1, world);
    }
    Thread.Sleep(500);
}

void PickUpItems()
{
    var objectsToRemove = new List<IWorldObject>();
    foreach (var obj in world.worldObjects)
    {
        if (Position.IsObjectWithInOneCell(player.position, obj.position))
        {
            if (obj is DefenceItem)
            {
                player.PickUp((DefenceItem)obj); 
                objectsToRemove.Add(obj);
                player.Defence += obj.Defence;
            }
            else if (obj is AttackItem)
            {
                player.PickUp((AttackItem)obj);
                objectsToRemove.Add(obj);
                player.Damage += obj.Damage;
            }

        }

    }
    foreach (var obj in objectsToRemove)
    {
        world.RemoveWorldObject(obj);
    }
}

void EnemyTurn()
{
    Logger.Log("Enemy's turn.");
    if (Position.IsObjectWithInOneCell(player.position, enemy.position))
    {
        enemy.Attack(player);
        Logger.Log($"Enemy attacked {enemy.Damage}");
    }
    else
    {
        PickUpItemsForEnemy();
        enemy.EnemyRandomMovement(1, world);
    }

    Thread.Sleep(500);
}

void PickUpItemsForEnemy()
{
    foreach (var obj in world.worldObjects.ToList())
    {
        if (Position.IsObjectWithInOneCell(enemy.position, obj.position))
        {
            // Have the enemy pick up the object automatically
            if (obj is DefenceItem)
            {
                enemy.PickUp((DefenceItem)obj);
                world.RemoveWorldObject(obj);
                Logger.Log($"Enemy picked up {obj.Name}.");
                enemy.Defence += obj.Defence;
            }
            else if (obj is AttackItem)
            {
                enemy.PickUp((AttackItem)obj);
                world.RemoveWorldObject(obj);
                Logger.Log($"Enemy picked up {obj.Name}.");
                enemy.Damage += obj.Damage;
            }
        }
    }
}

