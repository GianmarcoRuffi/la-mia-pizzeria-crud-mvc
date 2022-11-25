using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Models.Repositories
{
    public interface IDbPizzeriaRepository
    {

        List<Pizza> All();
        void Create(Pizza pizza, List<int> IngredientiSelezionati);
        void Delete(Pizza pizza);
        Pizza GetById(int id);
        void Update(Pizza pizza, Pizza formData, List<int>? IngredientiSelezionati);
    }
}