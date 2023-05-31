using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace ContactManager
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Contact> contacts;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Contact> Contacts
        {
            get { return contacts; }
            set
            {
                contacts = value;
                OnPropertyChanged("Contacts");
            }
        }

        private Contact selectedContact;

        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged("SelectedContact");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Contacts = new ObservableCollection<Contact>();
            SelectedContact = null;
            DataContext = this;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            Contact newContact = new Contact(name, phoneNumber);
            Contacts.Add(newContact);
            ClearInputFields();
        }

        private void lstContacts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedContact = (Contact)lstContacts.SelectedItem;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ClearInputFields()
        {
            txtName.Text = "";
            txtPhoneNumber.Text = "";
        }
    }
}
