using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarFeatureResult
{
    public class GetCarFatureByCarIdQueryResult
    {
        public int CarFeatureID { get; set; } 
        public int FeatureID { get; set; }
        public string Name { get; set; }
        public bool Avaliable { get; set; }
    }
}
