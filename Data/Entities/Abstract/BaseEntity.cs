using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Abstract
{
    public enum Status {Active=1,Modified,Passive }
    public abstract class BaseEntity
    {
        private Status _status = Status.Active;
        private DateTime _created=DateTime.Now;

        public int Id { get; set; }
        public DateTime CreatedDate { get=>_created; set=>_created=value; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get => _status; set => _status = value; }
    }
}
