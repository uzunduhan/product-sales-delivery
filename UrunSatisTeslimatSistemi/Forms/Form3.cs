using AutoMapper;
using UrunSatisTeslimatSistemi.Data.Models;
using UrunSatisTeslimatSistemi.Dto.Dtos;
using UrunSatisTeslimatSistemi.Extensions;
using UrunSatisTeslimatSistemi.Service.Abstract;

namespace UrunSatisTeslimatSistemi
{
    public partial class Form3 : Form
    {
        private readonly ICustomerService _customerService;
        private readonly IDeliveryService _deliveryService;
        private readonly IMapper _mapper;
        CustomerDto customerDto;
        int selectedRowId;

        public Form3()
        {
            InitializeComponent();
            _customerService = ProviderExtensions.GetRequiredService<ICustomerService>();
            _deliveryService = ProviderExtensions.GetRequiredService<IDeliveryService>();
            _mapper = ProviderExtensions.GetRequiredService<IMapper>();
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            var customers = await _customerService.GetAllCustomerWithProducts();

            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;

            comboBox1.DataSource = customers;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Email";

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var customer = await _customerService.GetByIdAsync(Convert.ToInt32(comboBox1.SelectedValue));
            customerDto = _mapper.Map<CustomerDto>(customer);

            dataGridView1.DataSource = customer.Deliveries.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery()
            {
                Adress = textBox1.Text.ToString()
            };

            customerDto.Deliveries.Add(delivery);

            _customerService.UpdateAsync(customerDto.Id, customerDto);


            dataGridView1.DataSource = customerDto.Deliveries.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                selectedRowId = Convert.ToInt32(row.Cells[3].Value);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var delivery = customerDto.Deliveries.Where(x => x.Id == selectedRowId).SingleOrDefault();

            delivery.Adress = textBox1.Text.ToString();

            await _customerService.UpdateAsync(customerDto.Id, customerDto);
            dataGridView1.DataSource = customerDto.Deliveries.ToList();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var delivery = customerDto.Deliveries.Where(x => x.Id == selectedRowId).SingleOrDefault();
            customerDto.Deliveries.Remove(delivery);

            await _customerService.UpdateAsync(customerDto.Id, customerDto);
            dataGridView1.DataSource = customerDto.Deliveries.ToList();
        }
    }
}
