using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }
}
