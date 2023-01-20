using DungeonMasterRepository;
using DungeonMasterDTO;
using Microsoft.Extensions.Options;

namespace DungeonMasterDomain
{
    public class DungeonCellInteractor
    {
        private DungeonCellRepository _repository;
        public DungeonCellInteractor()
        {
            _repository = new DungeonCellRepository();
        }

        // call / use repository CRUD methods
    }
}
