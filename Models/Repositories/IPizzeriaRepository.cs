using Microsoft.Extensions.Hosting;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Models.Repositories
{
    public interface IPizzeriaRepository
    {

        List<Pizza> All();

        Pizza GetById(int id);
        void Create(Pizza pizza, List<int> IngredientiSelezionati);
        void Modifica(Pizza pizza, Pizza formData, List<int>? IngredientiSelezionati);
        void Delete(Pizza pizza);



    }
}