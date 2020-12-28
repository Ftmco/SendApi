using services.cross.Repository;
using System.Threading.Tasks;

namespace services.cross.Services
{
    public class ButifyServices : IButifyRepository
    {
        public async Task<string> GetButifyAsync(string text)
        {
            return await Task.Run(() =>            
                 text.Replace("{", "{\n").Replace("}", "}\n").Replace("[{", "[{\n\t").Replace("\"","\t").Replace(",",",\n").Trim());
        }
    }
}
