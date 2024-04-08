using APIMVC.Models;

namespace APIMVC.Data
{
    public interface IColor
    {
        public Task GetConnectedToAPI();
        public Task<List<CDatum>> GetAllColors();
        public Task<DogPicture> GetDogPicture();

    }
}
