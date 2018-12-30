using Lab7Website.Models;
using Lab7Website.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.UI;

namespace Lab7Website
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public IQueryable<Company> CompaniesContactData_GetItem()
        {
            Collection<Company> companies;
            string error;

            if (CompaniesRepository.TryToGetCompanies(out companies, out error))
            {
                return companies.AsQueryable();
            }
            else
            {
                actionOutcome.Text = "Υπήρξε πρόβλημα κατά την εμφάνιση των εταιρειών.";
                return Enumerable.Empty<Company>().AsQueryable();
            }
        }

        public void CompaniesContactData_InsertItem()
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CompaniesContactData_DeleteItem(int id)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CompaniesContactData_UpdateItem(int id)
        {

        }
    }
}