using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace StaffStockManagement
{
    public partial class Form1 : Form
    {
        private readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5208/api/Stock/") };

        public Form1()
        {
            InitializeComponent();
            cmbStockType.DataSource = Enum.GetValues(typeof(StockType)); 
        }

    
        private async void btnLoadStock_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await client.GetAsync("all");
                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var stockList = JsonConvert.DeserializeObject<List<Stock>>(json);
                    dgvStock.DataSource = stockList;
                }
                else
                {
                    MessageBox.Show($"Failed to load stock.\nError: {json}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stock: " + ex.Message);
            }
        }

  
        private async void btnAddStock_Click_1(object sender, EventArgs e)
        {
            try
            {
                var stock = new Stock
                {
                    DrugName = txtDrugName.Text,
                    Quantity = int.Parse(txtQuantity.Text),
                    ExpiryDate = dtpExpiryDate.Value,
                    ManufactureDate = dtpManufactureDate.Value,
                    Location = txtLocation.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    StockType = cmbStockType.SelectedItem.ToString() 
                };

                if (stock.StockType == "External")
                {
                    stock.SupplierName = txtSupplierName.Text;
                    stock.SupplierDate = dtpSupplierDate.Value;
                    stock.CompanyName = txtCompanyName.Text;
                }

                var json = JsonConvert.SerializeObject(stock, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("add", content);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Stock added successfully!");
                    btnLoadStock.PerformClick();
                }
                else
                {
                    MessageBox.Show($"Failed to add stock.\nStatus Code: {response.StatusCode}\nError: {responseBody}");
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Network error: " + httpEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

   
        private async void btnUpdateStock_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvStock.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select a stock item to update.");
                    return;
                }

                var selectedStock = (Stock)dgvStock.SelectedRows[0].DataBoundItem;
                selectedStock.DrugName = txtDrugName.Text;
                selectedStock.Quantity = int.Parse(txtQuantity.Text);
                selectedStock.ExpiryDate = dtpExpiryDate.Value;
                selectedStock.ManufactureDate = dtpManufactureDate.Value;
                selectedStock.Location = txtLocation.Text;
                selectedStock.Price = decimal.Parse(txtPrice.Text);
                selectedStock.StockType = cmbStockType.SelectedItem.ToString();

                if (selectedStock.StockType == "External")
                {
                    selectedStock.SupplierName = txtSupplierName.Text;
                    selectedStock.SupplierDate = dtpSupplierDate.Value;
                    selectedStock.CompanyName = txtCompanyName.Text;
                }

                var json = JsonConvert.SerializeObject(selectedStock, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"update/{selectedStock.Id}", content);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Stock updated successfully!");
                    btnLoadStock.PerformClick();
                }
                else
                {
                    MessageBox.Show($"Failed to update stock.\nStatus Code: {response.StatusCode}\nError: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating stock: " + ex.Message);
            }
        }

      
        private async void btnDeleteStock_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvStock.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select a stock item to delete.");
                    return;
                }

                var selectedStock = (Stock)dgvStock.SelectedRows[0].DataBoundItem;
                var response = await client.DeleteAsync($"delete/{selectedStock.Id}");
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Stock deleted successfully!");
                    btnLoadStock.PerformClick();
                }
                else
                {
                    MessageBox.Show($"Failed to delete stock.\nStatus Code: {response.StatusCode}\nError: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting stock: " + ex.Message);
            }
        }
    }


    public enum StockType
    {
        Internal,
        External
    }

   
    public class Stock
    {
        public int Id { get; set; }
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string StockType { get; set; } 
        public string SupplierName { get; set; }
        public DateTime? SupplierDate { get; set; }
        public string CompanyName { get; set; }
    }
}
