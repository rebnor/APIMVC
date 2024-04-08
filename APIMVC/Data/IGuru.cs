using APIMVC.Models;

namespace APIMVC.Data
{
    public interface IGuru
    {
        public Task<List<string>> GetPartners();

    }
}