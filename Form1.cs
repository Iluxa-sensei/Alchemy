using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlchemyGame
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Image> elementImages = new Dictionary<string, Image>();
        private Dictionary<Tuple<string, string>, string> combinations = new Dictionary<Tuple<string, string>, string>();


        public Form1()
        {
            InitializeComponent();
            LoadImages();
            DefineCombinations();
        }

        private void LoadImages()
        {
            elementImages["Огонь"] = Image.FromFile(@"C:\Users\User\Downloads\fire.jpg");
            elementImages["Вода"] = Image.FromFile(@"C:\Users\User\Downloads\water.png");
            elementImages["Пар"] = Image.FromFile(@"C:\Users\User\Downloads\steam.jpg");
            elementImages["Земля"] = Image.FromFile(@"C:\Users\User\Downloads\soil.png");
            elementImages["Энергия"] = Image.FromFile(@"C:\Users\User\Downloads\energy.png");
            elementImages["Воздух"] = Image.FromFile(@"C:\Users\User\Downloads\air.png");
            elementImages["Лава"] = Image.FromFile(@"C:\Users\User\Downloads\lava.jpg");
            elementImages["Пыль"] = Image.FromFile(@"C:\Users\User\Downloads\dust.jpg");
            elementImages["Туман"] = Image.FromFile(@"C:\Users\User\Downloads\tuman.png");
            elementImages["Грязь"] = Image.FromFile(@"C:\Users\User\Downloads\mud.jpg");
        }

        private void DefineCombinations()
        {
            combinations[Tuple.Create("Огонь", "Вода")] = "Пар";
            combinations[Tuple.Create("Вода", "Огонь")] = "Пар";

            combinations[Tuple.Create("Земля", "Вода")] = "Грязь";
            combinations[Tuple.Create("Вода", "Земля")] = "Грязь";

            combinations[Tuple.Create("Огонь", "Воздух")] = "Энергия";
            combinations[Tuple.Create("Воздух", "Огонь")] = "Энергия";

            combinations[Tuple.Create("Земля", "Огонь")] = "Лава";
            combinations[Tuple.Create("Огонь", "Земля")] = "Лава";

            combinations[Tuple.Create("Воздух", "Вода")] = "Туман";
            combinations[Tuple.Create("Вода", "Воздух")] = "Туман";

            combinations[Tuple.Create("Земля", "Воздух")] = "Пыль";
            combinations[Tuple.Create("Воздух", "Земля")] = "Пыль";

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string el1 = comboBox1.Text;
            string el2 = comboBox2.Text;

            if (!string.IsNullOrEmpty(el1))
                CreateDraggablePicture(el1, new Point(50, 50));

            if (!string.IsNullOrEmpty(el2))
                CreateDraggablePicture(el2, new Point(200, 50));
        }

        private void CreateDraggablePicture(string element, Point location)
        {
            PictureBox pic = new PictureBox
            {
                Image = elementImages[element],
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 64,
                Height = 64,
                Location = location,
                Tag = element
            };

            bool isDragging = false;
            Point mouseOffset = Point.Empty;

            pic.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    mouseOffset = new Point(e.X, e.Y);
                }
            };

            pic.MouseMove += (s, e) =>
            {
                if (isDragging)
                {
                    var newLocation = pic.Location;
                    newLocation.Offset(e.X - mouseOffset.X, e.Y - mouseOffset.Y);
                    pic.Location = newLocation;
                }
            };

            pic.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = false;
                }
            };

            // Добавь Drop-логика, если хочешь создавать новые элементы при наложении:
            pic.MouseUp += (s, e) =>
            {
                foreach (Control ctrl in panelGame.Controls)
                {
                    if (ctrl is PictureBox other && other != pic)
                    {
                        if (pic.Bounds.IntersectsWith(other.Bounds))
                        {
                            string elem1 = pic.Tag.ToString();
                            string elem2 = other.Tag.ToString();

                            if (combinations.TryGetValue(Tuple.Create(elem1, elem2), out string result))
                            {
                                MessageBox.Show("Создан новый элемент: " + result);
                                pic.Image = elementImages[result];
                                pic.Tag = result;
                                panelGame.Controls.Remove(other);
                                break;
                            }
                        }
                    }
                }
            };

            panelGame.Controls.Add(pic);
        }

    }
}