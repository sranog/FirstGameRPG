using System;

public class Status
{
  public int VidaMaxima { get; set; }
  public int VidaAtual { get; set; }
  public int ManaMaxima { get; set; }
  public int ManaAtual { get; set; }
  public int Forca { get; set; }
  public int Defesa { get; set; }
  public float CriticalChance { get; set; }

  /* public int Inteligencia { get; set; }
     public int Fe { get; set; }
     public int Destreza { get; set; }
     public int Vigor { get; set; }
      public int Arcano { get; set; } */
  public Status(
 int vidaAtual,
 int vidaMaxima,
 int manaAtual,
 int manaMaxima,
 int forca,
 int defesa,
 float criticalChance
)
  {
    VidaAtual = vidaAtual;
    VidaMaxima = vidaMaxima;
    ManaAtual = manaAtual;
    ManaMaxima = manaMaxima;
    Forca = forca;
    Defesa = defesa;
    CriticalChance = criticalChance;
  }
}
public class  Personagem
{
    public string Nome { get; set; }
    public int Nivel { get; set; }
    public Status Atributos { get; set; } 

    public Personagem(string nome, int nivel, Status atributos)
    {
        Nome = nome;
        Nivel = nivel;
        Atributos = atributos;
    }       
}
public class Item
{
    public string Nome { get; set; }
    public string Tipo { get; set; } // Exemplo: "Arma", "Armadura", "Poção"
    public int Valor { get; set; } // Valor de ataque, defesa ou cura

    /* public string Descricao { get; set; } // Descrição do item
    public int Durabilidade { get; set; } // Durabilidade do item, se aplicável 
    public int NivelRequerido { get; set; } // Nível mínimo necessário para usar o item 
    public  int Quantidade { get; set; } // Quantidade do item no inventário   
    public int Preco { get; set; } // Preço do item para compra ou venda */

    public Item(string nome, string tipo, int valor)
    {
        Nome = nome;
        Tipo = tipo;
        Valor = valor;
    }
}
public class Habilidade
{
    public string Nome { get; set; }
    public string Tipo { get; set; } // Exemplo: "Ataque", "Defesa", "Suporte"
    public int CustoMana { get; set; } // Custo de mana para usar a habilidade
    public int Dano { get; set; } // Dano causado pela habilidade, se aplicável

 /* public float TempoRecarga { get; set; } // Tempo de recarga da habilidade
    public string Descricao { get; set; } // Descrição da habilidade
    public int NivelRequerido { get; set; } // Nível mínimo necessário para usar a habilidade */
 public Habilidade(string nome, string tipo, int custoMana, int dano)
    {
        Nome = nome;
        Tipo = tipo;
        CustoMana = custoMana;
        Dano = dano;
    }
}
public class Heroi : Personagem
{
    public int Experiencia { get; set; } 
    public string TipoArma { get; set; } 
    public string TipoArmadura { get; set; }
    public string Classe { get; set; } 

    public Heroi(string nome, int nivel, Status atributos, int experiencia, string tipoArma, string tipoArmadura, string classe)
        : base(nome, nivel, atributos)
    {
        Experiencia = experiencia;
        TipoArma = tipoArma;
        TipoArmadura = tipoArmadura;
        Classe = classe;
    }
}
public class Monstro :  Personagem
{
  
    public int NivelDificuldade { get; set; }
    public string TipoMonstro { get;set; } // Exemplo: "Orc", "Dragão", "Zumbi"
    public Monstro(string nome, int nivel, Status atributos, int nivelDificuldade, string tipoMonstro)
        : base(nome, nivel, atributos)
    {
        NivelDificuldade = nivelDificuldade;
        TipoMonstro = tipoMonstro;
    }
}

//  ATUALIZANDO O JOGO DE RPG PARA C#

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
