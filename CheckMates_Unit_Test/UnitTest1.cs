using Microsoft.VisualStudio.TestTools.UnitTesting;
using IT488_CheckMates_Checklist;
using System.Windows.Forms;
using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace IT488_CheckMates_Checklist.Tests
{
    [TestClass]
    public class HomePageTests
    {
        private HomePage homePage;

        [TestInitialize]
        public void Setup()
        {
            // Create a new instance of the HomePage form.
            // Run on a STA thread because Windows Forms requires it.
            Thread staThread = new Thread(
                (ThreadStart)(() =>
                {
                    homePage = new HomePage();
                    homePage.Show(); // Important for UI interaction
                }));

            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join(); // Wait for the thread to finish.
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (homePage != null)
            {
                // close the form on the UI thread.
                if (homePage.InvokeRequired)
                {
                    homePage.Invoke(new Action(() => homePage.Close()));
                }
                else
                {
                    homePage.Close();
                }

                homePage.Dispose();
                homePage = null;
            }
        }

        [TestMethod]
        public void AddButton_Click_AddsItemToCheckedListBox()
        {
            // Arrange
            string newItem = "Test List";
            TextBox itemTextBox = (TextBox)homePage.Controls["itemTextBox"];
            Button addButton = (Button)homePage.Controls["addButton"];
            CheckedListBox checkedListBox = (CheckedListBox)homePage.Controls["checkedListBox1"];

            // Act
            if (homePage.InvokeRequired)
            {
                homePage.Invoke(new Action(() =>
                {
                    itemTextBox.Text = newItem;
                    addButton.PerformClick();
                }));
            }
            else
            {
                itemTextBox.Text = newItem;
                addButton.PerformClick();
            }

            // Assert
            Assert.IsTrue(checkedListBox.Items.Contains(newItem));
        }

        [TestMethod]
        public void RemoveButton_Click_RemovesSelectedItemFromCheckedListBox()
        {
            // Arrange
            string newItem = "Test List";
            TextBox itemTextBox = (TextBox)homePage.Controls["itemTextBox"];
            Button addButton = (Button)homePage.Controls["addButton"];
            CheckedListBox checkedListBox = (CheckedListBox)homePage.Controls["checkedListBox1"];
            Button removeButton = (Button)homePage.Controls["removeButton"];

            // Act
            if (homePage.InvokeRequired)
            {
                homePage.Invoke(new Action(() =>
                {
                    itemTextBox.Text = newItem;
                    addButton.PerformClick();
                    checkedListBox.SelectedItem = newItem;
                    removeButton.PerformClick();
                    //Click yes on the message box.
                    SendKeys.SendWait("{ENTER}");
                }));
            }
            else
            {
                itemTextBox.Text = newItem;
                addButton.PerformClick();
                checkedListBox.SelectedItem = newItem;
                removeButton.PerformClick();
                SendKeys.SendWait("{ENTER}");
            }

            // Assert
            Assert.IsFalse(checkedListBox.Items.Contains(newItem));
        }

        [TestMethod]
        public void ClearButton_Click_OpensTaskPage()
        {
            // Arrange
            string newItem = "Test List";
            TextBox itemTextBox = (TextBox)homePage.Controls["itemTextBox"];
            Button addButton = (Button)homePage.Controls["addButton"];
            CheckedListBox checkedListBox = (CheckedListBox)homePage.Controls["checkedListBox1"];
            Button clearButton = (Button)homePage.Controls["ClearButton"];

            // Act
            if (homePage.InvokeRequired)
            {
                homePage.Invoke(new Action(() =>
                {
                    itemTextBox.Text = newItem;
                    addButton.PerformClick();
                    checkedListBox.SelectedItem = newItem;
                    clearButton.PerformClick();
                }));
            }
            else
            {
                itemTextBox.Text = newItem;
                addButton.PerformClick();
                checkedListBox.SelectedItem = newItem;
                clearButton.PerformClick();
            }

            // Assert
            Assert.IsTrue(System.Windows.Forms.Application.OpenForms["TaskPage"] != null);

            //Cleanup TaskPage
            if (System.Windows.Forms.Application.OpenForms["TaskPage"] != null)
            {
                System.Windows.Forms.Application.OpenForms["TaskPage"].Invoke(new Action(() => System.Windows.Forms.Application.OpenForms["TaskPage"].Close()));
            }
        }

        [TestMethod]
        public void EditButton_Click_OpensEditList()
        {
            // Arrange
            string newItem = "Test List";
            TextBox itemTextBox = (TextBox)homePage.Controls["itemTextBox"];
            Button addButton = (Button)homePage.Controls["addButton"];
            CheckedListBox checkedListBox = (CheckedListBox)homePage.Controls["checkedListBox1"];
            Button editButton = (Button)homePage.Controls["editButton"];

            // Act
            if (homePage.InvokeRequired)
            {
                homePage.Invoke(new Action(() =>
                {
                    itemTextBox.Text = newItem;
                    addButton.PerformClick();
                    checkedListBox.SelectedItem = newItem;
                    editButton.PerformClick();
                }));
            }
            else
            {
                itemTextBox.Text = newItem;
                addButton.PerformClick();
                checkedListBox.SelectedItem = newItem;
                editButton.PerformClick();
            }

            // Assert
            Assert.IsTrue(System.Windows.Forms.Application.OpenForms["EditList"] != null);

            //Cleanup EditList
            if (System.Windows.Forms.Application.OpenForms["EditList"] != null)
            {
                System.Windows.Forms.Application.OpenForms["EditList"].Invoke(new Action(() => System.Windows.Forms.Application.OpenForms["EditList"].Close()));
            }
        }
    }
}