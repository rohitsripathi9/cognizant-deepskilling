using System;

namespace FactoryMethodPatternExample
{
    public interface IDocument
    {
        void Open();
        void Save();
    }

    public interface IWordDocument : IDocument { }
    public interface IPdfDocument : IDocument { }
    public interface IExcelDocument : IDocument { }

    public class WordDocument : IWordDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening Word Document (.docx)...");
        }

        public void Save()
        {
            Console.WriteLine("Saving Word Document (.docx)...");
        }
    }

    public class PdfDocument : IPdfDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening PDF Document (.pdf)...");
        }

        public void Save()
        {
            Console.WriteLine("Saving PDF Document (.pdf)...");
        }
    }

    public class ExcelDocument : IExcelDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening Excel Spreadsheet (.xlsx)...");
        }

        public void Save()
        {
            Console.WriteLine("Saving Excel Spreadsheet (.xlsx)...");
        }
    }

    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }

    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }

    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }

    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Exercise 2: Factory Method Pattern Verification ---\n");

            DocumentFactory wordFactory = new WordDocumentFactory();
            DocumentFactory pdfFactory = new PdfDocumentFactory();
            DocumentFactory excelFactory = new ExcelDocumentFactory();

            Console.WriteLine("Creating Word Document using WordDocumentFactory...");
            IDocument wordDoc = wordFactory.CreateDocument();
            wordDoc.Open();
            wordDoc.Save();
            Console.WriteLine();

            Console.WriteLine("Creating PDF Document using PdfDocumentFactory...");
            IDocument pdfDoc = pdfFactory.CreateDocument();
            pdfDoc.Open();
            pdfDoc.Save();
            Console.WriteLine();

            Console.WriteLine("Creating Excel Document using ExcelDocumentFactory...");
            IDocument excelDoc = excelFactory.CreateDocument();
            excelDoc.Open();
            excelDoc.Save();
            Console.WriteLine();

            Console.WriteLine("SUCCESS: Factory Method Pattern works. Documents instantiated polymorphically through concrete factories.");
        }
    }
}
