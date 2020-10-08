using System.Collections.Generic;
using System.Threading.Tasks;
using TesteHubert.Interfaces;

namespace TesteHubert.Services
{
    public class TesteService : ITesteService
    {
        private readonly ITesteRepository _testeRepository;
        public TesteService(ITesteRepository testeRepository)
        {
            _testeRepository = testeRepository;
        }
        public async Task<string> BuscarItemA(int id, string data)
        {
            List<string> ItensA = new List<string>();

            ItensA = await _testeRepository.BuscarItemA(id, data);
            var jsonA = Newtonsoft.Json.JsonConvert.SerializeObject(ItensA);

            return jsonA;
        }
        public async Task<string> BuscarItemB(int id, string dataInicial, string dataFinal)
        {
            List<decimal> ItensB = new List<decimal>();

            ItensB = await _testeRepository.BuscarItemB(id, dataInicial, dataFinal);
            var jsonB = Newtonsoft.Json.JsonConvert.SerializeObject(ItensB);

            return jsonB;
        }
        public async Task<string> BuscarItemC(int id, string dataDePagamento, decimal valorPago)
        {
            int ItensC = await _testeRepository.BuscarItemC(id, dataDePagamento, valorPago);
            var jsonC = Newtonsoft.Json.JsonConvert.SerializeObject(ItensC);

            return jsonC;
        }
        public async Task<string> BuscarItemD(int id)
        {
            var ItensD = await _testeRepository.BuscarItemD(id);
            var jsonD = Newtonsoft.Json.JsonConvert.SerializeObject(ItensD);

            return jsonD;
        }
    }
}
