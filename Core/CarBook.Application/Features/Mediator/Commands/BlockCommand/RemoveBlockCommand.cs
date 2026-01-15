using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.BlockCommand
{
    public class RemoveBlockCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveBlockCommand(int id)
        {
            Id = id;
        }
    }
}
