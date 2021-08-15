using System;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace LiteDB.Async
{
    public partial class LiteCollectionAsync<T>
    {
        /// <summary>
        /// Delete a single document on collection based on _id index. Returns true if document was deleted
        /// </summary>
        public Task<bool> DeleteAsync(BsonValue id)
        {
            VerifyNoClosedTransaction();
            return Database.EnqueueAsync(
                () => UnderlyingCollection.Delete(id));
        }

        /// <summary>
        /// Delete all documents based on predicate expression. Returns how many documents was deleted
        /// </summary>
        public Task<int> DeleteManyAsync(BsonExpression predicate)
        {
            VerifyNoClosedTransaction();
            return Database.EnqueueAsync(
                () => UnderlyingCollection.DeleteMany(predicate));
        }

        /// <summary>
        /// Delete all documents based on predicate expression. Returns how many documents was deleted
        /// </summary>
        public Task<int> DeleteManyAsync(string predicate, BsonDocument parameters)
        {
            VerifyNoClosedTransaction();
            return Database.EnqueueAsync(
                () => UnderlyingCollection.DeleteMany(predicate, parameters));
        }

        /// <summary>
        /// Delete all documents based on predicate expression. Returns how many documents was deleted
        /// </summary>
        public Task<int> DeleteManyAsync(string predicate, params BsonValue[] args)
        {
            VerifyNoClosedTransaction();
            return Database.EnqueueAsync(
                () => UnderlyingCollection.DeleteMany(predicate, args));
        }

        /// <summary>
        /// Delete all documents based on predicate expression. Returns how many documents was deleted
        /// </summary>
        public Task<int> DeleteManyAsync(Expression<Func<T, bool>> predicate)
        {
            VerifyNoClosedTransaction();
            return Database.EnqueueAsync(
                () => UnderlyingCollection.DeleteMany(predicate));
        }
 
         /// <summary>
        /// Delete all documents inside collection. Returns how many documents was deleted. Run inside current transaction
        /// </summary>
        public Task<int> DeleteAllAsync()
        {
            VerifyNoClosedTransaction();
            return Database.EnqueueAsync(
                () => UnderlyingCollection.DeleteAll());
        }
   }
}