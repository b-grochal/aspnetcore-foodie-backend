using Foodie.Shared.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : AuditableUpdateCommand, IRequest<UpdateCategoryCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
