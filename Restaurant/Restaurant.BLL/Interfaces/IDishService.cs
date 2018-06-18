using System.Collections.Generic;
using Restaurant.BLL.DTO;

namespace Restaurant.BLL.Interfaces
{
    public interface IDishService
    {
        IEnumerable<IngredientsDTO> GetIngredientsFromId(int? id);
        IEnumerable<IngredientsDTO> GetIngredients();
        void Dispose();
    }
}
