using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Core.Lib.Domain.Model
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}

