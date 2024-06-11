using System;
namespace Design_Patterns.Creational.FactoryPattern
{
    // Product interface
    interface IDocumentConverter
    {
        void Convert(string inputFilePath, string outputFilePath);
    }

    // Concrete products
    class PdfToWordConverter : IDocumentConverter
    {
        public void Convert(string inputFilePath, string outputFilePath)
        {
            // Convert PDF to Word document
        }
    }

    class WordToPdfConverter : IDocumentConverter
    {
        public void Convert(string inputFilePath, string outputFilePath)
        {
            // Convert Word document to PDF
        }
    }

    class HtmlToPdfConverter : IDocumentConverter
    {
        public void Convert(string inputFilePath, string outputFilePath)
        {
            // Convert HTML document to PDF
        }
    }

    // Factory interface
    interface IDocumentConverterFactory
    {
        IDocumentConverter CreateDocumentConverter(DocumentConversionType type);
    }

    // Concrete factory
    class DocumentConverterFactory : IDocumentConverterFactory
    {
        public IDocumentConverter CreateDocumentConverter(DocumentConversionType type)
        {
            switch (type)
            {
                case DocumentConversionType.PdfToWord:
                    return new PdfToWordConverter();
                case DocumentConversionType.WordToPdf:
                    return new WordToPdfConverter();
                case DocumentConversionType.HtmlToPdf:
                    return new HtmlToPdfConverter();
                default:
                    throw new NotSupportedException($"Document conversion type '{type}' is not supported.");
            }
        }
    }

    enum DocumentConversionType
    {
        PdfToWord,
        WordToPdf,
        HtmlToPdf
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        IDocumentConverterFactory documentConverterFactory = new DocumentConverterFactory();

    //        IDocumentConverter pdfToWordConverter = documentConverterFactory.CreateDocumentConverter(DocumentConversionType.PdfToWord);
    //        pdfToWordConverter.Convert("input.pdf", "output.docx");

    //        IDocumentConverter htmlToPdfConverter = documentConverterFactory.CreateDocumentConverter(DocumentConversionType.HtmlToPdf);
    //        htmlToPdfConverter.Convert("input.html", "output.pdf");
    //    }
    //}

}

