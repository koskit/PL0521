using Lab7Website.Models;
using Lab7Website.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab7Website
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }

        public IQueryable<Company> CompaniestData_GetItem()
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

        public IQueryable<Company> CompaniesContactData_GetItem()
        {
            string selectedIdString = Request.QueryString["id"];

            if (string.IsNullOrWhiteSpace(selectedIdString))
            {
                CompaniesContactData.Visible = false;
                return Enumerable.Empty<Company>().AsQueryable();
            }
            else
            {
                CompaniesContactData.Visible = true;
                Collection<Company> companies;
                string error;

                if (CompaniesRepository.TryToGetCompanies(out companies, out error))
                {
                    int selectedId = int.Parse(selectedIdString);
                    return companies.Where(c => c.CompanyId == selectedId).AsQueryable();
                }
                else
                {
                    actionOutcome.Text = "Υπήρξε πρόβλημα κατά την εμφάνιση των εταιρειών.";
                    return Enumerable.Empty<Company>().AsQueryable();
                }
            }
        }

        public void CompaniesContactData_InsertItem()
        {
            string name = GetFormControl<TextBox>("NameEditTextBox").Text;
            string description = GetFormControl<TextBox>("DescriptionEditTextBox").Text;
            string startDateString = GetFormControl<TextBox>("StartDateEditTextBox").Text;
            string limitString = GetFormControl<TextBox>("LimitEditTextBox").Text;

            Company newCompany = new Company()
            {
                Description = description,
                Limit = decimal.Parse(limitString),
                Name = name,
                StartDate = DateTime.Parse(startDateString)
            };

            string error;
            if (CompaniesRepository.TryToCreateCompany(newCompany, out error))
            {
                actionOutcome.Text = "Δημιουργία επιτυχής";
            }
            else
            {
                actionOutcome.Text = error;
            }
        }

        public void CompaniesContactData_UpdateItem(int companyId, string name, string description, DateTime startDate, decimal limit)
        {
            string error;

            Collection<Company> companies;
            CompaniesRepository.TryToGetCompanies(out companies, out error);

            Company companyModel = companies
                .Where(c => c.CompanyId == companyId).Single();
            companyModel.Name = name;
            companyModel.Description = description;
            companyModel.StartDate = startDate;
            companyModel.Limit = limit;

            if (CompaniesRepository.TryToEditCompany(companyModel, out error))
            {
                actionOutcome.Text = "Επεξεργασία επιτυχής";
            }
            else
            {
                actionOutcome.Text = error;
            }
        }

        public void CompaniesContactData_DeleteItem(int CompanyId)
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



        private T GetFormControl<T>(string id) where T : Control
        {
            return (T)CompaniesContactData.FindControl(id);
        }

        protected void CompaniesData_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedId = CompaniesData.SelectedDataKey.Value;
            Response.Redirect("Contact.aspx?id=" + selectedId.ToString(), true);
        }
    }
}