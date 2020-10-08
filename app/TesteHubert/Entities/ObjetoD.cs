namespace TesteHubert.Entities
{
    public class ObjetoD
    {
        public ObjetoD(string nome, string logradouro, string cidade, string uF)
        {
            Nome = nome;
            Logradouro = logradouro;
            Cidade = cidade;
            UF = uF;
        }

        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}
