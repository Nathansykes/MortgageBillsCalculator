using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using Synoptic.Properties;
using System.Diagnostics;
using System.IO;

namespace Synoptic
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓--VARIABLE DEFINITIONS--↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        #region VariableDefinitions
        const string poundname = "GB Pound - £";
        const string dollarname = "US Dollar - $";
        const string euroname = "Euro - €";
        string currentcurrency;
        bool open = false;
        double propertycost, deposit, interest, multiplier, mortgage;
        int mlength, totalmonths;
        double monthlyrepayment, annualrepayment, totalrepayment;
        double gas, electricity, water, ctax, totalweekly, totalmonthly, totalannual, totalmlength;
        double combinedweekly, combinedmonthly, combinedannual, combinedtotal;

        MetroFramework.Controls.MetroLabel[] CurrencyLBLs = new MetroFramework.Controls.MetroLabel[26];
        private void DefineCurrencyLBLArray()
        {
            CurrencyLBLs[0] = CurrencyLBL1;
            CurrencyLBLs[1] = CurrencyLBL2;
            CurrencyLBLs[2] = CurrencyLBL3;
            CurrencyLBLs[3] = CurrencyLBL4;
            CurrencyLBLs[4] = CurrencyLBL5;
            CurrencyLBLs[5] = CurrencyLBL6;
            CurrencyLBLs[6] = CurrencyLBL7;
            CurrencyLBLs[7] = CurrencyLBL8;
            CurrencyLBLs[8] = CurrencyLBL9;
            CurrencyLBLs[9] = CurrencyLBL10;
            CurrencyLBLs[10] = CurrencyLBL11;
            CurrencyLBLs[11] = CurrencyLBL12;
            CurrencyLBLs[12] = CurrencyLBL13;
            CurrencyLBLs[13] = CurrencyLBL14;
            CurrencyLBLs[14] = CurrencyLBL15;
            CurrencyLBLs[15] = CurrencyLBL16;
            CurrencyLBLs[16] = CurrencyLBL17;
            CurrencyLBLs[17] = CurrencyLBL18;
            CurrencyLBLs[18] = CurrencyLBL19;
            CurrencyLBLs[19] = CurrencyLBL20;
            CurrencyLBLs[20] = CurrencyLBL21;
            CurrencyLBLs[21] = CurrencyLBL22;
            CurrencyLBLs[22] = CurrencyLBL23;
            CurrencyLBLs[23] = CurrencyLBL24;
            CurrencyLBLs[24] = CurrencyLBL25;
            CurrencyLBLs[25] = CurrencyLBL26;

        }

        string[] TextBoxStrings = new string[9];
        private void DefineTextboxArray()
        {
            TextBoxStrings[1] = CostTextbox.Text;
            TextBoxStrings[2] = DepositTextbox.Text;
            TextBoxStrings[3] = MortgageLengthTextbox.Text;
            TextBoxStrings[4] = InterestTextbox.Text;
            TextBoxStrings[5] = GasTextbox.Text;
            TextBoxStrings[6] = WaterTextbox.Text;
            TextBoxStrings[7] = ElectricityTextbox.Text;
            TextBoxStrings[8] = CTaxTextbox.Text;
        }

        MetroFramework.Controls.MetroTextBox[] MoneyTextbox = new MetroFramework.Controls.MetroTextBox[6];
        private void DefineMoneyTextboxArray()
        {
            MoneyTextbox[0] = CostTextbox;
            MoneyTextbox[1] = DepositTextbox;
            MoneyTextbox[2] = GasTextbox;
            MoneyTextbox[3] = WaterTextbox;
            MoneyTextbox[4] = ElectricityTextbox;
            MoneyTextbox[5] = CTaxTextbox;

        }

        MetroFramework.Controls.MetroLabel[] MoneyLabels = new MetroFramework.Controls.MetroLabel[20];
        private void DefineMoneyLabelsArray()
        {
            MoneyLabels[0] = MortgageAmountANSLBL;
            MoneyLabels[1] = MonthlyRepaymentANSLBL;
            MoneyLabels[2] = AnnualRepaymentANSLBL;
            MoneyLabels[3] = TotalRepaymentANSLBL;
            MoneyLabels[4] = BillsWeeklyANSLBL;
            MoneyLabels[5] = BillsMonthlyANSLBL;
            MoneyLabels[6] = BillsAnnualANSLBL;
            MoneyLabels[7] = TotalMLengthANSLBL;
            MoneyLabels[8] = WeeklyTotalSumANSLBL;
            MoneyLabels[9] = MonthlyTotalSumANSLBL;
            MoneyLabels[10] = AnnualTotalSumANSLBL;
            MoneyLabels[11] = TotalMLengthSumANSLBL;
            MoneyLabels[12] = MortgageAmountSumANSLBL;
            MoneyLabels[13] = MonthlyRepaymentSumANSLBL;
            MoneyLabels[14] = AnnualRepaymentSumANSLBL;
            MoneyLabels[15] = TotalRepaymentSumANSLBL;
            MoneyLabels[16] = CombinedWeeklyANSLBL;
            MoneyLabels[17] = CombinedMonthlyANSLBL;
            MoneyLabels[18] = CombinedAnnualANSLBL;
            MoneyLabels[19] = CombinedTotalANSLBL;
        }

        private void WeeklyBillsTab_Click(object sender, EventArgs e)
        {

        }

        private void SettingsTab_Click(object sender, EventArgs e)
        {

        }


        #endregion
        //↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑--VARIABLE DEFINITIONS--↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

        #region Help
        private void HelpButton_Click(object sender, EventArgs e)
        {
            //Process.Start("Help Guide.pdf");
			Process.Start("https://1drv.ms/b/s!AibZr8VIsI4jhRgagHspcfWpvrh_");
        }
        #endregion

        //r↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓--FORM LOAD--↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        #region Form
        private void Form1_Load(object sender, EventArgs e)
        {
            DefineMoneyTextboxArray();
            DefineMoneyLabelsArray();
            DefineCurrencyLBLArray();
            DefineTextboxArray();
            CurrencyCMB.SelectedItem = Settings.Default.Currency;
            TabControl.SelectedTab = MortgageTab;
            //---currency---
            switch (Settings.Default.Currency)
            {
                case poundname:
                    currentcurrency = "pound";
                    foreach (MetroFramework.Controls.MetroLabel l in CurrencyLBLs)
                    {
                        l.Text = "£";
                    }
                    break;

                case dollarname:
                    currentcurrency = "dollar";
                    foreach (MetroFramework.Controls.MetroLabel l in CurrencyLBLs)
                    {
                        l.Text = "$";
                    }
                    break;

                case euroname:
                    currentcurrency = "euro";
                    foreach (MetroFramework.Controls.MetroLabel l in CurrencyLBLs)
                    {
                        l.Text = "€";
                    }
                    break;
            }
            //---dark mode---
            switch (Settings.Default.DarkMode)
            {
                case true:
                    DarkModeToggle.Checked = true;
                    Theme = MetroThemeStyle.Dark;
                    MainFormStyleManager.Theme = MetroThemeStyle.Dark;
                    break;
                case false:
                    DarkModeToggle.Checked = false;
                    Theme = MetroThemeStyle.Light;
                    MainFormStyleManager.Theme = MetroThemeStyle.Light;
                    break;
            }
            //---style---
            switch (Settings.Default.Style)
            {
                case "Black":
                    Style = MetroColorStyle.Black;
                    MainFormStyleManager.Style = MetroColorStyle.Black;
                    Stylecmb.SelectedItem = "Black";
                    break;
                case "White":
                    Style = MetroColorStyle.White;
                    MainFormStyleManager.Style = MetroColorStyle.White;
                    Stylecmb.SelectedItem = "White";
                    break;
                case "Silver":
                    Style = MetroColorStyle.Silver;
                    MainFormStyleManager.Style = MetroColorStyle.Silver;
                    Stylecmb.SelectedItem = "Silver";
                    break;
                case "Blue":
                    Style = MetroColorStyle.Blue;
                    MainFormStyleManager.Style = MetroColorStyle.Blue;
                    Stylecmb.SelectedItem = "Blue";
                    break;
                case "Green":
                    Style = MetroColorStyle.Green;
                    MainFormStyleManager.Style = MetroColorStyle.Green;
                    Stylecmb.SelectedItem = "Green";
                    break;
                case "Lime":
                    Style = MetroColorStyle.Lime;
                    MainFormStyleManager.Style = MetroColorStyle.Lime;
                    Stylecmb.SelectedItem = "Lime";
                    break;
                case "Teal":
                    Style = MetroColorStyle.Teal;
                    MainFormStyleManager.Style = MetroColorStyle.Teal;
                    Stylecmb.SelectedItem = "Teal";
                    break;
                case "Orange":
                    Style = MetroColorStyle.Orange;
                    MainFormStyleManager.Style = MetroColorStyle.Orange;
                    Stylecmb.SelectedItem = "Orange";
                    break;
                case "Brown":
                    Style = MetroColorStyle.Brown;
                    MainFormStyleManager.Style = MetroColorStyle.Brown;
                    Stylecmb.SelectedItem = "Brown";
                    break;
                case "Pink":
                    Style = MetroColorStyle.Pink;
                    MainFormStyleManager.Style = MetroColorStyle.Pink;
                    Stylecmb.SelectedItem = "Pink";
                    break;
                case "Magenta":
                    Style = MetroColorStyle.Magenta;
                    MainFormStyleManager.Style = MetroColorStyle.Magenta;
                    Stylecmb.SelectedItem = "Magenta";
                    break;
                case "Purple":
                    Style = MetroColorStyle.Purple;
                    MainFormStyleManager.Style = MetroColorStyle.Purple;
                    Stylecmb.SelectedItem = "Purple";
                    break;
                case "Red":
                    Style = MetroColorStyle.Red;
                    MainFormStyleManager.Style = MetroColorStyle.Red;
                    Stylecmb.SelectedItem = "Red";
                    break;
                case "Yellow":
                    Style = MetroColorStyle.Yellow;
                    MainFormStyleManager.Style = MetroColorStyle.Yellow;
                    Stylecmb.SelectedItem = "Yellow";
                    break;
            }
            open = true;
        }
#endregion
        //r↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑--FORM LOAD--↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
        
        //y↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓--MORTGAGE--↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        #region Mortgage
        private void CalculateTile_Click(object sender, EventArgs e)
        {
            Mortgage();
        }
        int MortgageErrors = 0;
        private void Mortgage()
        {
            // multiplier = interest / 100 + 1
            //                                                              totalmonths)
            //                                    (multiplier-1)*(multiplier           )
            // monthlyrepayment = propertycost * ---------------------------------------
            //                                               totalmonths)
            //                                   (multiplier            ) -1
            //
            try
            {
                propertycost = Convert.ToDouble(CostTextbox.Text);
                deposit = Convert.ToDouble(DepositTextbox.Text);
                interest = Convert.ToDouble(InterestTextbox.Text);
                mlength = Convert.ToInt32(MortgageLengthTextbox.Text);

                totalmonths = mlength * 12;

                multiplier = ((interest / 12) / 100) + 1;

                mortgage = propertycost - deposit;

                monthlyrepayment = mortgage * ((multiplier - 1) * (Math.Pow(multiplier, totalmonths)) / (Math.Pow(multiplier, totalmonths) - 1));

                monthlyrepayment = Math.Round(monthlyrepayment, 2);
                annualrepayment = monthlyrepayment * 12;
                totalrepayment = annualrepayment * mlength;

                MortgageAmountANSLBL.Text = mortgage.ToString();
                MonthlyRepaymentANSLBL.Text = monthlyrepayment.ToString();
                AnnualRepaymentANSLBL.Text = annualrepayment.ToString();
                TotalRepaymentANSLBL.Text = totalrepayment.ToString();
                //---SUMMARY---
                MortgageAmountSumANSLBL.Text = mortgage.ToString();
                MonthlyRepaymentSumANSLBL.Text = monthlyrepayment.ToString();
                AnnualRepaymentSumANSLBL.Text = annualrepayment.ToString();
                TotalRepaymentSumANSLBL.Text = totalrepayment.ToString();
            }
            catch (Exception)
            {
                if (MortgageErrors < 4)
                {
                    MetroMessageBox.Show(this, "Something went wrong, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                
                if (MortgageErrors > 5)
                {
                    DialogResult OpenHelpGuide = MetroMessageBox.Show(this, "Something went wrong, please try again." +
                        "\nYou seem to be having trouble, maybe consult the help guide to find out what you're doing wrong." +
                        "\nWould you like to open the Help Guide?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if(OpenHelpGuide == DialogResult.Yes)
                    {
                        HelpButton.PerformClick();
                    }
                }
                MortgageErrors++;
            }            
        }
        #endregion
        //y↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑--MORTGAGE--↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
        
        //b↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓--WEEKLY BILLS--↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        #region WeeklyBills
        private void CalculateBillsTile_Click(object sender, EventArgs e)
        {
            WeeklyBills();
        }

        private void WeeklyBills()
        {
            try
            {
                gas = Convert.ToDouble(GasTextbox.Text);
                electricity = Convert.ToDouble(ElectricityTextbox.Text);
                water = Convert.ToDouble(WaterTextbox.Text);
                ctax = Convert.ToDouble(CTaxTextbox.Text);
                if (MortgageLengthTextbox.Text == "")
                {
                    mlength = 0;
                }
                else
                {
                    mlength = Convert.ToInt32(MortgageLengthTextbox.Text);
                }
                totalweekly = (gas + electricity + water + ctax);
                totalmonthly = totalweekly * 4;
                totalannual = totalmonthly * 12;
                totalmlength = totalannual * mlength;

                BillsWeeklyANSLBL.Text = totalweekly.ToString();
                BillsMonthlyANSLBL.Text = totalmonthly.ToString();
                BillsAnnualANSLBL.Text = totalannual.ToString();
                TotalMLengthANSLBL.Text = totalmlength.ToString();
                //---SUM---
                WeeklyTotalSumANSLBL.Text = totalweekly.ToString();
                MonthlyTotalSumANSLBL.Text = totalmonthly.ToString();
                AnnualTotalSumANSLBL.Text = totalannual.ToString();
                TotalMLengthSumANSLBL.Text = totalmlength.ToString();
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Something went wrong, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        #endregion
        //b↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑--WEEKLY BILLS--↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓--SUMMARY--↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        #region Summary
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefineTextboxArray();
            if (TabControl.SelectedTab == SummaryTab)
            {
                for (int i = 0; i < TextBoxStrings.Length; i++)
                {
                    if (TextBoxStrings[i] == "")
                    {
                        MetroMessageBox.Show(this, "Not all data is present to produce summary.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    CalculateSummary();
                }
            }
            switch (TabControl.SelectedIndex)
            {
                case 0:
                    AcceptButton = CalculateTile;
                    break;
                case 1:
                    AcceptButton = CalculateBillsTile;
                    break;
                case 2:
                    AcceptButton = RefreshTile;
                    break;
                case 3:
                    AcceptButton = CalculateTile;
                    break;
            }
        }
        private void RefreshTile_Click(object sender, EventArgs e)
        {
            CalculateSummary();
        }
        private void CalculateSummary()
        {
            combinedmonthly = Math.Round(monthlyrepayment + totalmonthly, 2);
            combinedannual = Math.Round(combinedmonthly * 12, 2);
            combinedweekly = Math.Round(combinedannual / 52, 2);
            combinedtotal = Math.Round(combinedmonthly * totalmonths, 2);

            CombinedWeeklyANSLBL.Text = combinedweekly.ToString();
            CombinedMonthlyANSLBL.Text = combinedmonthly.ToString();
            CombinedAnnualANSLBL.Text = combinedannual.ToString();
            CombinedTotalANSLBL.Text = combinedtotal.ToString();
        }
        #endregion
        //↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑--SUMMARY--↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

        //r↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓--STYLING--↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        #region Styling
        private void Stylecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Stylecmb.SelectedItem)
            {
                case "Black":
                    Style = MetroColorStyle.Black;
                    MainFormStyleManager.Style = MetroColorStyle.Black;
                    Settings.Default.Style = "Black";
                    break;
                case "White":
                    Style = MetroColorStyle.White;
                    MainFormStyleManager.Style = MetroColorStyle.White;
                    Settings.Default.Style = "White";
                    break;
                case "Silver":
                    Style = MetroColorStyle.Silver;
                    MainFormStyleManager.Style = MetroColorStyle.Silver;
                    Settings.Default.Style = "Silver";
                    break;
                case "Blue":
                    Style = MetroColorStyle.Blue;
                    MainFormStyleManager.Style = MetroColorStyle.Blue;
                    Settings.Default.Style = "Blue";
                    break;
                case "Green":
                    Style = MetroColorStyle.Green;
                    MainFormStyleManager.Style = MetroColorStyle.Green;
                    Settings.Default.Style = "Green";
                    break;
                case "Lime":
                    Style = MetroColorStyle.Lime;
                    MainFormStyleManager.Style = MetroColorStyle.Lime;
                    Settings.Default.Style = "Lime";
                    break;
                case "Teal":
                    Style = MetroColorStyle.Teal;
                    MainFormStyleManager.Style = MetroColorStyle.Teal;
                    Settings.Default.Style = "Teal";
                    break;
                case "Orange":
                    Style = MetroColorStyle.Orange;
                    MainFormStyleManager.Style = MetroColorStyle.Orange;
                    Settings.Default.Style = "Orange";
                    break;
                case "Brown":
                    Style = MetroColorStyle.Brown;
                    MainFormStyleManager.Style = MetroColorStyle.Brown;
                    Settings.Default.Style = "Brown";
                    break;
                case "Pink":
                    Style = MetroColorStyle.Pink;
                    MainFormStyleManager.Style = MetroColorStyle.Pink;
                    Settings.Default.Style = "Pink";
                    break;
                case "Magenta":
                    Style = MetroColorStyle.Magenta;
                    MainFormStyleManager.Style = MetroColorStyle.Magenta;
                    Settings.Default.Style = "Magenta";
                    break;
                case "Purple":
                    Style = MetroColorStyle.Purple;
                    MainFormStyleManager.Style = MetroColorStyle.Purple;
                    Settings.Default.Style = "Purple";
                    break;
                case "Red":
                    Style = MetroColorStyle.Red;
                    MainFormStyleManager.Style = MetroColorStyle.Red;
                    Settings.Default.Style = "Red";
                    break;
                case "Yellow":
                    Style = MetroColorStyle.Yellow;
                    MainFormStyleManager.Style = MetroColorStyle.Yellow;
                    Settings.Default.Style = "Yellow";
                    break;
            }
            Settings.Default.Save();
        }

        private void DarkModeToggle_CheckedChanged(object sender, EventArgs e)
        {
            switch (DarkModeToggle.CheckState)
            {
                case CheckState.Checked:
                    Theme = MetroThemeStyle.Dark;
                    MainFormStyleManager.Theme = MetroThemeStyle.Dark;
                    Settings.Default.DarkMode = true;
                    break;
                case CheckState.Unchecked:
                    Theme = MetroThemeStyle.Light;
                    MainFormStyleManager.Theme = MetroThemeStyle.Light;
                    Settings.Default.DarkMode = false;
                    break;
            }
            Settings.Default.Save();
        }
        #endregion
        //r↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑--STYLING--↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

        //y↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓--CURRENCY CONVERSION--↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        #region CurrencyConversion
        private void CurrencyCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CurrencyCMB.SelectedItem)
            {
                case poundname:
                    foreach (MetroFramework.Controls.MetroLabel l in CurrencyLBLs)
                    {
                        l.Text = "£";
                    }
                    Settings.Default.Currency = poundname;
                    if (open)
                    {
                        DialogResult dialogResultPound = MetroMessageBox.Show(this, "", "Convert Current Values", MessageBoxButtons.YesNo);
                        if (dialogResultPound == DialogResult.Yes)
                        {
                            ConvToPound();
                        }
                    }
                    break;

                case dollarname:
                    foreach (MetroFramework.Controls.MetroLabel l in CurrencyLBLs)
                    {
                        l.Text = "$";
                    }
                    Settings.Default.Currency = dollarname;
                    if (open)
                    {

                        DialogResult dialogResultDollar = MetroMessageBox.Show(this, "", "Convert Current Values", MessageBoxButtons.YesNo);
                        if (dialogResultDollar == DialogResult.Yes)
                        {
                            ConvToDollar();
                        }
                    }
                    break;

                case euroname:
                    foreach (MetroFramework.Controls.MetroLabel l in CurrencyLBLs)
                    {
                        l.Text = "€";
                    }
                    Settings.Default.Currency = euroname;
                    if (open)
                    {
                        DialogResult dialogResultEuro = MetroMessageBox.Show(this, "", "ConvertCurrentValues", MessageBoxButtons.YesNo);
                        if (dialogResultEuro == DialogResult.Yes)
                        {
                            ConvToEuro();
                        }
                    }
                    break;
            }
            Settings.Default.Save();
        }

        private void ConvToPound()
        {
            if (currentcurrency == "pound")
            {                
                for (int i = 0; i < MoneyTextbox.Length; i++)//pound-pound
                {
                    if (MoneyTextbox[i].Text != "")
                    {
                        MoneyTextbox[i].Text = Math.Round(((Convert.ToDouble(MoneyTextbox[i].Text)) * 1), 2).ToString();
                    }
                }
                for (int i = 0; i < MoneyLabels.Length; i++)
                {
                    MoneyLabels[i].Text = Math.Round(((Convert.ToDouble(MoneyLabels[i].Text)) * 1), 2).ToString();
                }
                propertycost = Math.Round(propertycost * 1,2);
                deposit = Math.Round(deposit * 1,2);
                mortgage = Math.Round(mortgage * 1,2);
                monthlyrepayment  = Math.Round(monthlyrepayment * 1,2);
                annualrepayment = Math.Round(annualrepayment * 1,2);
                totalrepayment = Math.Round(totalrepayment * 1,2);
            }
            else if (currentcurrency == "dollar")//dollar-pound
            {
                for (int i = 0; i < MoneyTextbox.Length; i++)
                {
                    if (MoneyTextbox[i].Text != "")
                    {
                        MoneyTextbox[i].Text = Math.Round(((Convert.ToDouble(MoneyTextbox[i].Text)) / 1.29), 2).ToString();
                    }
                }
                for (int i = 0; i < MoneyLabels.Length; i++)
                {
                    MoneyLabels[i].Text = Math.Round(((Convert.ToDouble(MoneyLabels[i].Text)) / 1.29), 2).ToString();
                }
                propertycost = Math.Round(propertycost / 1.29, 2);
                deposit = Math.Round(deposit / 1.29, 2);
                mortgage = Math.Round(mortgage / 1.29, 2);
                monthlyrepayment = Math.Round(monthlyrepayment / 1.29, 2);
                annualrepayment = Math.Round(annualrepayment / 1.29, 2);
                totalrepayment = Math.Round(totalrepayment / 1.29, 2);
            }
            else if (currentcurrency == "euro")//euro-pound
            {
                for (int i = 0; i < MoneyTextbox.Length; i++)
                {
                    if (MoneyTextbox[i].Text != "")
                    {
                        MoneyTextbox[i].Text = Math.Round(((Convert.ToDouble(MoneyTextbox[i].Text)) / 1.14), 2).ToString();
                    }
                }
                for (int i = 0; i < MoneyLabels.Length; i++)
                {
                    MoneyLabels[i].Text = Math.Round(((Convert.ToDouble(MoneyLabels[i].Text)) / 1.14), 2).ToString();
                }
                propertycost = Math.Round(propertycost / 1.14, 2);
                deposit = Math.Round(deposit / 1.14, 2);
                mortgage = Math.Round(mortgage / 1.14, 2);
                monthlyrepayment = Math.Round(monthlyrepayment / 1.14, 2);
                annualrepayment = Math.Round(annualrepayment / 1.14, 2);
                totalrepayment = Math.Round(totalrepayment / 1.14, 2);
            }
            currentcurrency = "pound";            
        }

        private void ConvToDollar()
        {
            if (currentcurrency == "pound")//pound-dollar
            {
                for (int i = 0; i < MoneyTextbox.Length; i++)
                {
                    if (MoneyTextbox[i].Text != "")
                    {
                        MoneyTextbox[i].Text = Math.Round(((Convert.ToDouble(MoneyTextbox[i].Text)) * 1.29), 2).ToString();
                    }
                }
                for (int i = 0; i < MoneyLabels.Length; i++)
                {
                    MoneyLabels[i].Text = Math.Round(((Convert.ToDouble(MoneyLabels[i].Text)) * 1.29), 2).ToString();
                }
                propertycost = Math.Round(propertycost * 1.29, 2);
                deposit = Math.Round(deposit * 1.29, 2);
                mortgage = Math.Round(mortgage * 1.29, 2);
                monthlyrepayment = Math.Round(monthlyrepayment * 1.29, 2);
                annualrepayment = Math.Round(annualrepayment * 1.29, 2);
                totalrepayment = Math.Round(totalrepayment * 1.29, 2);
            }
            else if (currentcurrency == "dollar")//dollar-dollar
            {
                for (int i = 0; i < MoneyTextbox.Length; i++)
                {
                    if (MoneyTextbox[i].Text != "")
                    {
                        MoneyTextbox[i].Text = Math.Round(((Convert.ToDouble(MoneyTextbox[i].Text)) * 1), 2).ToString();
                    }
                }
                for (int i = 0; i < MoneyLabels.Length; i++)
                {
                    MoneyLabels[i].Text = Math.Round(((Convert.ToDouble(MoneyLabels[i].Text)) * 1), 2).ToString();
                }
                propertycost = Math.Round(propertycost * 1, 2);
                deposit = Math.Round(deposit * 1, 2);
                mortgage = Math.Round(mortgage * 1, 2);
                monthlyrepayment = Math.Round(monthlyrepayment * 1, 2);
                annualrepayment = Math.Round(annualrepayment * 1, 2);
                totalrepayment = Math.Round(totalrepayment * 1, 2);
            }
            else if (currentcurrency == "euro")//euro-dollar
            {
                for (int i = 0; i < MoneyTextbox.Length; i++)
                {
                    if (MoneyTextbox[i].Text != "")
                    {
                        MoneyTextbox[i].Text = Math.Round(((Convert.ToDouble(MoneyTextbox[i].Text)) / 1.13), 2).ToString();
                    }
                }
                for (int i = 0; i < MoneyLabels.Length; i++)
                {
                    MoneyLabels[i].Text = Math.Round(((Convert.ToDouble(MoneyLabels[i].Text)) / 1.13), 2).ToString();
                }
                propertycost = Math.Round(propertycost / 1.13, 2);
                deposit = Math.Round(deposit / 1.13, 2);
                mortgage = Math.Round(mortgage / 1.13, 2);
                monthlyrepayment = Math.Round(monthlyrepayment / 1.13, 2);
                annualrepayment = Math.Round(annualrepayment / 1.13, 2);
                totalrepayment = Math.Round(totalrepayment / 1.13, 2);
            }
            currentcurrency = "dollar";            
        }

        private void ConvToEuro()
        {
            if (currentcurrency == "pound")//pound-euro
            {
                for (int i = 0; i < MoneyTextbox.Length; i++)
                {
                    if (MoneyTextbox[i].Text != "")
                    {
                        MoneyTextbox[i].Text = Math.Round(((Convert.ToDouble(MoneyTextbox[i].Text)) * 1.14), 2).ToString();
                    }
                }
                for (int i = 0; i < MoneyLabels.Length; i++)
                {
                    MoneyLabels[i].Text = Math.Round(((Convert.ToDouble(MoneyLabels[i].Text)) * 1.14), 2).ToString();
                }
                propertycost = Math.Round(propertycost * 1.14, 2);
                deposit = Math.Round(deposit * 1.14, 2);
                mortgage = Math.Round(mortgage * 1.14, 2);
                monthlyrepayment = Math.Round(monthlyrepayment * 1.14, 2);
                annualrepayment = Math.Round(annualrepayment * 1.14, 2);
                totalrepayment = Math.Round(totalrepayment * 1.14, 2);
            }
            else if (currentcurrency == "dollar")//dollar-euro
            {
                for (int i = 0; i < MoneyTextbox.Length; i++)
                {
                    if (MoneyTextbox[i].Text != "")
                    {
                        MoneyTextbox[i].Text = Math.Round(((Convert.ToDouble(MoneyTextbox[i].Text)) / 1.13), 2).ToString();
                    }
                }
                for (int i = 0; i < MoneyLabels.Length; i++)
                {
                    MoneyLabels[i].Text = Math.Round(((Convert.ToDouble(MoneyLabels[i].Text)) / 1.13), 2).ToString();
                }
                propertycost = Math.Round(propertycost / 1.13, 2);
                deposit = Math.Round(deposit / 1.13, 2);
                mortgage = Math.Round(mortgage / 1.13, 2);
                monthlyrepayment = Math.Round(monthlyrepayment / 1.13, 2);
                annualrepayment = Math.Round(annualrepayment / 1.13, 2);
                totalrepayment = Math.Round(totalrepayment / 1.13, 2);
            }
            else if (currentcurrency == "euro")//euro-euro
            {
                for (int i = 0; i < MoneyTextbox.Length; i++)
                {
                    if (MoneyTextbox[i].Text != "")
                    {
                        MoneyTextbox[i].Text = Math.Round(((Convert.ToDouble(MoneyTextbox[i].Text)) * 1), 2).ToString();
                    }
                }
                for (int i = 0; i < MoneyLabels.Length; i++)
                {
                    MoneyLabels[i].Text = Math.Round(((Convert.ToDouble(MoneyLabels[i].Text)) * 1), 2).ToString();
                }
                propertycost = Math.Round(propertycost * 1, 2);
                deposit = Math.Round(deposit * 1, 2);
                mortgage = Math.Round(mortgage * 1, 2);
                monthlyrepayment = Math.Round(monthlyrepayment * 1, 2);
                annualrepayment = Math.Round(annualrepayment * 1, 2);
                totalrepayment = Math.Round(totalrepayment * 1, 2);
            }
            currentcurrency = "euro";
        }
        #endregion 
        //y↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑--CURRENCY CONVERSION--↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
    }
}
