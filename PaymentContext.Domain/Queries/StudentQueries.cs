using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Queries
{
    public class StudentQueries
    {
        public static Expression<Func<Student, bool>> GetStudentByDocument(string documentNumber)
        {
            /// <summary>
            ///     You can use the return as helper in Entity Framework Queries.
            /// </summary> 
            /// <example>
            ///     public Student GetStudentFromDatabase() {
            ///         return _context
            ///             .Student
            ///             .Where(
            ///                 StudentQueries.GetStudent(12345678901) // It's this method.
            ///             )
            ///             .FirstOrDefult();
            ///     }
            /// </example>
            /// 
            return x => x.Document.Number == documentNumber;
        }
    }
}
