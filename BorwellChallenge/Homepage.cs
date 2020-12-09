using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwellChallenge
{
    public partial class frmPaintCalculator : Form
    {
        // Globally declares an array for dimensions and a new instance of the Room class
        public decimal[] Dimensions;
        public Room Room = new Room();

        public frmPaintCalculator()
        {
            InitializeComponent();
        }

        // Opens the doors and windows form and passes the Room class instance as a parametre to the form
        private void btnNext_Click(object sender, EventArgs e)
        {
            new frmOpenings(Room).Show();
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Sets the length, width and height class properties to input in the related textboxes and also turns them into decimals
                Room.Length = decimal.Parse(txtLength.Text);
                Room.Width = decimal.Parse(txtWidth.Text);
                Room.Height = decimal.Parse(txtHeight.Text);

                // Rounds the length, width and height class properties to 2 decimal places
                Room.Length = Math.Round(Room.Length, 2);
                Room.Width = Math.Round(Room.Width, 2);
                Room.Height = Math.Round(Room.Height, 2);

                // Checks if any of the numbers entered are negative and if so, shows a message and stops the code from reading
                if (("" + Room.Length).IndexOf('-') >= 0 || ("" + Room.Width).IndexOf('-') >= 0 || ("" + Room.Height).IndexOf('-') >= 0)
                {
                    MessageBox.Show("Input cannot be a negative number");
                    return;
                }

                // Sets up the array declared at the start with the lenght, width and height class properties and displays them in the listbox
                decimal[] Dimensions = { Room.Length, Room.Width, Room.Height };
                lstDimensions.Items.Clear();
                lstDimensions.Items.Add("Length - " + Dimensions[0] + " m");
                lstDimensions.Items.Add("Width - " + Dimensions[1] + " m");
                lstDimensions.Items.Add("Height - " + Dimensions[2] + " m");

                // Clears all of the textboxes and enabled the button to the next page
                txtLength.Text = "";
                txtWidth.Text = "";
                txtHeight.Text = "";

                btnNext.Enabled = true;
            }

            // Catches any errors based on the data entered by the user (if any data is actually entered and if it is a vallid number)
            catch
            {
                if (txtLength.Text == "" || txtWidth.Text == "" || txtHeight.Text == "")
                {
                    MessageBox.Show("Input was empty");
                    return;
                }
                MessageBox.Show("Input was not a number");
                return;
            }
        }
    }
}
