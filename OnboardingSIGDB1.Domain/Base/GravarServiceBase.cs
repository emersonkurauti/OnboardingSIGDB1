using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Interfaces;

namespace OnboardingSIGDB1.Domain.Base
{
    public class GravarServiceBase
    {
        public INotificationContext notificationContext { get; set; }
        protected IUnitOfWork _unitOfWork { get; set; }
        protected IMapper _mapper { get; set; }
    }
}
