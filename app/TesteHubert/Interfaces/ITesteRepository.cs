using System.Collections.Generic;
using System.Threading.Tasks;
using TesteHubert.Entities;

namespace TesteHubert.Interfaces
{
    public interface ITesteRepository
    {
        public Task<List<string>> BuscarItemA(int id, string data);
        public Task<List<decimal>> BuscarItemB(int id, string dataInicial, string dataFinal);
        public Task<int> BuscarItemC(int id, string dataDePagamento, decimal valorPago);
        public Task<ObjetoD> BuscarItemD(int id);

    }
}
