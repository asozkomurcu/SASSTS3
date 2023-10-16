using SASSTS.Application.Models.Dtos.BillsDtos;
using SASSTS.Application.Models.RequestModels.BillsRM;
using SASSTS.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Services.Abstraction
{
    public interface IBillService
    {
        Task<Result<List<BillDto>>> GetAllBills();
        Task<Result<BillDto>> GetBillById(GetBillByIdVM getBillByIdVM);

        Task<Result<int>> CreateBill(CreateBillVM createBillVM);
        Task<Result<int>> UpdateBill(UpdateBillVM updateBillVM);
    }
}
