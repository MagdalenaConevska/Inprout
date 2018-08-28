namespace Inprout.Data.Entities.Contracts
{
    using System;

    public interface IDeletableEntity : IBaseEntity
    {
        DateTime CreatedOn { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
