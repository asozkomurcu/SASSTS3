using SASSTS.Application.Models.Dtos.PurchaseRequestDtos;
using SASSTS.Application.Models.RequestModels.PurchaseRequestsRM;
using SASSTS.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Services.Abstraction
{
    public interface IPurchaseRequestService
    {
        Task<Result<List<PurchaseRequestDto>>> GetAllPurchaseRequests();
        Task<Result<PurchaseRequestDto>> GetPurchaseRequestById(GetPurchaseRequestByIdVM getPurchaseRequestByIdVM);
        Task<Result<int>> CreatePurchaseRequest(CreatePurchaseRequestVM createPurchaseRequest);
        Task<Result<int>> UpdatePurchaseRequest(UpdatePurchaseRequestVM updatePurchaseRequestVM);
        Task<Result<int>> DeletePurchaseRequest(DeletePurchaseRequestVM deletePurchaseRequest);
    }
}
