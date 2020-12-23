using services.cross.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace services.cross.Services
{
    public class ButifyServices : IButifyRepository
    {
        public async Task<string> GetButifyAsync(string text)
        {
            return await Task.Run(() =>
            {
                string responseText = text.Replace("{", "{\n").Replace("}", "}\n").Replace("[", "[\n").Replace("]", "]\n").Replace(":", ":\n");
                return responseText;
            });
        }
    }
}
