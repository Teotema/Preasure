
using DataTransferObjects;

namespace Services
{
    public interface IDynamicDbService
    {
        public Task<PresureDto[]> GetPresuares();
    }
}
