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
    public partial class frmOpenings : Form
    {
        // Creates an instance of the Room class and loads data from the instance on the homepage
        Room Room;

        public frmOpenings(Room R)
        {
            InitializeComponent();
            Room = R;
        }

        // Closes this form and brings focus back to the homepage form
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Opens the results form and passes the Room class instance as a parametre to the form
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            new frmResults(Room).Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Checks if any of the numbers entered are negative and if so, shows a message and stops the code from reading
            if (("" + Room.Length).IndexOf('-') >= 0 || ("" + Room.Width).IndexOf('-') >= 0 || ("" + Room.Height).IndexOf('-') >= 0)
            {
                MessageBox.Show("Input cannot be a negative number");
                return;
            }

            try
            {
                // Sets the opening height and width class properties to input in the related textboxes and also turns them into decimals
                Room.OpeningHeight = decimal.Parse(txtOpeningHeight.Text);
                Room.OpeningWidth = decimal.Parse(txtOpeningWidth.Text);

                // Rounds the opening height and width class properties to 2 decimal places
                Room.OpeningWidth = Math.Round(Room.OpeningWidth, 2);
                Room.OpeningHeight = Math.Round(Room.OpeningHeight, 2);

                // Displays an entry in the listbox including the opening number, height, width and area from the room class instance
                lstOpenings.Items.Add("No. " + Room.OpeningNumber + ", Height: " + Room.OpeningHeight +
                    " m, Width: " + Room.OpeningWidth + " m, Area: " + Room.Opening + " m²");

                // Clears all of the textboxes
                txtOpeningHeight.Text = "";
                txtOpeningWidth.Text = "";
            }

            // Catches any errors based on the data entered by the user (if any data is actually entered and if it is a vallid number)
            catch
            {
                if (txtOpeningHeight.Text == "" || txtOpeningWidth.Text == "")
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
