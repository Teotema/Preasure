using Services;

namespace DbServices
{
    public class UnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;

        protected IUnitOfWork UnitOfWork => _unitOfWork;

        protected UnitOfWorkService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }
    }
}