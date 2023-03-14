using AutoMapper;
using UrunSatisTeslimatSistemi.Common;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Dto.Dtos;
using UrunSatisTeslimatSistemi.Extensions;
using UrunSatisTeslimatSistemi.Service.Abstract;

namespace UrunSatisTeslimatSistemi
{
    public partial class Form2 : Form
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IMapper mapper;
        private readonly ICustomerProductService _customerProductService;

        //CustomerDto customer;

        int customerId;
        int productId;

        double toplamSatilanUrunSayisi = 0;
        double toplamKazanc = 0;
        

        public Form2() 
        {
            InitializeComponent();
            _productService = ProviderExtensions.GetRequiredService<IProductService>();
            _customerService = ProviderExtensions.GetRequiredService<ICustomerService>();
            _customerProductService = ProviderExtensions.GetRequiredService<ICustomerProductService>();
            mapper = ProviderExtensions.GetRequiredService<IMapper>();
          
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            List<CustomerDto> customers = await _customerService.GetAllCustomerWithProducts();

            List<Product> products = await _productService.GetAllAsync();

            //calculate total sold products count and total earnings
            for(int i = 0; i < customers.Count ; i++)
            {
                var cus = customers[i].Customer_Products.Select(x => x.Product).ToList();
      
                toplamSatilanUrunSayisi += cus.Count;

                for(int j = 0; j < cus.Count ; j++)
                {
                    toplamKazanc += cus[j].Price;
                }
              
            }

            label5.Text = toplamSatilanUrunSayisi.ToString();
            label7.Text = toplamKazanc.ToString();

            //this section uses, when you equal combobox datasource to your items, if you dont want to handle selected index changed action.
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;

            comboBox1.DataSource = customers;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            //this section uses, when you equal combobox datasource to your items, if you dont want to handle selected index changed action.
            comboBox2.SelectedIndexChanged-= comboBox2_SelectedIndexChanged;

            comboBox2.DataSource = products;
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "Name";

            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;



        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selectedCustomerIdText = comboBox1.SelectedValue;

            var selectedCustomeId = Convert.ToInt32(selectedCustomerIdText);
            customerId = selectedCustomeId;

            var selectedCustomer = await _customerService.GetByIdAsync(selectedCustomeId);


            textBox2.Text= selectedCustomer.Email;

            dataGridView1.DataSource = selectedCustomer.Customer_Products.Select(x => x.Product).ToList();


        
            var deliveryList = selectedCustomer.Deliveries.ToList();

            comboBox3.DataSource= deliveryList;
            comboBox3.ValueMember= "Id";
            comboBox3.DisplayMember = "Adress";

   
          
    
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
                return;

            var product = await _productService.GetByIdAsync(Convert.ToInt32(comboBox2.SelectedValue));
            productId = product.Id;

            if (product is null)
                return;


            if (textBox1.Text == "")
                return;

            label2.Text = (product.Price * Convert.ToInt32(textBox1.Text)).ToString();

        }

        private async void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelperService helperService = new HelperService();
            helperService.IsTheEnteredValueNumber(sender, e);
        }

        private async void addProductButton_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {

                var CustomerProduct = new CustomerProduct
                {
                    CustomerId = customerId,
                    ProductId = productId
                };

                await _customerProductService.InsertAsync(CustomerProduct);
            }

            var customer = await _customerService.GetByIdAsync(customerId);

            dataGridView1.DataSource = customer.Customer_Products.Select(x => x.Product).ToList();


        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            productId = Convert.ToInt32(comboBox2.SelectedValue);
        }
    }
}
