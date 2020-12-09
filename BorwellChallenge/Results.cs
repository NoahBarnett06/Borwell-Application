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
    public partial class frmResults : Form
    {
        // Creates an instance of the Room class and loads data from the instance on the doors and windows form
        Room Room;

        public frmResults(Room R)
        {
            InitializeComponent();
            Room = R;
        }

        // Closes this form and brings focus back to the openings form
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Changes the placeholder labels to display the final output (the area of the floor, the volume of the room, and the amount of paint needed to paint the walls)
        private void frmResults_Load(object sender, EventArgs e)
        {
            lblArea.Text = "Area of the floor = " + Math.Round(Room.FloorArea, 2) + " m²";
            lblVolume.Text = "Volume of the room = " + Math.Round(Room.Volume, 2) + " m³";
            lblPaint.Text = "Amount of paint needed to paint the walls = " + Room.Paint + " litres";
        }
    }
}
