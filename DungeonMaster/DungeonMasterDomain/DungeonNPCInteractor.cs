using DungeonMasterRepository;
using DungeonMasterDTO;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace DungeonMasterDomain
{
    public class DungeonNPCInteractor
    {
        private DungeonNPCRepository _repository;
        public DungeonNPCInteractor()
        {
            _repository= new DungeonNPCRepository();
        }
    }
}
