using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace services.cross.Repository
{
    public interface IButifyRepository
    {
        Task<string> GetButifyAsync(string text);
    }
}
