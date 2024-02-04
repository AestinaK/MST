using App.Setup.Dto;
using App.Setup.Model;

namespace App.Setup.Service.Interface;

public interface IIncomeCService
{
    Task<IncomeCategory> CreateIncomeCategory(IncomeCDto dto);
}