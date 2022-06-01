namespace Sample.Common
{
    public static class ApiRoute
    {
        #region User
        public static class Users
        {
            public const string AddUser = "api/user/add";
            public const string UpdateUser = "api/user/update";
            public const string DeleteUser = "api/user/delete/{userid}";
            public const string GetUsers = "api/user/search";
        }
        #endregion
    }
}
