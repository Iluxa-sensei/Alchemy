namespace AlchemyGame
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Label labelHint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panelGame = new System.Windows.Forms.Panel();
            this.labelHint = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { "Огонь", "Вода", "Воздух", "Земля" });
            this.comboBox1.Location = new System.Drawing.Point(20, 20);

            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] { "Огонь", "Вода", "Воздух", "Земля" });
            this.comboBox2.Location = new System.Drawing.Point(150, 20);

            this.buttonAdd.Text = "Добавить элементы";
            this.buttonAdd.Location = new System.Drawing.Point(300, 20);
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            this.panelGame.Location = new System.Drawing.Point(20, 60);
            this.panelGame.Size = new System.Drawing.Size(600, 400);
            this.panelGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGame.AllowDrop = true;

            this.labelHint.Text = "Перетащите элементы вместе для комбинации.";
            this.labelHint.Location = new System.Drawing.Point(20, 470);
            this.labelHint.Size = new System.Drawing.Size(400, 20);

            this.ClientSize = new System.Drawing.Size(650, 500);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.labelHint);
            this.Name = "Form1";
            this.Text = "Алхимия";
            this.ResumeLayout(false);
        }
    }
}