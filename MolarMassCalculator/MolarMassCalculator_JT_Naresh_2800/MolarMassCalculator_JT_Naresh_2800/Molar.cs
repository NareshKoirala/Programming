/*MOLAR CLASS
 * this class is incharge of making sure that the data
 * is being named and parse properly
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MolarMassCalculator_JT_Naresh_2800
{
    internal class Molar
    {
        public int AtomicNum { get; private set; } // Stores the atomic number of the element
        public string Element { get; private set; } // Stores the element's full name (e.g., "Hydrogen")
        public string Symbol { get; private set; } // Stores the element's symbol (e.g., "H")
        public double Mass { get; private set; } // Stores the atomic mass of the element 

        // Constructor that takes a CSV-formatted string representing element data
        public Molar(string atoms)
        {
            // Splits the input string by commas to extract individual properties
            var data = atoms.Split(',');

            // Ensures that the input string contains at least 4 parts (atomic number, element name, symbol, mass)
            if (data.Length < 4)
            {
                throw new ArgumentException("CSV format incorrect"); // Throws an exception if the format is incorrect
            }

            // Attempts to parse the first value as an integer for AtomicNum
            if (!int.TryParse(data[0].Trim(), out int atomicNum))
            {
                throw new FormatException($"Invalid Atomic Number: {data[0]}"); // Throws an exception if parsing fails
            }

            // Attempts to parse the fourth value as a double for atomic mass
            if (!double.TryParse(data[3].Trim(), out double atomicMass))
            {
                throw new FormatException($"Invalid Atomic Mass: {data[3]}"); // Throws an exception if parsing fails
            }

            // Assigns parsed values to the properties
            AtomicNum = atomicNum; // Stores the atomic number
            Element = data[1].Trim(); // Stores the element's full name (trimmed of whitespace)
            Symbol = data[2].Trim(); // Stores the element's symbol (trimmed of whitespace)
            Mass = atomicMass; // Stores the atomic mass
        }
    }
}
