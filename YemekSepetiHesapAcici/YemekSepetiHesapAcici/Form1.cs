using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Threading.Tasks;

namespace YemekSepetiHesapAcici
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void driveracici()
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            for (int k = 0;k < Convert.ToInt16(comboBox1.Text) ;k++ )
            {              
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;
                var options = new ChromeOptions();
                                    
                options.AddArgument("--window-position=-32000,-32000");
                options.AddArgument("--window-size=1920,1080");
                options.AddUserProfilePreference("profile.managed_default_content_settings.images", 2);
                var driver = new ChromeDriver(service, options);
         
                driver.Navigate().GoToUrl("https://www.yemeksepeti.com/sakarya-uye-ol");
                try
                {
                    IWebElement email = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[1]/form/div[1]/div/input"));
                    email.SendKeys(textBox1.Text + k.ToString() + "@gmail.com");
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[1]/form/div[2]/div/input")).SendKeys("102030Eb.");
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[1]/form/div[3]/div/input")).SendKeys("102030Eb.");
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[1]/form/div[4]/div/input")).SendKeys("Eren");
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[1]/form/div[5]/div/input")).SendKeys("Bicakci");
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("window.scrollBy(0,350)", "");
                    driver.FindElement(By.ClassName("select2-selection__placeholder")).Click();
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/span/span/span[1]/input")).SendKeys("Arifiye");
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/span/span/span[2]/ul/li")).Click();
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[1]/form/div[8]/div[1]/div[2]/input[1]")).Click();
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[1]/form/div[8]/div[3]/div/button")).Click();
                    Thread.Sleep(1000);
                    richTextBox1.Text += textBox1.Text + k.ToString() + "@gmail.com" + ":" + "102030Eb." + "\n";
                    label2.Text = "HESAP AÇMA İŞLEMİ BAŞARILI";
                    label2.ForeColor = System.Drawing.Color.Green;
                }
                catch
                {
                    label2.Text = "İNSAN DOĞRULAMAYA DÜŞTÜ !";
                    label2.ForeColor = System.Drawing.Color.Red;

                    Thread.Sleep(10000);
                    k--;
                 
                    
                }
                driver.Quit();
                
               
            }
            button1.Enabled = true;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 1001; i++)
            {
                comboBox1.Items.Add(i);
            }
               
        }
    }
}
