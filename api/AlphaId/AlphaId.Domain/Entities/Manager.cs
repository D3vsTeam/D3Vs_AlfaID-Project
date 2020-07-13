using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaId.Domain.Entities
{
    public class Manager : BaseEntity
    {
        public string Name { get; set; }

        public string Area { get; set; }
    }
}
