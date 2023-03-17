using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryCommandResponse>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            this.Id = id;
        }
    }
}
