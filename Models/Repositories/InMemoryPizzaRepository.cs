namespace la_mia_pizzeria_static.Models.Repositories
{
    public class InMemoryPizzaRepository : IPizzeriaRepository
    {
        public List<Pizza> All()
        {
            throw new NotImplementedException();
        }

        public void Create(Pizza pizza, List<int> IngredientiSelezionati)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public Pizza GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Modifica(Pizza pizza, Pizza formData, List<int>? IngredientiSelezionati)
        {
            throw new NotImplementedException();
        }
    }
}
