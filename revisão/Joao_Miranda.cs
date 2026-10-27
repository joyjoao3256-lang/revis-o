

namespace revisão
{
    public class Joao_Miranda
    {
        public string Nome { get; set; }

        public List<string> Habilidades { get; set; }
        =new List<string>();

        public int Idade { get; set; }

        public void ExibirDados()
        {
            Console.WriteLine($"Meu nome é {Nome}, tenho {Idade} anos, Minhas Habilidades São {Habilidades}");
            foreach (string Habilidade2 in Habilidades)
            {
                Console.WriteLine($"- {Habilidades}");
            }
        }
    }
}
