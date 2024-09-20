using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Test3._7._2024
{
    public partial class Form1 : Form
    {
        private readonly Metode metode = new();
        private int istoricid = 0;

        // Stive pentru operatiile Undo și Redo
        private readonly Stack<Operation> undoStack = new();
        private readonly Stack<Operation> redoStack = new();
        public Form1()
        {
            InitializeComponent();
            InitializeToolTips();
        }

        private void InitializeToolTips()
        {
            // Inițializare ToolTip
            toolTip = new()
            {
                // Setarea opțiunilor pentru ToolTip
                AutoPopDelay = 5000, // Timpul cât va fi vizibil ToolTip-ul
                InitialDelay = 1000, // Întârzierea inițială înainte de afișare
                ReshowDelay = 500, // Întârzierea între afișări
                ShowAlways = true // Afișează ToolTip-ul chiar și când formularul nu este activ
            };

            // Asociază mesaje de ToolTip pentru controalele respective
            toolTip.SetToolTip(this.selectId, "Introduceți ID-ul dispozitivului");
            toolTip.SetToolTip(this.startDate, "Selectați data de start de back-up");
            toolTip.SetToolTip(this.endDate, "Selectați data de final de back-up");
            toolTip.SetToolTip(this.appToBeSearched, "Introduceți aplicațiile instalate (separate prin virgule)");
            toolTip.SetToolTip(this.appsTextBox, "Introduceți aplicațiile instalate (separate prin virgule)");
            toolTip.SetToolTip(this.dateForAdvanced, "Introduceți data back-up-ului realizat");
            toolTip.SetToolTip(this.signOutButton, "Iesire din contul actual");
            toolTip.SetToolTip(this.aboutButton, "Informatii despre aplicatie");
            toolTip.SetToolTip(this.helpButton, "Ghid indrumator de utilizare a aplicatiei");
            toolTip.SetToolTip(this.undoButton, "Intoarcere la starea dinaintea ultimei actualizari");
            toolTip.SetToolTip(this.redoButton, "Intoarcere la starea dinaintea ultimului Undo");
            toolTip.SetToolTip(this.addNewButton, "Adauga un dispozitiv nou cu datele din \"Installed Apps\" si data din selector-ul de data");
            toolTip.SetToolTip(this.updateButton, "Actualizeaza un dispozitiv cu datele din \"Installed Apps\" si data din selector-ul de data");
            toolTip.SetToolTip(this.deleteButton, "Sterge ultimul dispozitiv cautat");

        }

        // Metoda de controlare a vizibilitatii componentelor principale ale aplicatiei
        // In functie daca operatorul este logat sau nu, acesta va avea vizibilitatea butoanelor
        private void SetUIVisibility(bool isVisible)
        {
            aboutButton.Visible = isVisible;
            helpButton.Visible = isVisible;
            searchByDate.Visible = isVisible;
            searchByID.Visible = isVisible;
            searchByApp.Visible = isVisible;
            startDate.Visible = isVisible;
            endDate.Visible = isVisible;
            startDateLabel.Visible = isVisible;
            endDateLabel.Visible = isVisible;
            selectId.Visible = isVisible;
            appToBeSearched.Visible = isVisible;
            historyTextBox.Visible = isVisible;
            dateForAdvanced.Visible = isVisible;
            appsLabel.Visible = isVisible;
            appsTextBox.Visible = isVisible;
            updateButton.Visible = isVisible;
            addNewButton.Visible = isVisible;
            deleteButton.Visible = isVisible;
            signOutButton.Visible = isVisible;
            usersNameLabel.Visible = isVisible;
            userPictureBox.Visible = isVisible;
            undoButton.Visible = isVisible;
            redoButton.Visible = isVisible;
            inventoryId.Visible = isVisible;
            inventarIdLabel.Visible = isVisible;
            redCodeLabel.Visible = isVisible;
            yellowCodeLabel.Visible = isVisible;
            greenCodeLabel.Visible = isVisible;
            userLabel.Visible = !isVisible;
            passwordLabel.Visible = !isVisible;
            signInButton.Enabled = !isVisible;
            signInButton.Visible = !isVisible;
            textBoxUsername.Enabled = !isVisible;
            textBoxUsername.Visible = !isVisible;
            textBoxPassword.Enabled = !isVisible;
            textBoxPassword.Visible = !isVisible;
        }

        // Metoda de setare a permisiunilor operatorului in urma login-ului
        // Exista 3 categorii de permisiuni (default - operator basic, intermediate - operator cu drept de actualizare a DB si admin - drepturi depline)
        private void SetPermissions(int userRights)
        {
            switch (userRights)
            {
                case 1: // Read-only
                    dateForAdvanced.Enabled = false;
                    appsLabel.Enabled = false;
                    appsTextBox.Enabled = false;
                    inventoryId.Enabled = false;
                    updateButton.Enabled = false;
                    addNewButton.Enabled = false;
                    deleteButton.Enabled = false;
                    break;
                case 2: // Edit existing
                    dateForAdvanced.Enabled = true;
                    appsLabel.Enabled = true;
                    appsTextBox.Enabled = true;
                    inventoryId.Enabled = false;
                    updateButton.Enabled = true;
                    addNewButton.Enabled = false;
                    deleteButton.Enabled = false;
                    break;
                case 3: // Full access
                    dateForAdvanced.Enabled = true;
                    appsLabel.Enabled = true;
                    appsTextBox.Enabled = true;
                    inventoryId.Enabled = true;
                    updateButton.Enabled = true;
                    addNewButton.Enabled = true;
                    deleteButton.Enabled = true;
                    break;
            }
        }

        // Functionalitatea butonului de SignIn
        // Se compara datele introduse din campurile username si password cu cele din DB
        private void SignInButton_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            // Verificare daca campurile sunt nule sau goale
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userRights = metode.VerifyLogin(username, password);
            // Login reusit
            if (userRights > 0)
            {
                MessageBox.Show("Login successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchByDate.Checked = false;
                searchByID.Checked = false;
                searchByApp.Checked = false;
                SetUIVisibility(true);
                SetPermissions(userRights);
                usersNameLabel.Text = username;
                LoadComboBoxData();
            }
            // Logare esuata
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metoda de resetare a form-ului de logare la apasarea butonului de SignOut
        private void ResetLoginForm()
        {
            signInButton.Enabled = true;
            textBoxUsername.Enabled = true;
            textBoxPassword.Enabled = true;
            historyTextBox.Text = string.Empty;
            selectId.Text = string.Empty;
            usersNameLabel.Text = string.Empty;
            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            appToBeSearched.Text = string.Empty;
            appsTextBox.Text = string.Empty;
        }

        // Metoda ToggleSearchButton, in functie de tipul de Search avem functionalitati diferite in metoda din SearchButton
        private void ToggleSearchOptions(int option)
        {
            switch (option)
            {
                case 1: // Search dupa id produs
                    selectId.Enabled = true;
                    searchByID.Checked = true;
                    appToBeSearched.Enabled = false;
                    startDate.Enabled = false;
                    endDate.Enabled = false;
                    break;
                case 2: // Search dupa interval data back-up
                    selectId.Enabled = false;
                    appToBeSearched.Enabled = false;
                    startDate.Enabled = true;
                    searchByDate.Checked = true;
                    endDate.Enabled = true;
                    break;
                case 3: // Search dupa aplicatiile instalate
                    selectId.Enabled = false;
                    appToBeSearched.Enabled = true;
                    searchByApp.Checked = true;
                    startDate.Enabled = false;
                    endDate.Enabled = false;
                    break;
            }
        }

        // Delogare si resetare vizibilitate interfata
        private void SignOutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sign out successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetUIVisibility(false);
            ResetLoginForm();
        }

        // Metoda de update la ultimul dispozitiv interogat, actualizeaza doar data si aplicatiile instalate pe acesta, NU si ID-ul
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            // Afișează o fereastră de confirmare
            DialogResult result = MessageBox.Show(
                "Are you sure you want to update this device?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            // Verifică răspunsul utilizatorului
            if (result == DialogResult.Yes)
            {
                // Utilizatorul a confirmat 
                var originalInventar = metode.SearchByID(istoricid).FirstOrDefault();
                if (originalInventar == null)
                {
                    MessageBox.Show("Original item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Inventar inventar = new()
                {
                    ID = istoricid,
                    BackupDate = dateForAdvanced.Value,
                    Applications = appsTextBox.Text
                };
                metode.UpdateInventar(inventar);

                Log newLog = new()
                {
                    IDlog = 0,
                    User = textBoxUsername.Text,
                    LogDate = DateTime.Now,
                    InvIdOperatedOn = inventar.ID,
                    TypeOfOperationUsed = "Update"
                };
                metode.LogToDB(newLog);

                MessageBox.Show("Item with ID = " + inventar.ID + " updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadComboBoxData();
                SearchForResults(sender, e);
                // Stocare stare pentru UNDO: Salvăm operația în stiva de undo
                undoStack.Push(new Operation
                {
                    Type = OperationType.Update,
                    Item = originalInventar
                });
                redoStack.Clear();
                UpdateButtons();
            }
            else
            {
                // Utilizatorul a anulat update-ul
                MessageBox.Show("Update canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Metoda de search, interogheaza baza de date in functie de filtrul introdus
        private void SearchForResults(object sender, EventArgs e)
        {
            if (startDate.Enabled == true) // Caut dupa interval back-up
            {
                var results = metode.SearchByDate(startDate.Value, endDate.Value);
                DisplayResults(results);
            }
            else if (selectId.Enabled == true) // Caut dupa ID
            {
                if (int.TryParse(selectId.Text, out int Id))
                {
                    // Conversia a reușit, Id conține valoarea convertită
                    var results = metode.SearchByID(Id);
                    DisplayResults(results);
                }
                else
                {
                    var results = metode.SearchByID(0);
                    DisplayResults(results);
                    // Conversia a eșuat, deci nu este un număr întreg valid
                    //MessageBox.Show("Please enter a valid integer ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (appToBeSearched.Enabled == true) // Caut dupa aplicatiile instalate
            {
                string app = appToBeSearched.Text.Trim();
                var results = metode.SearchByApp(app);
                DisplayResults(results);
            }
        }

        // Metoda de add new device in sistem, ID-ul nou este auto-incrementat dupa ultimul id introdus si cu informatiile introduse de operator
        private void AddNewButton_Click(object sender, EventArgs e)
        {
            // Afișează o fereastră de confirmare
            DialogResult result = MessageBox.Show(
                "Are you sure you want to add this new device?",
                "Confirm Adding",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            // Verifică răspunsul utilizatorului
            if (result == DialogResult.Yes)
            {
                // Utilizatorul a confirmat 
                if (int.TryParse(inventoryId.Text, out int invId))
                {
                    Inventar inventar = new()
                    {
                        ID = invId,
                        BackupDate = dateForAdvanced.Value,
                        Applications = appsTextBox.Text
                    };
                    metode.AddNewInventar(ref inventar);

                    Log newLog = new()
                    {
                        IDlog = 0,
                        User = textBoxUsername.Text,
                        LogDate = DateTime.Now,
                        InvIdOperatedOn = inventar.ID,
                        TypeOfOperationUsed = "Add"
                    };
                    metode.LogToDB(newLog);

                    MessageBox.Show("Item added with ID = " + inventar.ID, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadComboBoxData();

                    // Stocare stare pentru UNDO: Salvăm operația în stiva de undo
                    undoStack.Push(new Operation
                    {
                        Type = OperationType.Add,
                        Item = inventar
                    });
                    redoStack.Clear();
                    UpdateButtons();
                }
                else
                {
                    Inventar inventar = new()
                    {
                        ID = 0,
                        BackupDate = dateForAdvanced.Value,
                        Applications = appsTextBox.Text
                    };
                    metode.AddNewInventar(ref inventar);
                    Log newLog = new()
                    {
                        IDlog = 0,
                        User = textBoxUsername.Text,
                        LogDate = DateTime.Now,
                        InvIdOperatedOn = inventar.ID,
                        TypeOfOperationUsed = "Add"
                    };
                    metode.LogToDB(newLog);
                    MessageBox.Show("Item added with ID = " + inventar.ID, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadComboBoxData();

                    // Stocare stare pentru UNDO: Salvăm operația în stiva de undo
                    undoStack.Push(new Operation
                    {
                        Type = OperationType.Add,
                        Item = inventar
                    });
                    redoStack.Clear();
                    UpdateButtons();
                }
            }
            else
            {
                // Utilizatorul a anulat ștergerea
                MessageBox.Show("Adding canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Metoda de delete a ultimului dispozitiv interogat din DB
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int idValue = istoricid;
            // Afișează o fereastră de confirmare
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this ID " + idValue + "?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            // Verifică răspunsul utilizatorului
            if (result == DialogResult.Yes)
            {
                // Utilizatorul a confirmat 
                var originalInventar = metode.SearchByID(idValue).FirstOrDefault();
                if (originalInventar == null)
                {
                    MessageBox.Show("Original item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                metode.DeleteInventar(idValue);

                Log newLog = new()
                {
                    IDlog = 0,
                    User = textBoxUsername.Text,
                    LogDate = DateTime.Now,
                    InvIdOperatedOn = idValue,
                    TypeOfOperationUsed = "Delete"
                };
                metode.LogToDB(newLog);

                MessageBox.Show("Item with ID " + idValue + " deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadComboBoxData();
                SearchForResults(sender, e);

                // Stocare stare pentru UNDO
                // Salvăm operația în stiva de undo
                undoStack.Push(new Operation
                {
                    Type = OperationType.Delete,
                    Item = originalInventar
                });
                redoStack.Clear();
                UpdateButtons();
            }
            else
            {
                // Utilizatorul a anulat ștergerea
                MessageBox.Show("Deletion canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Metoda de actualizare la update-uri din DB a listei de ID-uri ce pot fi selectate de selectID
        private void LoadComboBoxData()
        {
            List<int> ids = metode.GetIdsFromDatabase();
            selectId.Items.Clear();
            foreach (var id in ids)
            {
                selectId.Items.Add(id);
            }
        }

        // Metoda de afisare a rezultatelor in historyTextBox
        private void DisplayResults(List<Inventar> results)
        {
            historyTextBox.Text = string.Empty;
            if (results != null && results.Count > 0)
            {
                istoricid = results.Last().ID;
                UpdateHistoryBox(historyTextBox, results);
            }
            // Daca nu gasesc inregistrari, afisez eroare
            else
            {
                historyTextBox.Items.Clear();
                ListBoxItem listBoxItem = new($"No records found!\r\n", Color.Red);
                historyTextBox.Items.Add(listBoxItem);
            }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Tool has been developed by Nechifor Ionut-Sebastian, Badge number: 93", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string helpMessage = "Welcome to the Application Help!\n\n" +
                                 "This application allows you to manage your inventory of devices with ease. Here’s a brief guide on how to use the features:\n\n" +
                                 "1. **Selecting Filters**:\n" +
                                 "   - Use the buttons on the left to select the filter type you want to use.\n" +
                                 "   - **ID Filter**: Enter the ID of the item in the box provided.\n" +
                                 "   - **Backup Interval Filter**: Select the start and end dates to filter by backup date.\n" +
                                 "   - **Applications Filter**: Enter the name of the application you are searching for in the corresponding box.\n\n" +
                                 "2. **Performing Searches**:\n" +
                                 "   - After setting your filters, click the 'Search' button.\n" +
                                 "   - Results will be displayed in the 'HistoryBox' below. You can work with these results to update, delete, or insert new entries.\n\n" +
                                 "3. **Data Management**:\n" +
                                 "   - **Add New Button**: Adds a new entry to the database with the last backup date and the apps installed as specified by the operator.\n" +
                                 "   - **Update Button**: Updates the selected entry with the data entered in the input fields.\n" +
                                 "   - **Delete Button**: Deletes the selected entry from the database. **Note**: A confirmation dialog will appear to prevent accidental deletions.\n\n" +
                                 "4. **Caution**:\n" +
                                 "   - All operations directly affect the database. Please ensure you are making the correct changes to avoid data loss or corruption.\n\n" +
                                 "For further assistance, please refer to the user manual or contact support.";

            MessageBox.Show(helpMessage, "Application Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Implementare buton REDO
        private void RedoButton_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                var lastUndoneOperation = redoStack.Pop();
                switch (lastUndoneOperation.Type)
                {
                    case OperationType.Add:
                        undoStack.Push(lastUndoneOperation);
                        Inventar temp = lastUndoneOperation.Item;
                        metode.AddNewInventar(ref temp);

                        Log newLog = new()
                        {
                            IDlog = 0,
                            User = textBoxUsername.Text,
                            LogDate = DateTime.Now,
                            InvIdOperatedOn = temp.ID,
                            TypeOfOperationUsed = "RedoAdd"
                        };
                        metode.LogToDB(newLog);

                        break;
                    case OperationType.Delete:
                        undoStack.Push(lastUndoneOperation);
                        metode.DeleteInventar(lastUndoneOperation.Item.ID);

                        Log newLog1 = new()
                        {
                            IDlog = 0,
                            User = textBoxUsername.Text,
                            LogDate = DateTime.Now,
                            InvIdOperatedOn = lastUndoneOperation.Item.ID,
                            TypeOfOperationUsed = "RedoDelete"
                        };
                        metode.LogToDB(newLog1);

                        break;
                    case OperationType.Update:
                        Inventar tempUpdate = metode.SelectInventar(lastUndoneOperation.Item.ID);
                        var originalItem = lastUndoneOperation.Item;
                        metode.UpdateInventar(originalItem);

                        Log newLog3 = new()
                        {
                            IDlog = 0,
                            User = textBoxUsername.Text,
                            LogDate = DateTime.Now,
                            InvIdOperatedOn = originalItem.ID,
                            TypeOfOperationUsed = "RedoUpdate"
                        };
                        metode.LogToDB(newLog3);

                        lastUndoneOperation.Item = tempUpdate;
                        undoStack.Push(lastUndoneOperation);
                        break;
                }
                LoadComboBoxData();
                UpdateButtons();
                SearchForResults(sender, e);
            }
            else
            {
                MessageBox.Show("No actions to redo.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Implementare buton UNDO
        private void UndoButton_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                var lastOperation = undoStack.Pop();
                switch (lastOperation.Type)
                {
                    case OperationType.Add:
                        redoStack.Push(lastOperation);
                        metode.DeleteInventar(lastOperation.Item.ID);

                        Log newLog = new()
                        {
                            IDlog = 0,
                            User = textBoxUsername.Text,
                            LogDate = DateTime.Now,
                            InvIdOperatedOn = lastOperation.Item.ID,
                            TypeOfOperationUsed = "UndoAdd"
                        };
                        metode.LogToDB(newLog);

                        break;
                    case OperationType.Delete:
                        redoStack.Push(lastOperation);
                        Inventar temp = lastOperation.Item;
                        metode.AddNewInventar(ref temp);

                        Log newLog1 = new()
                        {
                            IDlog = 0,
                            User = textBoxUsername.Text,
                            LogDate = DateTime.Now,
                            InvIdOperatedOn = temp.ID,
                            TypeOfOperationUsed = "UndoDelete"
                        };
                        metode.LogToDB(newLog1);

                        break;
                    case OperationType.Update:
                        Inventar tempUpdate = metode.SelectInventar(lastOperation.Item.ID);
                        var originalItem = lastOperation.Item;
                        metode.UpdateInventar(originalItem);

                        Log newLog2 = new()
                        {
                            IDlog = 0,
                            User = textBoxUsername.Text,
                            LogDate = DateTime.Now,
                            InvIdOperatedOn = originalItem.ID,
                            TypeOfOperationUsed = "UndoUpdate"
                        };
                        metode.LogToDB(newLog2);

                        lastOperation.Item = tempUpdate;
                        redoStack.Push(lastOperation);
                        break;
                }
                SearchForResults(sender, e);
                LoadComboBoxData();
                UpdateButtons();
            }
            else
            {
                MessageBox.Show("No actions to undo.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SelectId_CursorChanged(object sender, EventArgs e)
        {
            if (int.TryParse(selectId.Text, out int Id))
            {
                // Conversia a reușit, Id conține valoarea convertită
                var results = metode.SearchByID(Id);
                DisplayResults(results);
            }
            else
            {
                historyTextBox.Items.Clear();
                // Conversia a eșuat, deci nu este un număr întreg valid
                ListBoxItem listBoxItem = new($"Please enter a valid integer ID.\r\n", Color.Red);
                historyTextBox.Items.Add(listBoxItem);
            }
        }

        private void StartDate_ValueChanged(object sender, EventArgs e)
        {
            var results = metode.SearchByDate(startDate.Value, endDate.Value);
            DisplayResults(results);
        }

        private void EndDate_ValueChanged(object sender, EventArgs e)
        {
            var results = metode.SearchByDate(startDate.Value, endDate.Value);
            DisplayResults(results);
        }

        private void AppToBeSearched_TextChanged(object sender, EventArgs e)
        {
            string app = appToBeSearched.Text.Trim();
            var results = metode.SearchByApp(app);
            DisplayResults(results);
        }

        private void UpdateButtons()
        {
            // Enable the Undo/Redo button if there are commands to undo/redo
            undoButton.Enabled = (undoStack.Count > 0);
            redoButton.Enabled = (redoStack.Count > 0);
        }

        // Eveniment pentru desenarea fiecărui element din ListBox
        private void HistoryTextBox_DrawItem(object? sender, DrawItemEventArgs e)
        {
            // Cast sender to ListBox and check for nullability
            if (sender is ListBox listBox)
            {
                // Check if the index is valid
                if (e != null && e.Index >= 0 && e.Index < listBox.Items.Count)
                {
                    // Cast the item from the list box
                    if (listBox.Items[e.Index] is ListBoxItem item)
                    {
                        // Draw the background
                        e.DrawBackground();
                        // Draw the item text with its color
                        using (SolidBrush brush = new(item.Color))
                        {
                            if (e.Font != null)
                            {
                                e.Graphics.DrawString(item.Text, e.Font, brush, e.Bounds);
                            }
                        }
                        // Draw focus rectangle if needed
                        e.DrawFocusRectangle();
                    }
                }
            }
        }

        public void UpdateHistoryBox(ListBox historyBox, List<Inventar> items)
        {
            historyBox.Items.Clear(); // Golește lista înainte de a adăuga elementele actualizate

            foreach (var item in items)
            {
                // Calculează numărul de zile de la ultimul back-up
                TimeSpan timeSinceBackup = DateTime.Now - item.BackupDate;

                // Determină culoarea pe baza numărului de zile
                Color itemColor;
                if (timeSinceBackup.TotalDays < 365)
                {
                    itemColor = Color.Green; // VERDE închis pentru back-up mai nou de un an
                }
                else if (timeSinceBackup.TotalDays >= 365 && timeSinceBackup.TotalDays < 730)
                {
                    itemColor = Color.Goldenrod; // PORTOCALIU-GALBEN pentru back-up între 1 și 2 ani
                }
                else
                {
                    itemColor = Color.Red; // ROSU pentru back-up mai vechi de 2 ani
                }

                // Creează un obiect care să conțină textul și culoarea
                ListBoxItem listBoxItem = new($"ID = {item.ID} - Last Backup: {item.BackupDate.ToShortDateString()} - Apps: {item.Applications} ", itemColor);
                historyBox.Items.Add(listBoxItem);
            }

            historyBox.DrawMode = DrawMode.OwnerDrawFixed; // Setează modul de desenare personalizat
            historyBox.DrawItem += new DrawItemEventHandler(HistoryTextBox_DrawItem); // Eveniment pentru desenare
        }

        private void HistoryTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (historyTextBox.SelectedItem is ListBoxItem selectedItem)
            {
                MessageBox.Show(selectedItem.Text);
                Match match = Regex.Match(selectedItem.Text, @"\d+");
                if (match.Success)
                {
                    istoricid = int.Parse(match.Value);
                    appsTextBox.Text = string.Empty;
                    string prefix = "Apps: ";
                    string appsList = string.Empty;

                    // Găsește poziția prefixului "Apps: " în text
                    int prefixIndex = selectedItem.Text.IndexOf(prefix);
                    if (prefixIndex != -1)
                    {
                        // Adaugă lungimea prefixului pentru a începe după "Apps: "
                        int startIndex = prefixIndex + prefix.Length;

                        // Extrage tot ce urmează după "Apps: "
                        appsList = selectedItem.Text.Substring(startIndex).Trim();
                    }
                    appsTextBox.Text = appsList;
                    MessageBox.Show($"Dispozitiv selectat cu ID: {istoricid}");
                }
            }
        }

        // Filtru dupa ID
        private void SearchByID_MouseMove(object sender, MouseEventArgs e)
        {
            ToggleSearchOptions(1);
        }

        // Filtru dupa interval data
        private void SearchByDate_MouseMove(object sender, MouseEventArgs e)
        {
            ToggleSearchOptions(2);
        }

        // Filtru dupa aplicatii
        private void SearchByApp_MouseMove(object sender, MouseEventArgs e)
        {
            ToggleSearchOptions(3);
        }

        private void SelectId_EnabledChanged(object sender, EventArgs e)
        {
            SearchForResults(sender, e);
        }
    }
}