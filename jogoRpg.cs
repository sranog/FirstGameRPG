int heroLife = 10;
int monsterLife = 10;
int bossLife = 30;

int ataque;
Random random = new Random();

do
{
  // ataque do herói
  ataque = random.Next(1, 11);

  monsterLife -= ataque;
  Console.WriteLine($"O monstro foi atacado e perdeu {ataque} de vida. Agora ele tem {monsterLife} de vida.");

  if (monsterLife <= 0 && heroLife > 0)
  {
    heroLife += 20;
    Console.WriteLine($"O monstro morreu. Sua vida aumentou +20 pontos! Total: {heroLife} pontos.");
    Console.WriteLine("Um Boss apareceu!");
    break;
  }

  // ataque do monstro
  ataque = random.Next(1, 11);
  heroLife -= ataque;
  Console.WriteLine($"O herói foi atacado e perdeu {ataque} de vida. Agora ele tem {heroLife} de vida.");

  if (heroLife <= 0)
  {
    Console.WriteLine("O monstro era forte  demais!");
    break;
  }

} while (heroLife > 0 && monsterLife > 0);

while (heroLife > 0)
{
  // ataque do herói no boss
  ataque = random.Next(1, 11);
  bossLife -= ataque;
  Console.WriteLine($"O Boss foi atacado e perdeu {ataque} de vida. Agora ele tem {bossLife} de vida.");

  if (bossLife <= 0)
  {
    Console.WriteLine("O Boss morreu!");
    break;
  }

  // ataque do boss no herói
  ataque = random.Next(1, 11);
  heroLife -= ataque;
  Console.WriteLine($"O herói foi atacado e perdeu {ataque} de vida. Agora ele tem {heroLife} de vida.");

} 

Console.WriteLine(bossLife <= 0 && heroLife > 0 ? "O herói derrotou todos os inimigos!" : "Você perdeu. Fim de jogo!");
