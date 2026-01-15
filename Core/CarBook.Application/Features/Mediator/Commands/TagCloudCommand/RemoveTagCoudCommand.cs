using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommand
{
    public class RemoveTagCoudCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveTagCoudCommand(int id)
        {
            Id = id;
        }
    }
}
