using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class LanguageRepositories
    {
        static string Path = "C:\\Code Main\\ASP.Net Core\\2004\\WebApplication1\\bin\\Debug\\net6.0\\languageBD.txt";
        public async Task<List<Language>> GetAll()
        {
            try
            {
                using StreamReader sr2 = new StreamReader(Path, Encoding.UTF8);
                string result = await sr2.ReadToEndAsync();
                return JsonSerializer.Deserialize<List<Language>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Language> GetById(string id)
        {
            try
            {
                var languages = await GetAll();
                return languages.FirstOrDefault(x => x.Id.ToLower() == id.ToLower());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task WriteNew(List<Language> language)
        {
            try
            {

                using StreamWriter sw = new StreamWriter(Path);
                string text = JsonSerializer.Serialize(language);
                sw.WriteLine(text);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
