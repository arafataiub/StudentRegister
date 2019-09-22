using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxMax.Visible = false;
            textBoxMaxName.Visible = false;
            textBoxMin.Visible = false;
            textBoxMinName.Visible = false;
            textBoxAvg.Visible = false;
            textBoxTotall.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
        }

        List<string> Names = new List<string>();
        List<string> IDs = new List<string>();
        List<string> Addresses = new List<string>();
        List<string> Mobiles = new List<string>();
        List<int> Ages = new List<int>();
        List<int> GpaPoints = new List<int>();

       
        
        



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (string.IsNullOrEmpty(textBoxMobile.Text) == true)
            {
                MessageBox.Show("You Have To Provide a Valid Contact Number");
                return;
            }else if(string.IsNullOrEmpty(textBoxID.Text)==true)
            {
                MessageBox.Show("You Have To Provide a Valid ID");
                return;

            }
            else if (string.IsNullOrEmpty(textBoxName.Text) == true)
            {
                MessageBox.Show("You Have To Provide Your Name");
                return;

            }
            else if (string.IsNullOrEmpty(textBoxAge.Text) == true)
            {
                MessageBox.Show("You Have To Provide Your Age");
                return;

            }
            else if (string.IsNullOrEmpty(textBoxAddress.Text) == true)
            {
                MessageBox.Show("You Have To Provide Your Address");
                return;

            }
            else if (string.IsNullOrEmpty(textBoxGpaPoint.Text) == true)
            {
                MessageBox.Show("You Have To Provide Your Gpa Point");
                return;

            }
            else
            {
              
                if (CheckDuplicateMobile(textBoxMobile.Text) == true)
                {
                    MessageBox.Show("Contact Number Must be Unique,Please Enter Another Contact");
                    return;
                }
               
                else if (CheckDuplicateID(textBoxID.Text) == true)
                {
                    MessageBox.Show("Contact Number Must be Unique,Please Enter Another Contact");
                    return;
                }

                else if (Convert.ToInt32(textBoxGpaPoint.Text) > 4)
                {
                    MessageBox.Show("Gpa Point is not valid");
                    return;
                }

                 else if (textBoxMobile.TextLength != 11)
                {
                    MessageBox.Show("Mobile Number should be 11 character");
                    return;
                }
                else if(textBoxID.TextLength != 4)
                {
                    MessageBox.Show("ID should be 4 character long");
                    return;

                }
                else
                {
                    try
                    {
                        Convert.ToInt32(textBoxMobile.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Mobile Number is not valid");
                        error = true;
                        return;
                    }


                    try
                    {
                        Convert.ToInt32(textBoxAge.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Age is not valid");
                        error = true;
                        return;
                    }

                }


                if(error== false)
                {
                    Names.Add(textBoxName.Text);
                    Mobiles.Add(textBoxMobile.Text);
                    Addresses.Add(textBoxAddress.Text);
                    IDs.Add(textBoxID.Text);
                    Ages.Add(Convert.ToInt16(textBoxAge.Text));
                    GpaPoints.Add(Convert.ToInt32(textBoxGpaPoint.Text));

                    richTextBox1.Text = "Your Info:" + "\n" + "Name:" + textBoxName.Text + "\n" + "Contact No:"
               + textBoxMobile.Text + "\n" + "Address:" + textBoxAddress.Text + "\n" + "ID: "
               + textBoxID.Text + "\n" + "Age:" + textBoxAge.Text + "\n" + "Gpa Point: " + textBoxGpaPoint.Text ;

                    ClearAllControls();

                }


               

                

            }



                




        }

        public bool CheckDuplicateMobile(string cinput)
        {
            bool isduplicale = false;

           


            foreach (string c in Mobiles)
            {
                if (c == cinput)
                {
                    isduplicale = true;
                    break;
                }
                else
                    continue;
            }
            return isduplicale;

        }

        public bool CheckDuplicateID(string cinput)
        {
            bool isduplicale = false;


            foreach (string c in IDs)
            {
                if (c == cinput)
                {
                    isduplicale = true;
                    break;
                }
                else
                    continue;
            }
            return isduplicale;

        }

        private void ClearAllControls()
        {
            textBoxID.Text = "";
            textBoxName.Text = "";
            textBoxMobile.Text = "";
            textBoxAge.Text = "";
            textBoxAddress.Text = "";
            textBoxGpaPoint.Text = "";

        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            string message = "";
            for (int i = 0; i < Names.Count(); i++)
            {
                message += "Info for " + Names[i] + "\n" + "Contact no: " + Mobiles[i] + "\n" + " , Address: "
                    + Addresses[i] + "\n" + "ID: " + IDs[i] + "\n "+ "Age:" + Ages[i] + "\n" + "Gpa Point: " + GpaPoints[i] + "\n";
            }
            richTextBox1.Text = message;

            InitializeComponent();
            textBoxMax.Visible = true;
            textBoxMaxName.Visible = true;
            textBoxMin.Visible = true;
            textBoxMinName.Visible = true;
            textBoxAvg.Visible = true;
            textBoxTotall.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;

            int totall = 0;
            int j = 0;
            int max = GpaPoints[0];
            int maxn = 0;
            int min = GpaPoints[0];
            int minn = 0;

            foreach (int c in GpaPoints)
            {
                if(c>max)
                {
                    max = c;
                    maxn = j;
                }
                if(c<min)
                {
                    min = c;
                    minn = j;
                }
                totall = totall + c;
                j++;
                
            }
            textBoxTotall.Text = Convert.ToString(totall);
            textBoxAvg.Text = Convert.ToString(totall / j);
            textBoxMax.Text = Convert.ToString(max);
            textBoxMaxName.Text = Convert.ToString(Names[maxn]);
            textBoxMin.Text = Convert.ToString(min);
            textBoxMinName.Text = Convert.ToString(Names[minn]);







        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool found = false;
            if (radioButtonID.Checked == true || radioButtonMobile.Checked == true || radioButtonName.Checked == true)
            {
                if(radioButtonID.Checked == true)
                {
                    if(string.IsNullOrEmpty(textBoxID.Text)==true)
                    {
                        MessageBox.Show("Give a Valid ID");
                        return;

                    }
                    else
                    {
                        
                        foreach (string c in IDs)
                        {
                            if (c == textBoxID.Text)
                            {

                                string message = "";
                                
                                    message += "Info for " + Names[i] + "\n" + "Contact no: " + Mobiles[i] + "\n" + " , Address: "
                                        + Addresses[i] + "\n" + "ID: " + IDs[i] + "\n " + "Age:" + Ages[i] + "\n" + "Gpa Point: " + GpaPoints[i] + "\n";
                                
                                richTextBox1.Text = message;
                                found = true;

                                break;
                            }
                            else
                            {
                                i++;
                                continue;
                            }
                            
                                
                        }
                        if (found == false)
                        {
                            MessageBox.Show("ID Not Found!");
                            return;

                        }

                    }
                }
                else if(radioButtonName.Checked == true)
                {
                    if (string.IsNullOrEmpty(textBoxName.Text) == true)
                    {
                        MessageBox.Show("Give a Valid Name");
                        return;

                    }
                    else
                    {
                        
                        foreach (string c in Names)
                        {
                            if (c == textBoxName.Text)
                            {

                                string message = "";

                                message += "Info for " + Names[i] + "\n" + "Contact no: " + Mobiles[i] + "\n" + " , Address: "
                                    + Addresses[i] + "\n" + "ID: " + IDs[i] + "\n " + "Age:" + Ages[i] + "\n" + "Gpa Point: " + GpaPoints[i] + "\n";

                                richTextBox1.Text = message;
                                found = true;
                                break;
                            }
                            else
                            {
                                i++;
                                continue;
                            }

                        }
                        if (found == false)
                        {
                            MessageBox.Show("Name Not Found!");
                            return;

                        }

                    }

                }
                else if (radioButtonMobile.Checked == true)
                {
                    if (string.IsNullOrEmpty(textBoxMobile.Text) == true)
                    {
                        MessageBox.Show("Give a Valid Mobile no");
                        return;

                    }
                    else
                    {

                        foreach (string c in Mobiles)
                        {
                            if (c == textBoxMobile.Text)
                            {

                                string message = "";

                                message += "Info for " + Names[i] + "\n" + "Contact no: " + Mobiles[i] + "\n" + " , Address: "
                                    + Addresses[i] + "\n" + "ID: " + IDs[i] + "\n " + "Age:" + Ages[i] + "\n" + "Gpa Point: " + GpaPoints[i] + "\n";

                                richTextBox1.Text = message;
                                found = true;

                                break;
                            }
                            else
                            {
                                i++;
                                continue;
                            }

                        }
                        if (found == false)
                        {
                            MessageBox.Show("Mobile no Not Found!");
                            return;

                        }

                    }

                }

            }
            else
            {
                MessageBox.Show("Select name or Id or Mobile number for search!");
                return;

            }
                    
        }
    }
}
