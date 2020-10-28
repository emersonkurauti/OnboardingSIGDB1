using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IGravarCargoService
    {
        NotificationContext notificationContext { get; set; }
        int Id { get; set; }

        void ValidarEntidade();
        void ValidarCargoExiste(int id);
        bool Adicionar(CargoDTO dto);
        bool Alterar(int id, CargoDTO dto);
    }
}
