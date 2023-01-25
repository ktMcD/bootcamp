using DungeonMasterRepository;
using DungeonMasterDTO;
using Microsoft.Extensions.Options;

namespace DungeonMasterDomain
{
    public class DungeonCharacterInteractor
    {
        public DungeonCharacterRepository _repository;

        public DungeonCharacterInteractor()
        {
            _repository = new DungeonCharacterRepository();
        }
        public List<Character> GetAllCharacters()
        {
            return _repository.GetAllCharacters();
        }


    }
}
