using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MS.Customer.Domain.Base
{
    public abstract class BaseClassDb
    {
        public BaseClassDb()
        {
            SetActive();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uid { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset? UpdatedAt { get; private set; }
        public bool Active { get; private set; }

        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();

        public void SetUid(Guid uid)
        {
            Uid = uid;
        }

        public void SetCreatedAt(DateTimeOffset dateTime)
        {
            if (CreatedAt == null || CreatedAt == DateTimeOffset.MinValue)
                CreatedAt = dateTime;
        }

        public void SetUpdatedAt(DateTimeOffset dateTime)
        {
            UpdatedAt = dateTime;
        }

        public void SetActive()
        {
            Active = true;
        }

        public void SetInactive()
        {
            Active = false;
        }

        public bool SetActiveOrInactive()
        {
            Active = !Active;

            return Active;
        }
    }
}
