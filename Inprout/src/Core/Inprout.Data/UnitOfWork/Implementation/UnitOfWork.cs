namespace Inprout.Data.UnitOfWork.Implementation
{
    using System.Threading.Tasks;
    using Entities;
    using Repository.Contracts;
    using Contracts;
    using Repository.Implementation;
    using Context;
    using System.Data.Entity.Validation;
    using System.Text;

    public class UnitOfWork : IUnitOfWork
    {
        private IInproutDbContext InproutDbContext { get; }

        public UnitOfWork() //// TODO: missing di for InproutDbContext
        {
            InproutDbContext = new InproutDbContext();
        }

        private IDeletableRepository<User> _users { get; set; }

        public IDeletableRepository<User> Users => _users ?? new DeletableRepository<User>(InproutDbContext);


        public void Save()
        {
            try
            {
                InproutDbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string message = GetDatabaseErrorMessage(ex);

                throw new DbEntityValidationException(message, ex);
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await InproutDbContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                string message = GetDatabaseErrorMessage(ex);

                throw new DbEntityValidationException(message, ex);
            }
        }

        private string GetDatabaseErrorMessage(DbEntityValidationException ex)
        {
            var message = new StringBuilder("Error Message: ");

            foreach (var evResult in ex.EntityValidationErrors)
            {
                var innerMessage = new StringBuilder($"Entity of type {evResult?.Entry?.Entity?.GetType()?.Name} in state \"{evResult?.Entry?.State}\" has the following validation errors: ");

                foreach (var ve in evResult?.ValidationErrors)
                {
                    innerMessage.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                }

                message.AppendLine(innerMessage.ToString());
            }

            return message.ToString();
        }
    }
}
