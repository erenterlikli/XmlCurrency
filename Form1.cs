using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml; //Xml kütüphanesi.

namespace XMLDövizKuru
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bugun = "http://www.tcmb.gov.tr/kurlar/today.xml"; //xml olarak web sitesi
            var xmldoc = new XmlDocument(); //xml dökümanı kuruldu.
            xmldoc.Load(bugun);

            //string eskigun = "http://www.tcmb.gov.tr/kurlar/201503/03032015.xml";
            //xmldoc.Load(eskigun);

            DateTime tarih = Convert.ToDateTime(xmldoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

            string USD = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            label4.Text = string.Format("Tarih: {0} USD: {1}", tarih.ToShortDateString(), USD);

            string EUR = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            label5.Text = string.Format("Tarih: {0} EUR: {1}", tarih.ToShortDateString(), EUR);

            string GBP = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            label6.Text = string.Format("Tarih: {0} EUR:{1}", tarih.ToShortDateString(), GBP);


        }
    }
}
