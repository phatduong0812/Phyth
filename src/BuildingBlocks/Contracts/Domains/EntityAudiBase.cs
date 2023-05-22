using Contracts.Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domains
{
    public abstract class EntityAudiBase<T> : EntityBase<T>, IAuditable
    {
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? LastModifyDate { get; set; }
    }
}
