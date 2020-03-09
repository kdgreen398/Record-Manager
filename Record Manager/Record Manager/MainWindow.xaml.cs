using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Record_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int current_record_num = 1; // index of record currently being viewed [not zero-based]
        private int nav_index = 0; // index of record currently being viewed in search results [zero-based]

        private bool source_loaded = false; // is source file loaded

        ArrayList search_results = null; // list of record indexes after search

        private string search_type = "Default";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                FileHandler.CreateFormattedFiles(openFileDialog.FileName);
                source_loaded = true;
                open_file_button.Visibility = Visibility.Hidden;

                ShowRecord(0, false);

            }
        }

        void ShowRecord(int index, bool has_results)
        {
            current_record_num = index + 1;
            gotoBox.Text = (index + 1).ToString() + " of " + FileHandler.rec_count;
            // if we have search results , then update the search navingation box to diplay the correct record number
            if (has_results)
            {
                search_result_textbox.Text = (nav_index + 1).ToString() + " of " + search_results.Count;
            }


            using (BinaryReader br = new BinaryReader(File.OpenRead(FileHandler.formatted_filepath)))
            {
                br.BaseStream.Position = index * FileHandler.rec_length;
                char c;
                String field_data = "";
                for (int i = 0; i < FileHandler.author_cap; i++)
                {
                    c = br.ReadChar();
                    if (c != '~')
                        field_data += c;
                }

                author_textbox.Content = field_data;

                field_data = "";
                for (int i = 0; i < FileHandler.title_cap; i++)
                {
                    c = br.ReadChar();
                    if (c != '~')
                        field_data += c;
                }
                title_textbox.Text = field_data;

                field_data = "";
                for (int i = 0; i < FileHandler.journal_cap; i++)
                {
                    c = br.ReadChar();
                    if (c != '~')
                        field_data += c;
                }
                journal_textbox.Content = field_data;

                field_data = "(";
                for (int i = 0; i < FileHandler.year_cap; i++)
                {
                    c = br.ReadChar();
                    if (c != '~')
                        field_data += c;
                }
                field_data += ')';
                year_textbox.Content = field_data;

                field_data = "";
                for (int i = 0; i < FileHandler.abstract_cap; i++)
                {
                    c = br.ReadChar();
                    if (c != '~')
                        field_data += c;
                }
                abstract_textbox.Text = field_data;

            }

        }

        private void BeginSearch(object sender, MouseButtonEventArgs e)
        {

            if (!source_loaded)
                return;

            string file_path;
            int cap_to_use;
            int count;
            switch (search_by_combo.SelectionBoxItem.ToString())
            {
                case "Title":
                    file_path = FileHandler.title_filepath;
                    cap_to_use = FileHandler.title_cap;
                    count = FileHandler.rec_count - 1;
                    break;
                case "Author":
                    file_path = FileHandler.author_filepath;
                    cap_to_use = FileHandler.author_cap;
                    count = FileHandler.rec_count - 1;
                    break;
                case "Keyword":
                    file_path = FileHandler.keyword_filepath;
                    cap_to_use = FileHandler.keyword_cap;
                    count = FileHandler.keyword_count - 1;
                    break;
                default:
                    file_path = FileHandler.keyword_filepath;
                    cap_to_use = FileHandler.keyword_cap;
                    count = FileHandler.rec_count - 1;
                    break;
            }



            using (BinaryReader br = new BinaryReader(File.Open(file_path, FileMode.Open)))
            {
                switch (search_type)
                {
                    case "Default":
                        search_results = SearchHandler.BinarySearch(search_type, cap_to_use, br, search_box.Text.ToLower(), count);
                        break;
                    case "Boolean":
                        ArrayList result_1 = SearchHandler.BinarySearch(search_type, cap_to_use, br, search_box.Text.ToLower(), count);
                        ArrayList result_2 = SearchHandler.BinarySearch(search_type, cap_to_use, br, search_box2.Text.ToLower(), count);
                        search_results = SetOperation(result_1, result_2, boolean_combo.SelectionBoxItem.ToString());
                        if (search_results != null)
                            search_results.Sort();
                        break;
                    case "Wildcard":
                        search_results = SearchHandler.BinarySearch(search_type, cap_to_use, br, search_box.Text.ToLower(), count);
                        if (search_results != null)
                            search_results.Sort();
                        break;
                }

                if (search_results != null)
                {
                    nav_index = 0;
                    // search result contains indexes that are not zero-based, so we must subtract 1 to fix any errors
                    ShowRecord((int)search_results[nav_index] - 1, true);
                }
                else
                {
                    // if results from binary search is null
                    author_textbox.Content = "Nothing found";
                    title_textbox.Text = "";
                    journal_textbox.Content = "";
                    year_textbox.Content = "";
                    abstract_textbox.Text = "";
                }

            }

        }

        private ArrayList SetOperation(ArrayList set_1, ArrayList set_2, string operation)
        {
            if (set_1 != null & set_2 != null)
            {
                ArrayList result = null;
                if (operation == "AND")
                {
                    result = new ArrayList();
                    foreach (int record in set_1)
                    {
                        if (set_2.Contains(record))
                            result.Add(record);
                    }
                }
                else
                {
                    result = set_1;
                    foreach (int record in set_2)
                    {
                        if (!result.Contains(record))
                            result.Add(record);
                    }
                }

                return result;
            }
            return null;
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Background = new SolidColorBrush(Color.FromArgb(20, 0, 0, 0));
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            lbl.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }

        private void Next(object sender, MouseButtonEventArgs e)
        {
            if (search_results != null)
            {
                if (nav_index < search_results.Count - 1)
                {
                    nav_index++;
                    ShowRecord((int)search_results[nav_index] - 1, true);
                }
            }
            else if (current_record_num < FileHandler.rec_count)
            {
                current_record_num++;
                ShowRecord(current_record_num - 1, false);
            }
        }

        private void Back(object sender, MouseButtonEventArgs e)
        {
            if (search_results != null)
            {
                if (nav_index > 0)
                {
                    nav_index--;
                    ShowRecord((int)search_results[nav_index] - 1, true);
                }
            }
            else if (current_record_num > 1)
            {
                current_record_num--;
                ShowRecord(current_record_num - 1, false);
            }

        }

        private void GoTo(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int num = Int32.Parse(gotoBox.Text);
                current_record_num = num;
                if (num >= 1 && num <= FileHandler.rec_count)
                {

                    search_results = null;
                    ShowRecord(num - 1, false);
                    search_result_textbox.Text = "--  of --";
                }
                else
                    gotoBox.Text = "invalid entry";
            }
            catch (System.FormatException)
            {
                gotoBox.Text = "invalid entry";
            }

        }

        private void ClearTextBox(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = "";
        }

        private void search_type_combobox_DropDownClosed(object sender, EventArgs e)
        {
            search_type = search_type_combobox.SelectionBoxItem.ToString();

            if (search_type == "Boolean")
            {
                search_box2.Visibility = Visibility.Visible;
                boolean_combo.Visibility = Visibility.Visible;
            }
            else
            {
                search_box2.Visibility = Visibility.Hidden;
                boolean_combo.Visibility = Visibility.Hidden;
            }
        }
    }
}