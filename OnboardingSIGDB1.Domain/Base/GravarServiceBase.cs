using AutoMapper;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Notifications;

namespace OnboardingSIGDB1.Domain.Base
{
    public class GravarServiceBase
    {
        public NotificationContext notificationContext { get; set; }
        protected IUnitOfWork _unitOfWork { get; set; }
        protected IMapper _mapper { get; set; }
    }
}
