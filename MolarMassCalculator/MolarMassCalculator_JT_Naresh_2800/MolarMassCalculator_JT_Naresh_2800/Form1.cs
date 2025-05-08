/*Programmer's block
 * Names: JT & Naresh
 * Molar Mass Calculations
 * Molar CSV file from: https://gist.github.com/GoodmanSciences/c2dd862cd38f21b0ad36b8f96b4bf1ee
 * The program calculates 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace MolarMassCalculator_JT_Naresh_2800
{
    public partial class Form1 : Form
    {
        // Variable 
        List<Molar> OriginalCopy;
        private Dictionary<string, double> elementMasses = new Dictionary<string, double>();
        private string invalid_Char = string.Empty;

        public Form1()
        {
            InitializeComponent();
            // Enable the drag and drop functionality
            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;

            // PreLoad the Data grid view with the CSV file
            string filePath = @"..\..\..\..\Periodic Table of Elements.csv";
            LoadCVS(filePath);

            _searchTextBox.TextChanged += _searchTextBox_TextChanged;
            UI_Lbl_MolarMass.ForeColor = Color.DarkGreen;


        }

        private void _searchTextBox_TextChanged(object sender, EventArgs e)
        {

            if (UI_DataGridView is null || OriginalCopy is null)
                return;

            if (string.IsNullOrEmpty(_searchTextBox.Text))
            {
                UI_DataGridView.DataSource = new BindingList<Molar>(OriginalCopy);
                return;
            }

            if (UI_DataGridView.DataSource is BindingList<Molar> molarList)
            {
                var text = _searchTextBox.Text.Trim().ToLower();
                var sortedLINQ = (
                                     from m in molarList
                                     orderby m.AtomicNum == (!string.IsNullOrEmpty(text) && int.TryParse(text, out _) ? int.Parse(text) : 0) descending,
                                             m.Symbol.ToLower().Contains(text) descending,
                                             m.Element.ToLower().Contains(_searchTextBox.Text.Trim()) descending,
                                             m.Symbol.Length > 1,
                                             m.Symbol,
                                             m.Element
                                     select m
                                 );
                UI_DataGridView.DataSource = new BindingList<Molar>(sortedLINQ.ToList());
            }
        }

        // Handle drag enter event
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the data being dragged is a file drop
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Allow copy operation
            }
            else
            {
                e.Effect = DragDropEffects.None; // Disallow operation
            }
        }
        // Handle drop event handler
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // Retriece the file paths of the dropped files
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if(files.Length > 0)
            {
                LoadCVS(files[0]);
            }
        }

        // The LoadCSV file method takes in a filepath
        // and in charge of displaying the data onto the datagrid view
        private void LoadCVS(string filePath)
        {
            // creating a List with the Molar class
            List<Molar> molarList = new List<Molar>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length <= 1) return; // No data to process

                foreach (string line in lines.Skip(1)) // Skip header row
                {
                    try
                    {
                        Molar molar = new Molar(line);
                        molarList.Add(molar);
                        elementMasses[molar.Symbol] = molar.Mass; // Store in dictionary for lookups
                    }
                    catch (FormatException fe)
                    {
                        MessageBox.Show($"Error parsing line: {line}\n{fe.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                OriginalCopy = molarList;

                UI_DataGridView.DataSource = new BindingList<Molar>(molarList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File error: {ex}");
            }
        }

        private void UI_Btn_SortByName_Click(object sender, EventArgs e)
        {
            // Simple Element order
            if (UI_DataGridView.DataSource is BindingList<Molar> molarList)
            {
                //  molarList.OrderBy(m =>  m.Element).ToList();
                var sortedLINQ = (
                                    from m in molarList
                                    orderby m.Element
                                    select m
                                 );
                UI_DataGridView.DataSource = new BindingList<Molar>(sortedLINQ.ToList());
            }
        }

        private void UI_Btn_SortByAtomicNum_Click(object sender, EventArgs e)
        {
            if (UI_DataGridView.DataSource is BindingList<Molar> molarList)
            {
                //  molarList.OrderBy(m => m.AtomicNum).ToList();
                var sortedLINQ = (
                                    from m in molarList
                                    orderby m.AtomicNum
                                    select m
                                 );
                UI_DataGridView.DataSource = new BindingList<Molar>(sortedLINQ.ToList());
            }
        }

        private void UI_Btn_SingleChar_Click(object sender, EventArgs e)
        {
            // not so simple sorting symbol
            if( UI_DataGridView.DataSource is BindingList<Molar> molarList)
            {
                // false (single-character symbols) comes before true (multi-character symbols).
                // molarList.OrderBy(m => m.Symbol.Length > 1).ThenBy(m => m.Symbol).ToList()
                var sortedLINQ = (
                                    from m in molarList
                                    orderby m.Symbol.Length > 1 , m.Symbol
                                    select m
                                 );
                UI_DataGridView.DataSource = new BindingList<Molar>(sortedLINQ.ToList());
            }
        }

        private void UI_TB_ChemFormula_TextChanged(object sender, EventArgs e)
        {
            bool allElementsMatch = true;

            // Clears the text in the search text box
            _searchTextBox.Text = string.Empty;

            // Retrieves the chemical formula entered by the user and trims any leading/trailing whitespace
            string formula = UI_TB_ChemFormula.Text.Trim().Replace(" ", string.Empty);


            // Checks if the DataGridView or the OriginalCopy list is null; if so, exits the method to prevent errors
            if (UI_DataGridView is null || OriginalCopy is null)
                return;

            // If the formula is empty, reset the DataGridView to show the original unfiltered data
            if (string.IsNullOrEmpty(formula))
            {
                invalid_Char = string.Empty;
                UI_DataGridView.DataSource = OriginalCopy;
                UI_Lbl_MolarMass.Text = "";
                return;
            }

            // Defines a regular expression pattern to extract chemical elements and their quantities from the formula
            // Pattern breakdown:
            // - ([A-Z][a-z]?) -> Captures an element symbol (first letter uppercase, optional second letter lowercase)
            // - (\d*) -> Captures the optional number following the element (if missing, it defaults to 1)
            var main_regex = new System.Text.RegularExpressions.Regex(@"([A-Z][a-z]?)(\d*)");
            Console.WriteLine(main_regex); // debug purposes: Prints the regex pattern

            // Applies the regex to the formula and converts the matches into an enumerable collection
            var matches = main_regex.Matches(formula).Cast<System.Text.RegularExpressions.Match>();


            allElementsMatch = Main_Check(formula);

            if (!char.IsLetter(formula.First()) || char.IsLower(formula.First())) 
            { 
                allElementsMatch = false; 
                invalid_Char += formula.First() + ", "; 
            }

            foreach (var item in matches)
            {
                string replace = Regex.Replace(item.ToString(), @"\d+", string.Empty);

                if (!OriginalCopy.Any(x => x.Symbol == replace.ToString()))
                {
                    allElementsMatch = false;
                    invalid_Char += replace.ToString() + ", ";
                }
            }

            // Sets the ForeColor based on the matching result
            UI_Lbl_MolarMass.ForeColor = allElementsMatch ? Color.Green : Color.Red;



            // LINQ query to extract element details from the matches
            var elementsQuery =
                    from match in matches
                        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expressions
                        // In regular expressions (Regex) in C#, the .Groups property of
                        // a Match object stores captured groups from a match.
                        // It allows you to extract specific parts of the matched text.
                    let symbol = match.Groups[1].Value
                    let count = string.IsNullOrEmpty(match.Groups[2].Value) ? 1 : int.Parse(match.Groups[2].Value)
                    // Extracts the count of the element; defaults to 1 if the number is missing
                    where elementMasses.ContainsKey(symbol)
                    // Ensures the element is valid by checking the dictionary
                    group count by symbol into grouped
                    join m in OriginalCopy on grouped.Key equals m.Symbol
                    select new
                    {
                        Element = m.Element,
                        Count = grouped.Sum(), // Sum all occurrences of the same element
                        Mass = elementMasses[grouped.Key],
                        TotalMass = Math.Round(grouped.Sum() * elementMasses[grouped.Key], 3)
                    };


            // elementsQuery.ToList().Sum(x => x.TotalMass)
            if (UI_Lbl_MolarMass.ForeColor == Color.Green)
            {
                UI_Lbl_MolarMass.Text = (
                                            from m in elementsQuery
                                            select m.TotalMass
                                        ).Sum().ToString() + "g/mol";
                invalid_Char = string.Empty;
            }
            else UI_Lbl_MolarMass.Text = "Invalid: " + invalid_Char;

            // elementsQuery.OrderBy(x => x.Mass).ToList()
            UI_DataGridView.DataSource = (
                                            from element in elementsQuery
                                            orderby element.Mass
                                            select element
                                         ).ToList();
        }

        private bool Main_Check(string formula)
        {
            var lower_regex = new System.Text.RegularExpressions.Regex(@"([a-z][a-z])");
            var symbol_regex = new System.Text.RegularExpressions.Regex(@"[^\w\s]");
            var num_regex = new System.Text.RegularExpressions.Regex(@"(\d[a-z])");

            var lower_matches = lower_regex.Matches(formula).Cast<System.Text.RegularExpressions.Match>();
            var symbol_matches = symbol_regex.Matches(formula).Cast<System.Text.RegularExpressions.Match>();
            var num_matches = num_regex.Matches(formula).Cast<System.Text.RegularExpressions.Match>();

            foreach (var match in lower_matches) { invalid_Char += match + " "; }
            foreach (var match in symbol_matches) { invalid_Char += match + " "; }
            foreach (var match in num_matches) { invalid_Char += match + " "; }

            if (lower_matches.Count() != 0 || symbol_matches.Count() != 0 || num_matches.Count() != 0)
                return false;

            return true;
        }
    }
}