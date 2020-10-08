using System.Threading.Tasks;

namespace TesteHubert.Interfaces
{
    public interface ITesteService
    {
        public Task<string> BuscarItemA(int id, string data);
        public Task<string> BuscarItemB(int id, string dataInicial, string dataFinal);
        public Task<string> BuscarItemC(int id, string dataDePagamento, decimal valorPago);
        public Task<string> BuscarItemD(int id);

    }
}
