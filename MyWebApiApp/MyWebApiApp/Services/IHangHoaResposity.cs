using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Services
{
    public interface IHangHoaResposity
    {
        List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1);
    }
}
