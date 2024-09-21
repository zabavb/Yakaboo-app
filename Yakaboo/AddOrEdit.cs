using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yakaboo.Models;

namespace Yakaboo
{
    public partial class AddOrEdit : Form
    {
        Context _Context = new Context();

        public Author _Author = new Author();
        public Book _Book = new Book();
        public Publisher _Publisher = new Publisher();

        private TextBox _TextBox1 = new TextBox();
        private TextBox _TextBox2 = new TextBox();
        private TextBox _TextBox3 = new TextBox();
        private ComboBox _ComboBox1 = new ComboBox();
        private ComboBox _ComboBox2 = new ComboBox();

        public AddOrEdit()
        {
            InitializeComponent();
        }

        private void AddOrEdit_Load(object sender, EventArgs e)
        {

            //============================================== Initialize Author ==============================================

            if (Extension.IsAuthor)
            {
                this.ClientSize = new Size(495, 217);
                this.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                this.ForeColor = Color.White;

                Label labelName = new Label();
                labelName.AutoSize = true;
                labelName.Location = new Point(36, 43);
                labelName.Name = "labelName";
                labelName.Size = new Size(59, 21);
                labelName.Text = "Name:";
                this.Controls.Add(labelName);

                TextBox textBoxName = new TextBox();
                textBoxName.Location = new Point(117, 40);
                textBoxName.Name = "textBoxName";
                textBoxName.Size = new Size(310, 28);
                textBoxName.TabIndex = 1;
                textBoxName.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                textBoxName.TextChanged += TextBoxNameAuthor_TextChanged;
                this.Controls.Add(textBoxName);
                _TextBox1 = textBoxName;

                Label labelSurname = new Label();
                labelSurname.AutoSize = true;
                labelSurname.Location = new Point(36, 90);
                labelSurname.Name = "labelSurname";
                labelSurname.Size = new Size(75, 21);
                labelSurname.Text = "Surname:";
                this.Controls.Add(labelSurname);

                TextBox textBoxSurname = new TextBox();
                textBoxSurname.Location = new Point(117, 87);
                textBoxSurname.Name = "textBoxName";
                textBoxSurname.Size = new Size(310, 28);
                textBoxSurname.TabIndex = 2;
                textBoxSurname.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                textBoxSurname.TextChanged += TextBoxSurname_TextChanged;
                this.Controls.Add(textBoxSurname);
                _TextBox2 = textBoxSurname;

                Button buttonOK = new Button();
                buttonOK.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                buttonOK.Location = new Point(101, 146);
                buttonOK.Name = "buttonOK";
                buttonOK.Size = new Size(93, 43);
                buttonOK.TabIndex = 3;
                buttonOK.Text = "OK";
                buttonOK.UseVisualStyleBackColor = true;
                buttonOK.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                buttonOK.Click += ButtonOKAuthor_Click;
                this.Controls.Add(buttonOK);

                Button buttonCancel = new Button();
                buttonCancel.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                buttonCancel.Location = new Point(294, 146);
                buttonCancel.Name = "buttonCancel";
                buttonCancel.Size = new Size(93, 43);
                buttonCancel.TabIndex = 4;
                buttonCancel.Text = "Cancel";
                buttonCancel.UseVisualStyleBackColor = true;
                buttonCancel.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                buttonCancel.Click += ButtonCancel_Click;
                this.Controls.Add(buttonCancel);
                //============================================== Fill fields of Author ==============================================
                if (!Extension.IsAdd)
                {
                    Author author = _Context.Authors.AsQueryable().AsParallel().FirstOrDefault(item => item.ID == Extension.SelectedItemID);
                    _Author.ID = author.ID;
                    textBoxName.Text = author.Name;
                    textBoxSurname.Text = author.Surname;
                }
            }
            //============================================== Initialize Book ==============================================
            if (Extension.IsBook)
            {
                this.ClientSize = new Size(495, 314);
                this.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                this.ForeColor = Color.White;

                Label labelTitle = new Label();
                labelTitle.AutoSize = true;
                labelTitle.Location = new Point(36, 43);
                labelTitle.Name = "labelTitle";
                labelTitle.Size = new Size(49, 21);
                labelTitle.Text = "Title:";
                this.Controls.Add(labelTitle);

                TextBox textBoxTitle = new TextBox();
                textBoxTitle.Location = new Point(125, 40);
                textBoxTitle.Name = "textBoxName";
                textBoxTitle.Size = new Size(302, 28);
                textBoxTitle.TabIndex = 1;
                textBoxTitle.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                textBoxTitle.TextChanged += TextBoxTitleBook_TextChanged;
                this.Controls.Add(textBoxTitle);
                _TextBox1 = textBoxTitle;

                Label labelPages = new Label();
                labelPages.AutoSize = true;
                labelPages.Location = new Point(36, 85);
                labelPages.Name = "labelPages";
                labelPages.Size = new Size(60, 21);
                labelPages.Text = "Pages:";
                this.Controls.Add(labelPages);

                TextBox textBoxPages = new TextBox();
                textBoxPages.Location = new Point(125, 82);
                textBoxPages.Name = "textBoxPages";
                textBoxPages.Size = new Size(302, 28);
                textBoxPages.TabIndex = 2;
                textBoxPages.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                textBoxPages.TextChanged += TextBoxPages_TextChanged;
                this.Controls.Add(textBoxPages);
                _TextBox2 = textBoxPages;

                Label labelPrice = new Label();
                labelPrice.AutoSize = true;
                labelPrice.Location = new Point(36, 128);
                labelPrice.Name = "labelPrice";
                labelPrice.Size = new Size(52, 21);
                labelPrice.Text = "Price:";
                this.Controls.Add(labelPrice);

                TextBox textBoxPrice = new TextBox();
                textBoxPrice.Location = new Point(125, 125);
                textBoxPrice.Name = "textBoxPrice";
                textBoxPrice.Size = new Size(302, 28);
                textBoxPrice.TabIndex = 3;
                textBoxPrice.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                textBoxPrice.TextChanged += TextBoxPrice_TextChanged;
                this.Controls.Add(textBoxPrice);
                _TextBox3 = textBoxPrice;

                Label labelPublisher = new Label();
                labelPublisher.AutoSize = true;
                labelPublisher.Location = new Point(36, 168);
                labelPublisher.Name = "labelPublisher";
                labelPublisher.Size = new Size(83, 21);
                labelPublisher.Text = "Publisher:";
                this.Controls.Add(labelPublisher);

                ComboBox comboBoxPublisher = new ComboBox();
                comboBoxPublisher.FormattingEnabled = true;
                comboBoxPublisher.Location = new Point(125, 165);
                comboBoxPublisher.Name = "comboBoxPublisher";
                comboBoxPublisher.Size = new Size(302, 28);
                comboBoxPublisher.TabIndex = 4;
                comboBoxPublisher.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                comboBoxPublisher.SelectedIndexChanged += ComboBoxPublisher_SelectedIndexChanged;
                this.Controls.Add(comboBoxPublisher);
                comboBoxPublisher.Items.AddRange(_Context.Publishers.Select(item => item.Name).ToArray());
                comboBoxPublisher.Items.Add("");
                _ComboBox1 = comboBoxPublisher;

                Label labelAuthor = new Label();
                labelAuthor.AutoSize = true;
                labelAuthor.Location = new Point(36, 213);
                labelAuthor.Name = "labelAuthor";
                labelAuthor.Size = new Size(83, 21);
                labelAuthor.Text = "Author:";
                this.Controls.Add(labelAuthor);

                ComboBox comboBoxAuthor = new ComboBox();
                comboBoxAuthor.FormattingEnabled = true;
                comboBoxAuthor.Location = new Point(125, 210);
                comboBoxAuthor.Name = "comboBoxAuthor";
                comboBoxAuthor.Size = new Size(302, 28);
                comboBoxAuthor.TabIndex = 5;
                comboBoxAuthor.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                comboBoxAuthor.SelectedIndexChanged += ComboBoxAuthor_SelectedIndexChanged;
                this.Controls.Add(comboBoxAuthor);
                comboBoxAuthor.Items.AddRange(_Context.Authors.Select(item => item.Name).ToArray());
                comboBoxAuthor.Items.Add("");
                _ComboBox2 = comboBoxAuthor;

                Button buttonOK = new Button();
                buttonOK.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                buttonOK.Location = new Point(101, 260);
                buttonOK.Name = "buttonOK";
                buttonOK.Size = new Size(93, 43);
                buttonOK.TabIndex = 6;
                buttonOK.Text = "OK";
                buttonOK.UseVisualStyleBackColor = true;
                buttonOK.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                buttonOK.Click += ButtonOKBook_Click;
                this.Controls.Add(buttonOK);

                Button buttonCancel = new Button();
                buttonCancel.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                buttonCancel.Location = new Point(294, 260);
                buttonCancel.Name = "buttonCancel";
                buttonCancel.Size = new Size(93, 43);
                buttonCancel.TabIndex = 7;
                buttonCancel.Text = "Cancel";
                buttonCancel.UseVisualStyleBackColor = true;
                buttonCancel.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                buttonCancel.Click += ButtonCancel_Click;
                this.Controls.Add(buttonCancel);
                //============================================== Fill fields of Book ==============================================
                if (!Extension.IsAdd)
                {
                    Book book = _Context.Books.AsQueryable().AsParallel().FirstOrDefault(item => item.ID == Extension.SelectedItemID);

                    _Book.ID = book.ID;
                    textBoxTitle.Text = book.Title;
                    textBoxPages.Text = book.Size.ToString();
                    textBoxPrice.Text = book.Price.ToString();

                    if (book.PublisherID != null)
                    {
                        Publisher publisher = _Context.Publishers.AsQueryable().AsParallel().FirstOrDefault(item => item.ID == book.PublisherID);

                        for (int i = 0; i < comboBoxPublisher.Items.Count; i++)
                            if (comboBoxPublisher.Items[i].ToString() == publisher.Name)
                                comboBoxPublisher.SelectedIndex = i;
                    }
                    if (book.AuthorID != null)
                    {
                        Author author = _Context.Authors.AsQueryable().AsParallel().FirstOrDefault(item => item.ID == book.AuthorID);

                        for (int i = 0; i < comboBoxAuthor.Items.Count; i++)
                            if (comboBoxAuthor.Items[i].ToString() == author.Name)
                                comboBoxAuthor.SelectedIndex = i;
                    }
                }
            }
            //============================================== Initialize Publisher ==============================================
            if (Extension.IsPublisher)
            {
                this.ClientSize = new Size(495, 226);
                this.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                this.ForeColor = Color.White;

                Label labelName = new Label();
                labelName.AutoSize = true;
                labelName.Location = new Point(36, 43);
                labelName.Name = "labelName";
                labelName.Size = new Size(59, 21);
                labelName.Text = "Name:";
                this.Controls.Add(labelName);

                TextBox textBoxName = new TextBox();
                textBoxName.Location = new Point(117, 40);
                textBoxName.Name = "textBoxName";
                textBoxName.Size = new Size(310, 28);
                textBoxName.TabIndex = 1;
                textBoxName.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                textBoxName.TextChanged += TextBoxNamePublisher_TextChanged;
                this.Controls.Add(textBoxName);
                _TextBox1 = textBoxName;

                Label labelAddress = new Label();
                labelAddress.AutoSize = true;
                labelAddress.Location = new Point(36, 88);
                labelAddress.Name = "labelAddress";
                labelAddress.Size = new Size(59, 21);
                labelAddress.Text = "Address:";
                this.Controls.Add(labelAddress);

                TextBox textBoxAddress = new TextBox();
                textBoxAddress.Location = new Point(117, 85);
                textBoxAddress.Name = "textBoxAddress";
                textBoxAddress.Size = new Size(310, 28);
                textBoxAddress.TabIndex = 2;
                textBoxAddress.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
                textBoxAddress.TextChanged += TextBoxAddress_TextChanged;
                this.Controls.Add(textBoxAddress);
                _TextBox2 = textBoxAddress;

                Button buttonOK = new Button();
                buttonOK.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                buttonOK.Location = new Point(101, 148);
                buttonOK.Name = "buttonOK";
                buttonOK.Size = new Size(93, 43);
                buttonOK.TabIndex = 3;
                buttonOK.Text = "OK";
                buttonOK.UseVisualStyleBackColor = true;
                buttonOK.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                buttonOK.Click += ButtonOKPublisher_Click;
                this.Controls.Add(buttonOK);

                Button buttonCancel = new Button();
                buttonCancel.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                buttonCancel.Location = new Point(294, 148);
                buttonCancel.Name = "buttonCancel";
                buttonCancel.Size = new Size(93, 43);
                buttonCancel.TabIndex = 4;
                buttonCancel.Text = "Cancel";
                buttonCancel.UseVisualStyleBackColor = true;
                buttonCancel.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                buttonCancel.Click += ButtonCancel_Click;
                this.Controls.Add(buttonCancel);
                //============================================== Fill fields of Publisher ==============================================
                if (!Extension.IsAdd)
                {
                    Publisher publisher = _Context.Publishers.AsQueryable().AsParallel().FirstOrDefault(item => item.ID == Extension.SelectedItemID);

                    _Publisher.ID = publisher.ID;
                    textBoxName.Text = publisher.Name;
                    textBoxAddress.Text = publisher.Address;
                }
            }
        }
        //============================================== General fields ==============================================
        private void ButtonCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddOrEdit_SizeChanged(object sender, EventArgs e)
        {
            if (Extension.IsAuthor)
                this.ClientSize = new Size(495, 217);
            else if (Extension.IsBook)
                this.ClientSize = new Size(495, 314);
            else if(Extension.IsPublisher)
                this.ClientSize = new Size(495, 226);
        }
        //============================================== Author fields ==============================================
        private void TextBoxNameAuthor_TextChanged(object? sender, EventArgs e)
        {
            _Author.Name = _TextBox1.Text;
        }
        private void TextBoxSurname_TextChanged(object? sender, EventArgs e)
        {
            _Author.Surname = _TextBox2.Text;
        }
        private void ButtonOKAuthor_Click(object? sender, EventArgs e)
        {
            if (_Author.Name.IsNullOrEmpty() || _Author.Surname.IsNullOrEmpty())
                MessageBox.Show("Not all fields filled correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        //============================================== Book fields ==============================================
        private void TextBoxTitleBook_TextChanged(object? sender, EventArgs e)
        {
            _Book.Title = _TextBox1.Text;
        }
        private void TextBoxPages_TextChanged(object? sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_TextBox2.Text))
            {
                string filter = Regex.Replace(_TextBox2.Text, "[^0-9]", "");

                if (_TextBox2.Text != filter)
                {
                    _TextBox2.Text = filter;
                    _TextBox2.SelectionStart = _TextBox2.Text.Length;
                }
                else
                    _Book.Size = Convert.ToInt32(_TextBox2.Text);
            }
            else
                _Book.Size = 0;
        }
        private void TextBoxPrice_TextChanged(object? sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_TextBox3.Text))
            {
                string filter = Regex.Replace(_TextBox3.Text, "[^0-9,]", "");

                if (_TextBox3.Text != filter)
                {
                    _TextBox3.Text = filter;
                    _TextBox3.SelectionStart = _TextBox3.Text.Length;
                }
                else
                {
                    if (!_TextBox3.Text.EndsWith(","))
                    {
                        _Book.Price = Convert.ToSingle(_TextBox3.Text);
                        _TextBox3.SelectionStart = _TextBox3.Text.Length;
                    }
                }
            }
            else
                _Book.Price = 0f;
        }
        private void ComboBoxPublisher_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_ComboBox1.SelectedItem.ToString() != "")
                _Book.PublisherID = _Context.Publishers.FirstOrDefault(item => item.Name == _ComboBox1.SelectedItem.ToString()).ID;
            else
                _Book.PublisherID = null;
        }
        private void ComboBoxAuthor_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_ComboBox2.SelectedItem.ToString() != "")
                _Book.AuthorID = _Context.Authors.FirstOrDefault(item => item.Name == _ComboBox2.SelectedItem.ToString()).ID;
            else
                _Book.AuthorID = null;
        }
        private void ButtonOKBook_Click(object? sender, EventArgs e)
        {
            string tmpStr = _Book.Price.ToString();
            if (_Book.Title.IsNullOrEmpty() || _Book.Size <= 0 || _Book.Price <= 0 || _ComboBox1.SelectedItem.ToString() == "" || _ComboBox2.SelectedItem.ToString() == "")
                MessageBox.Show("Not all fields filled correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (tmpStr.EndsWith(","))
                {
                    List<char> tmpList = tmpStr.ToList();
                    tmpList.RemoveAt(tmpList.Count);
                    _Book.Price = Convert.ToSingle(tmpList);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        //============================================== Publisher fields ==============================================
        private void TextBoxNamePublisher_TextChanged(object? sender, EventArgs e)
        {
            _Publisher.Name = _TextBox1.Text;
        }
        private void TextBoxAddress_TextChanged(object? sender, EventArgs e)
        {
            _Publisher.Address = _TextBox2.Text;
        }
        private void ButtonOKPublisher_Click(object? sender, EventArgs e)
        {
            if (_Publisher.Name.IsNullOrEmpty())
                MessageBox.Show("Not all fields filled correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}