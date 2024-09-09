// See https://aka.ms/new-console-template for more information

using System.Data;
using ExcelDataReader;

string filePath = @"C:\Users\said_\Downloads\Results.xlsx";
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
// Reading from a .xls file (Excel 97-2003)
using var reader = ExcelReaderFactory.CreateReader(stream);
// Use the AsDataSet method to read the data into a DataSet
var result = reader.AsDataSet();

// Assuming the data is on the first sheet
var dataTable = result.Tables[0];

// Print the data
Console.WriteLine("Card Number\tAmount");
foreach (DataRow row in dataTable.Rows)
{
    // Assuming the cardNumber is in the first column (index 0)
    // and amount is in the second column (index 1)
    string cardNumber = row[0].ToString();
    string amount = row[1].ToString();

    Console.WriteLine($"{cardNumber}\t{amount}");
}