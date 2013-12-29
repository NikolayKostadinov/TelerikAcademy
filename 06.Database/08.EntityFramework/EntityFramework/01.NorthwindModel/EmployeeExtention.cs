// TODO: By inheriting the Employee entity class create a class which allows 
// employees to access their corresponding territories as property of type EntitySet<T>.

namespace NorthwindModel
{
    using System;
    using System.Collections.Generic;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Linq;

    [Table(Name = "Employees")]
    public partial class Employee
    {
        private EntitySet<Territory> teritories;
        [AssociationAttribute(Storage = "teritories", OtherKey = "EmployeeID")]
        public EntitySet<Territory> Teritories
        {
            get { return this.teritories; }
            set { this.teritories.Assign(value); }
        }
    }
}
