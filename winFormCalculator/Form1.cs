using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winFormCalculator
{
    public partial class Form1 : Form
    {
        private bool opFlag = false;
        private bool memFlag = false;

        private double memory;

        public Form1()
        {
            InitializeComponent();

            btnMC.Enabled = false;
            btnMR.Enabled = false;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if(txtExp.Text == "0" || opFlag == true || memFlag == true)
            {
                txtExp.Text = btn.Text;
                opFlag = false;
                memFlag = false;
            }
            else
            {
                txtExp.Text = txtExp.Text + btn.Text;
            }

            try
            {
                txtResult.Text = MathEvaluator.Result(txtExp.Text);
                double v = double.Parse(txtResult.Text);
                txtResult.Text = v.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            double v = Double.Parse(txtExp.Text);
            txtExp.Text = (-v).ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtExp.Text = txtExp.Text + "+";
            opFlag = false;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            txtExp.Text = txtExp.Text + "-";
            opFlag = false;
        }

        private void btnMultiple_Click(object sender, EventArgs e)
        {
            txtExp.Text = txtExp.Text + "*";
            opFlag = false;
        }

 
        private void btnDivide_Click(object sender, EventArgs e)
        {
            txtExp.Text = txtExp.Text + "/";
            opFlag = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {

            txtResult.Text = MathEvaluator.Result(txtExp.Text);

            txtExp.Text = txtResult.Text;
        }

        
        private void btnCE_Click(object sender, EventArgs e) 
        {
            txtResult.Text = "";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            txtExp.Text = "";
            opFlag = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1);
            if(txtResult.Text.Length == 0)
            {
                txtResult.Text = "0";
            }
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            memory = Double.Parse(txtResult.Text);
            btnMC.Enabled = true;
            btnMR.Enabled = true;
            memFlag = true;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            txtResult.Text = memory.ToString();
            memFlag = true;
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            txtExp.Text = "0";
            memory = 0;
            btnMR.Enabled = false;
            btnMC.Enabled = false;
        }



        private void openBracket_Click(object sender, EventArgs e)
        {
            txtExp.Text = txtExp.Text + "(";
            opFlag = false;
        }

        private void closeBracket_Click(object sender, EventArgs e)
        {
            txtExp.Text = txtExp.Text + ")";
            opFlag = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
