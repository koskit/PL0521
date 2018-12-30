using System;

namespace Lab7Website.Models
{
    /// <summary>
    /// Company model for [dbo].[Company] table.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// The id of the company.
        /// </summary>
        public int CompanyId { get; private set; }

        /// <summary>
        /// The name of the company.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the company.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The start date of the company.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The money limit of the company.
        /// </summary>
        public decimal Limit { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class with the 
        /// <see cref="CompanyId"/> of the model already set.
        /// </summary>
        /// <param name="id">The id of the company.</param>
        public Company(int id)
        {
            CompanyId = id;

            //Initialization of start date to minimum value -> Sql does not support null datatimes.
            //Null on sql is minimum value.
            StartDate = DateTime.MinValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        public Company() { }
    }
}