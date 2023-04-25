using System.Text.Json;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class LanguageServices
    {
        
        public async Task<List<Language>> GetAll()
        {

            return await new LanguageRepositories().GetAll();

        }

        public async Task Create(Language lg)
        {
            var list = await new LanguageRepositories().GetAll();
            var item = list.FirstOrDefault(x => x.Id.ToLower() == lg.Id.ToLower());
            if(item != null) 
            {
                throw new Exception();
            }
            list.Add(lg);
            await new LanguageRepositories().WriteNew(list);
        }

    }
}
