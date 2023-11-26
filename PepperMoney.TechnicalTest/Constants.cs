namespace PepperMoney.TechnicalTest
{
    public static class Constants
    {
        #region configuration
        public static string CONNECTION_STRING_FIELD_NAME = "SQLBooks";
        #endregion

        #region exceptions
        public static string EXCEPTION_BUILDING_CONTEXT = "Error context building in BooksService";

        public static string EXCEPTION_BUILDING_SERVICE = "Error service building in BooksController";

        public static string EXCEPTION_BUILDING_CONFIGURATION = "Error configuration building in BooksService";

        public static string EXCEPTION_BOOK_ALREADY_EXISTS = "The book {0} already exists in the database";
        #endregion

        #region messages
        public static string MESSAGE_BOOK_NULL = "Book from http body is null or empty. Check that the title is not empty";
        #endregion
    }
}
