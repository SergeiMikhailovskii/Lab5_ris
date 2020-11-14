using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {

        private List<Currency> currencies = new List<Currency>()
        {
            new Currency("USD", 2.56),
            new Currency("EUR", 3.02),
            new Currency("RUB", 0.03),
            new Currency("BYN", 1),
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCurrencyListsData();
            }
        }

        private void BindCurrencyListsData()
        {
            var items = new string[currencies.Count];

            for (int i = 0; i<currencies.Count; i++)
            {
                items[i] = currencies[i].Name;
            }

            Array.Sort(items);

            CurrencyFromList.DataSource = items;
            CurrencyFromList.DataBind();

            CurrencyToList.DataSource = items;
            CurrencyToList.DataBind();
        }

        protected void CalculateBtn_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                Currency currencyFrom = currencies.Find(it => it.Name.Equals(CurrencyFromList.SelectedValue));
                Currency currencyTo = currencies.Find(it => it.Name.Equals(CurrencyToList.SelectedValue));
                
                    double converted = currencyFrom.Price / currencyTo.Price * Convert.ToDouble(SumTextBox.Text);
                    ResultLb.Visible = true;
                    ResultLb.Text = converted + " " + currencyTo.Name;

            }
        }

        protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                var input = Convert.ToDouble(e.Value);
                if (input > 0)
                {
                    e.IsValid = true;
                } else
                {
                    e.IsValid = false;
                }
            } catch (FormatException exc)
            {
                e.IsValid = false;
            }
        }

    }

    internal class Currency
    {
        public Currency(string name, double price)
        {
            Price = price;
            Name = name;
        }

        public double Price { get; set; }
        public string Name { get; set; }
    }
}