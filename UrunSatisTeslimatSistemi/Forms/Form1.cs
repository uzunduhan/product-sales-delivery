using AutoMapper;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using UrunSatisTeslimatSistemi.Common;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Dto.Dtos;
using UrunSatisTeslimatSistemi.Extensions;
using UrunSatisTeslimatSistemi.Service.Abstract;
using UrunSatisTeslimatSistemi.Service.Validations;

namespace UrunSatisTeslimatSistemi
{
    public partial class Form1 : Form
    {
        private readonly IProductService _productService;
        private readonly ICustomerProductService _customerProductService;
        int selectedRowId;
        bool isAnyRowSelected = false;


        public Form1()
        {
            InitializeComponent();
            _productService = ProviderExtensions.GetRequiredService<IProductService>();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            List<Product> products = await _productService.GetAllAsync();

            dataGridView1.DataSource = products;

            updateProductButton.Enabled = false;
            deleteProductButton.Enabled = false;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            isAnyRowSelected = true;

            updateProductButton.Enabled = true;
            deleteProductButton.Enabled = true;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                selectedRowId = Convert.ToInt32(row.Cells[2].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.is = false;
            var frmHubWindow = new Form2()
            {
                Owner = this
            };

            frmHubWindow.ShowDialog();
            //ShowFrmHubButton.IsEnabled = true;
        }

        private async void createProductButton_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                MessageBox.Show("price field canot be empty", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductDto product = new ProductDto()
            {
                Name = textBox1.Text,
                Price = Convert.ToDouble(textBox2.Text),
            };

            //ProductDtoValidator validator = new ProductDtoValidator();

            //ValidationResult results = validator.Validate(product);

            //IList<ValidationFailure> failures = results.Errors;

            //if (!results.IsValid)
            //{
            //    foreach (ValidationFailure failure in failures)
            //    {
            //        MessageBox.Show(failure.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}

            await _productService.InsertAsync(product);
            textBox1.Text = "";
            textBox2.Text = "";

            dataGridView1.DataSource = await _productService.GetAllAsync();

        }

        private async void updateProductButton_Click(object sender, EventArgs e)
        {
            if (isAnyRowSelected)
            {

                UpdateProductDto product = new()
                {
                    Id = selectedRowId,
                    Name = textBox1.Text,
                    Price = Convert.ToDouble(textBox2.Text),
                };

                ProductDtoValidator validator = new ProductDtoValidator();

                ValidationResult results = validator.Validate(product);

                IList<ValidationFailure> failures = results.Errors;

                if (!results.IsValid)
                {
                    foreach (ValidationFailure failure in failures)
                    {
                        MessageBox.Show(failure.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                 await _productService.UpdateProductAsync(product);

                isAnyRowSelected = false;

                textBox1.Text = "";
                textBox2.Text = "";
                updateProductButton.Enabled = false;
                deleteProductButton.Enabled = false;

                dataGridView1.DataSource = await _productService.GetAllAsync();
            }
        }

        private async void deleteProductButton_Click(object sender, EventArgs e)
        {
            if (isAnyRowSelected)
            {
                isAnyRowSelected = false;

                updateProductButton.Enabled = false;
                deleteProductButton.Enabled = false;

                await _productService.RemoveAsync(selectedRowId);
                dataGridView1.DataSource = await _productService.GetAllAsync();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
             HelperService helperService = new HelperService();
             helperService.IsTheEnteredValueNumber(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frmHubWindow = new Form3()
            {
                Owner = this
            };

            frmHubWindow.ShowDialog();

        }
    }
}