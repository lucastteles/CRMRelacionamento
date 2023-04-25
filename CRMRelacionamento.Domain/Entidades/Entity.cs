using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRelacionamento.Domain.Enidades
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
           
        }

        public Guid Id { get; set; }
    }
}
