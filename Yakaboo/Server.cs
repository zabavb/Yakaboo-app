using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Collections.Generic;
using System.Web;
using Yakaboo.CRUD;
using Yakaboo.Models;

namespace Yakaboo
{
    public partial class Server : Form
    {
        Context _Context = new Context();

        public Server()
        {
            InitializeComponent();

            comboBoxTables.SelectedIndex = 0;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            textBoxFindIsEmpty();
            dataGridView1.ForeColor = Color.Black;

        }
        //============================================== General fields ==============================================
        public void SelectedItem()
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            Extension.SelectedItemID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
        }
        public void AuthorOrBookOrPublisher()
        {
            Extension.IsAuthor = comboBoxTables.SelectedIndex == 0;
            Extension.IsBook = comboBoxTables.SelectedIndex == 1;
            Extension.IsPublisher = comboBoxTables.SelectedIndex == 2;
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTables.SelectedIndex == 0)
                InitializeDataGridViewAuthors(new List<Author>(), false);
            else if (comboBoxTables.SelectedIndex == 1)
                InitializeDataGridViewBooks(new List<Book>(), false);
            else if (comboBoxTables.SelectedIndex == 2)
                InitializeDataGridViewPublishers(new List<Publisher>(), false);
        }

        private void InitializeDataGridViewAuthors(List<Author> authors, bool isSelect)
        {
            if (comboBoxTables.SelectedIndex != 0)
                comboBoxTables.SelectedIndex = 0;

            if (isSelect)
                dataGridView1.DataSource = authors;
            else
                dataGridView1.DataSource = _Context.Authors.AsQueryable().AsParallel().ToList();

            if (dataGridView1.Columns.Count > 0)
                dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void InitializeDataGridViewBooks(List<Book> books, bool isSelect)
        {
            if (comboBoxTables.SelectedIndex != 1)
                comboBoxTables.SelectedIndex = 1;

            if (isSelect)
                dataGridView1.DataSource = books.AsQueryable().Select(item => new
                {
                    item.ID,
                    item.Title,
                    item.Size,
                    item.Price,
                    item.AuthorID,
                    Author = _Context.Authors.FirstOrDefault(a => a.ID == item.AuthorID).Name + " " + _Context.Authors.FirstOrDefault(a => a.ID == item.AuthorID).Surname,
                    item.PublisherID,
                    Publisher = _Context.Publishers.FirstOrDefault(p => p.ID == item.PublisherID).Name
                }).AsParallel().ToList();
            else
                dataGridView1.DataSource = _Context.Books.AsQueryable().Select(item => new
                {
                    item.ID,
                    item.Title,
                    item.Size,
                    item.Price,
                    item.AuthorID,
                    Author = _Context.Authors.FirstOrDefault(a => a.ID == item.AuthorID).Name + " " + _Context.Authors.FirstOrDefault(a => a.ID == item.AuthorID).Surname,
                    item.PublisherID,
                    Publisher = _Context.Publishers.FirstOrDefault(p => p.ID == item.PublisherID).Name
                }).AsParallel().ToList();

            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["AuthorID"].Visible = false;
                dataGridView1.Columns["PublisherID"].Visible = false;
            }
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void InitializeDataGridViewPublishers(List<Publisher> publishers, bool isSelect)
        {
            if (comboBoxTables.SelectedIndex != 2)
                comboBoxTables.SelectedIndex = 2;

            if (isSelect)
                dataGridView1.DataSource = publishers;
            else
                dataGridView1.DataSource = _Context.Publishers.AsQueryable().AsParallel().ToList();

            if (dataGridView1.Columns.Count > 0)
                dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void textBoxFind_Enter(object sender, EventArgs e)
        {
            textBoxFindIsEmpty();
        }
        private void textBoxFind_Leave(object sender, EventArgs e)
        {
            textBoxFindIsEmpty();
        }
        private void textBoxFindIsEmpty()
        {
            if (string.IsNullOrEmpty(textBoxFind.Text))
            {
                textBoxFind.Text = "Search...";
                textBoxFind.ForeColor = Color.Gray;
            }
            else if (textBoxFind.ForeColor == Color.Gray)
            {
                textBoxFind.Text = string.Empty;
                textBoxFind.ForeColor = Color.Black;
            }
        }

        private void Server_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(765, 525);
        }

        //============================================== Select/Search ==============================================
        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            AuthorOrBookOrPublisher();
            if (!string.IsNullOrEmpty(textBoxFind.Text))
            {
                if (textBoxFind.Text != "Search...")
                {
                    if (Extension.IsAuthor)
                    {
                        AuthorAdapter authorAdapter = new AuthorAdapter();
                        object obj = authorAdapter.Select(_Context, textBoxFind.Text);

                        InitializeDataGridViewAuthors((List<Author>)obj, true);
                    }
                    if (Extension.IsBook)
                    {
                        BookAdapter bookAdapter = new BookAdapter();
                        object obj = bookAdapter.Select(_Context, textBoxFind.Text);

                        InitializeDataGridViewBooks((List<Book>)obj, true);
                    }
                    if (Extension.IsPublisher)
                    {
                        PublisherAdapter publisherAdapter = new PublisherAdapter();

                        object obj = publisherAdapter.Select(_Context, textBoxFind.Text);
                        InitializeDataGridViewPublishers((List<Publisher>)obj, true);
                    }
                }
            }
            else
            {
                if (Extension.IsAuthor)
                    InitializeDataGridViewAuthors(new List<Author>(), false);
                else if (Extension.IsBook)
                    InitializeDataGridViewBooks(new List<Book>(), false);
                else if (Extension.IsPublisher)
                    InitializeDataGridViewPublishers(new List<Publisher>(), false);
            }
        }
        //============================================== Add ==============================================
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AuthorOrBookOrPublisher();
            Extension.IsAdd = true;

            AddOrEdit addForm = new AddOrEdit();
            DialogResult dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (Extension.IsAuthor)
                {
                    AuthorAdapter authorAdapter = new AuthorAdapter();
                    authorAdapter.Add(_Context, addForm);

                    InitializeDataGridViewAuthors(new List<Author>(), false);
                }
                if (Extension.IsBook)
                {
                    BookAdapter bookAdapter = new BookAdapter();
                    bookAdapter.Add(_Context, addForm);

                    InitializeDataGridViewBooks(new List<Book>(), false);
                }
                if (Extension.IsPublisher)
                {
                    PublisherAdapter publisherAdapter = new PublisherAdapter();
                    publisherAdapter.Add(_Context, addForm);

                    InitializeDataGridViewPublishers(new List<Publisher>(), false);
                }
            }
        }
        //============================================== Edit ==============================================
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                SelectedItem();
                AuthorOrBookOrPublisher();
                Extension.IsAdd = false;

                AddOrEdit editForm = new AddOrEdit();
                DialogResult dialogResult = editForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    if (Extension.IsAuthor)
                    {
                        AuthorAdapter authorAdapter = new AuthorAdapter();
                        authorAdapter.Update(_Context, editForm);

                        InitializeDataGridViewAuthors(new List<Author>(), false);
                    }
                    if (Extension.IsBook)
                    {
                        BookAdapter bookAdapter = new BookAdapter();
                        bookAdapter.Update(_Context, editForm);

                        InitializeDataGridViewBooks(new List<Book>(), false);
                    }
                    if (Extension.IsPublisher)
                    {
                        PublisherAdapter publisherAdapter = new PublisherAdapter();
                        publisherAdapter.Update(_Context, editForm);

                        InitializeDataGridViewPublishers(new List<Publisher>(), false);
                    }
                }
            }
            else
                MessageBox.Show("Please choose element (one) to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //============================================== Delete ==============================================
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                SelectedItem();
                AuthorOrBookOrPublisher();

                if (Extension.IsAuthor)
                {
                    AuthorAdapter authorAdapter = new AuthorAdapter();
                    authorAdapter.Delete(_Context);

                    InitializeDataGridViewAuthors(new List<Author>(), false);
                }
                if (Extension.IsBook)
                {
                    BookAdapter bookAdapter = new BookAdapter();
                    bookAdapter.Delete(_Context);

                    InitializeDataGridViewBooks(new List<Book>(), false);
                }
                if (Extension.IsPublisher)
                {
                    PublisherAdapter publisherAdapter = new PublisherAdapter();
                    publisherAdapter.Delete(_Context);

                    InitializeDataGridViewPublishers(new List<Publisher>(), false);
                }
            }
            else
                MessageBox.Show("Please choose element (one) to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}