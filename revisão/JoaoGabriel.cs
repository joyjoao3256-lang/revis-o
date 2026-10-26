

namespace Entidades

{
    public class JoaoGabriel
    {
        public string nome { get; set; }
        static int idade;
        public List<string> habilidades { get; set; }
        = new List<string>();

        public int Idade { get; set; }

        public void ExibirDados()
        {
            Console.WriteLine($"Meu nome é{nome},tenho {idade} anos, Minhas habilidades são {habilidades}");
            foreach (string habilidades1 in habilidades)
            {
                Console.WriteLine($"- {habilidades}");
            }
        }
    }
}
