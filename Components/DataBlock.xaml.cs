using PasswordManager.Helper;
using PasswordManager.Pages;
using PasswordManager.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PasswordManager.Components
{
    public partial class DataBlock : UserControl
    {
        public DataBlock(string title, string login, string password, string additional)
        {
            InitializeComponent();

            this.Title_Content.Content = title;
            this.Login_Content.Content = login;
            this.Password_Content.Text = password;
            this.Additional_Content.Text = additional;

            this.InitialsTitle.Text = title.Substring(0, 2);
        }

        private void DataBlock_Click(object sender, RoutedEventArgs e)
        {
            DataBlockContent dataBlockContent = new DataBlockContent(this.Title_Content.Content.ToString(), this.Login_Content.Content.ToString(), this.Password_Content.Text, this.Additional_Content.Text);
            AddDataBlockContent(dataBlockContent);
        }

        private void EditBlock_Click(object sender, RoutedEventArgs e)
        {
            Modal_EditData modal_editData = new Modal_EditData(this, this.Title_Content.Content.ToString(), this.Login_Content.Content.ToString(), this.Password_Content.Text, this.Additional_Content.Text);
            ModalService.ShowModal(modal_editData);
        }

        private void DeleteBlock_Click(object sender, RoutedEventArgs e)
        {
            DeleteDialog deleteDialog = new DeleteDialog(this);
            ModalService.ShowModal(deleteDialog);
        }

        private void AddDataBlockContent(DataBlockContent dataBlockContent)
        {
            MainPage.MainPageInstance?.DataBlockContentPanel.Children.Clear();
            MainPage.MainPageInstance?.DataBlockContentPanel.Children.Add(dataBlockContent);
        }
    }
}