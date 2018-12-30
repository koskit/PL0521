using Lab7Website.Models;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Lab7Website.Repositories
{
    /// <summary>
    /// Repository class that provides a middle layer between the website and the database
    /// for object oriented manipulation of the table through <see cref="Company"/> models.
    /// </summary>
    public static class CompaniesRepository
    {
        #region Class Properties

        /// <summary>
        /// The connection string for the companies table.
        /// </summary>
        private static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["CompaniesTable"].ConnectionString;
            }
        }

        #endregion Class Properties

        #region Procedures

        /// <summary>
        /// Function that retrieves companies from the database.
        /// </summary>
        private static Collection<Company> RetrieveCompaniesProcedure()
        {
            Collection<Company> toReturn = new Collection<Company>();

            using (SqlConnection dbconnection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Company", dbconnection);

                dbconnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        toReturn.Add(
                            new Company(int.Parse(reader["CompanyId"].ToString()))
                            {
                                Description = reader["Description"].ToString(),
                                Limit = decimal.Parse(reader["Limit"].ToString()),
                                Name = reader["Name"].ToString(),
                                StartDate = DateTime.Parse(reader["StartDate"].ToString())
                            });
                    }

                    dbconnection.Close();
                }

                return toReturn;
            }
        }

        /// <summary>
        /// Function that adds a company entry to the database country table.
        /// </summary>
        /// <param name="toCreate">The company to create.</param>
        private static void CreateCompanyProcedure(Company toCreate)
        {
            using (SqlConnection dbconnection = new SqlConnection(ConnectionString))
            {
                dbconnection.Open();

                SqlCommand cmd = new SqlCommand()
                {
                    Connection = dbconnection,
                    CommandText = "INSERT INTO Company ([CompanyId], [Name], [Description], [StartDate], [Limit]) " +
                    "VALUES(@CompanyId, @Name, @Description, @StartDate, @Limit)"
                };

                cmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("CompanyId",toCreate.CompanyId),
                    new SqlParameter("Name",toCreate.Name),
                    new SqlParameter("Description",toCreate.Description ?? string.Empty),
                    new SqlParameter("StartDate",toCreate.StartDate),
                    new SqlParameter("Limit",toCreate.Limit)
                });

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Function that updates all columns from a country table entry.
        /// </summary>
        /// <param name="toEdit">The country to edit.</param>
        private static void EditCompanyProcedure(Company toEdit)
        {
            using (SqlConnection dbconnection = new SqlConnection(ConnectionString))
            {
                dbconnection.Open();

                SqlCommand cmd = new SqlCommand()
                {
                    Connection = dbconnection,
                    CommandText = "UPDATE Company " +
                    "SET [Name] = @Name, [Description] = @Description, [StartDate] = @StartDate, [Limit] = @Limit " +
                    "WHERE [CompanyId] = @CompanyId"
                };

                cmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("CompanyId",toEdit.CompanyId),
                    new SqlParameter("Name",toEdit.Name),
                    new SqlParameter("Description",toEdit.Description ?? string.Empty),
                    new SqlParameter("StartDate",toEdit.StartDate),
                    new SqlParameter("Limit",toEdit.Limit)
                });

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Functions that deletes a country entry from the database table.
        /// </summary>
        /// <param name="toDelete">The country to delete.</param>
        private static void DeleteCompanyProcedure(Company toDelete)
        {
            using (SqlConnection dbconnection = new SqlConnection(ConnectionString))
            {
                dbconnection.Open();

                SqlCommand cmd = new SqlCommand()
                {
                    Connection = dbconnection,
                    CommandText = "DELETE FROM Company WHERE [CompanyId] = @CompanyId"
                };

                cmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("CompanyId",toDelete.CompanyId)
                });

                cmd.ExecuteNonQuery();
            }
        }

        #endregion Procedures

        #region Public Methods

        /// <summary>
        /// Tries to get the companies for the repository.
        /// </summary>
        /// <param name="companies">The companies retrieved from the repository.</param>
        /// <param name="error">The errors that occured concatenated to a string.</param>
        /// <returns>True/false depending on if the retrieval was successful.</returns>
        public static bool TryToGetCompanies(out Collection<Company> companies, out string error)
        {
            companies = SafeExecute(RetrieveCompaniesProcedure, out error);
            return error == null;
        }

        /// <summary>
        /// Tries to create/add a company to the repository.
        /// </summary>
        /// <param name="toCreate">The company to create.</param>
        /// <param name="error">The errors that occured concatenated to a string.</param>
        /// <returns>True/false depending on if the creation was successful.</returns>
        public static bool TryToCreateCompany(Company toCreate, out string error)
        {
            SafeExecute(CreateCompanyProcedure, toCreate, out error);
            return error == null;
        }

        /// <summary>
        /// Tries to edit a company from the repository.
        /// </summary>
        /// <param name="toEdit">The company to edit.</param>
        /// <param name="error">The errors that occured concatenated to a string.</param>
        /// <returns>True/false depending on if the edit was successful.</returns>
        public static bool TryToEditCompany(Company toEdit, out string error)
        {
            Collection<Company> companies = SafeExecute(RetrieveCompaniesProcedure, out error);

            if (error != null)
                return false;

            Company original =
                companies.Where(c => c.CompanyId == toEdit.CompanyId).SingleOrDefault();

            if (original == null)
            {
                error = string.Format(
                    "Company with id '{0}' not found in the company repository.", toEdit.CompanyId);
                return false;
            }

            SafeExecute(EditCompanyProcedure, toEdit, out error);
            return error == null;
        }

        /// <summary>
        /// Tries to delete a country from the repository.
        /// </summary>
        /// <param name="toDelete">The country to delete.</param>
        /// <param name="error">The errors that occured concatenated to a string.</param>
        /// <returns>True/false depending on if the deletion was successful.</returns>
        public static bool TryToDeleteCompany(Company toDelete, out string error)
        {
            SafeExecute(DeleteCompanyProcedure, toDelete, out error);
            return error == null;
        }

        #endregion Public Methods

        #region Private Helper Methods

        /// <summary>
        /// Executes the given procedure function within a try block. If an exception is thrown,
        /// returns null and outs the error variable that contains the exception message.
        /// </summary>
        /// <typeparam name="T">The type of the return object.</typeparam>
        /// <param name="procedure">The function to run.</param>
        /// <param name="error">The error if an exception was thrown. Null otherwise.</param>
        /// <returns>The returned object of the procedure function parameter.</returns>
        private static T SafeExecute<T>(Func<T> procedure, out string error) where T : class
        {
            error = null;

            try { return procedure(); }
            catch (Exception ex)
            {
                error = ex.InnerException == null ?
                    string.Format("Exception: '{0}'", ex.Message) :
                    string.Format("Exception: '{0}', Inner Exception '{1}'", ex.Message, ex.InnerException.Message);

                return null;
            }
        }

        /// <summary>
        /// Executes the given procedure function within a try block. If an exception is thrown,
        /// returns null and outs the error variable that contains the exception message.
        /// </summary>
        /// <typeparam name="T">The type of the parameter object of the function.</typeparam>
        /// <param name="procedure">The function to run.</param>
        /// <param name="parameter">The parameter for the given function parameter.</param>
        /// <param name="error">The error if an exception was thrown. Null otherwise.</param>
        /// <returns>The returned object of the procedure function parameter.</returns>
        private static void SafeExecute<T>(Action<T> procedure, T parameter, out string error)
        {
            error = null;

            try { procedure(parameter); }
            catch (Exception ex)
            {
                error = ex.InnerException == null ?
                    string.Format("Exception: '{0}'", ex.Message) :
                    string.Format("Exception: '{0}', Inner Exception '{1}'", ex.Message, ex.InnerException.Message);
            }
        }

        #endregion Private Helper Methods
    }
}