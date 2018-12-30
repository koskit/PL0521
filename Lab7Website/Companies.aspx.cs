using Lab7Website.Models;
using Lab7Website.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lab7Website
{
    public partial class Companies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Company> CompaniesData_GetData()
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

        public void CompaniesData_DeleteItem(int CompanyId)
        {
            string error;
            if (CompaniesRepository.TryToDeleteCompany(new Company(CompanyId), out error))
            {
                actionOutcome.Text = "Διαγραφή επιτυχής";
            }
            else
            {
                actionOutcome.Text = error;
            }
        }

        public void CompaniesData_UpdateItem(int CompanyId, string name, string description)
        {
            string error;

            Collection<Company> companies;
            CompaniesRepository.TryToGetCompanies(out companies, out error);

            Company companyModel = companies
                .Where(c => c.CompanyId == CompanyId).Single();
            companyModel.Name = name;
            companyModel.Description = description;

            if (CompaniesRepository.TryToEditCompany(companyModel, out error))
            {
                actionOutcome.Text = "Επεξεργασία επιτυχής";
            }
            else
            {
                actionOutcome.Text = error;
            }
        }
    }
}